using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FileManager

{
    class FileManager
    {
        //========================== Static ==========================

        public static int HEIGHT_KEYS = 3;
        public static int BOTTOM_OFFSET = 2;

        //========================== Поля ==========================

        public event OnKey KeyPress;
        List<FilePanel> panels = new List<FilePanel>();
        private int activePanelIndex;

        //========================== Методи ==========================

       

        static FileManager()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 41);
            Console.SetBufferSize(100, 41);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public FileManager()
        {
            FilePanel filePanel = new FilePanel();
            filePanel.Top = 0;
            filePanel.Left = 0;
            this.panels.Add(filePanel);

            filePanel = new FilePanel();
            filePanel.Top = FilePanel.panel_height;
            filePanel.Left = 0;
            this.panels.Add(filePanel);

            activePanelIndex = 0;

            this.panels[this.activePanelIndex].Active = true;
            KeyPress += this.panels[this.activePanelIndex].KeyboardProcessing;

            foreach (FilePanel fp in panels)
            {
                fp.Show();
            }

            this.ShowKeys();
        }

        

        public void Explore()
        {
            bool exit = false;
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    this.ClearMessage();

                    ConsoleKeyInfo userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.Tab:
                            this.ChangeActivePanel();
                            break;
                        case ConsoleKey.Enter:
                            this.ChangeDirectoryOrRunProcess();
                            break;                       
                        case ConsoleKey.F5:
                            this.Copy();
                            break;
                        case ConsoleKey.F6:
                            this.Move();
                            break;                       
                        case ConsoleKey.F9:
                             Delete();
                            break;
                        case ConsoleKey.F10:
                            exit = true;
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        case ConsoleKey.DownArrow:                          
                             goto case ConsoleKey.Help;
                        case ConsoleKey.UpArrow:
                             goto case ConsoleKey.Help;                       
                        case ConsoleKey.Help:
                            KeyPress(userKey);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
       

        private void Copy()
        {
            foreach (FilePanel panel in panels)
            {
                if (panel.isDiscs)
                {
                    return;
                }
            }

            if (this.panels[0].Path == this.panels[1].Path)
            {
                return;
            }

            try
            {
                string destPath = this.activePanelIndex == 0 ? this.panels[1].Path : this.panels[0].Path;

                FileSystemInfo fileObject = this.panels[this.activePanelIndex].GetActiveObject();
                FileInfo currentFile = fileObject as FileInfo;

                if (currentFile != null)
                {
                    string fileName = currentFile.Name;
                    string destName = Path.Combine(destPath, fileName);
                    File.Copy(currentFile.FullName, destName, true);
                }

                else
                {
                    string currentDir = ((DirectoryInfo)fileObject).FullName;
                    string destDir = Path.Combine(destPath, ((DirectoryInfo)fileObject).Name);
                    CopyDirectory(currentDir, destDir);
                }

                this.RefreshPannels();
            }
            catch (Exception e)
            {
                this.ShowMessage(e.Message);
                return;
            }
        }

        private void CopyDirectory(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                CopyDirectory(subdir.FullName, temppath);
            }
        }

        private void Delete()
        {
            if (this.panels[this.activePanelIndex].isDiscs)
            {
                return;
            }

            FileSystemInfo fileObject = this.panels[this.activePanelIndex].GetActiveObject();
            try
            {
                if (fileObject is DirectoryInfo)
                {
                    ((DirectoryInfo)fileObject).Delete(true);
                }
                else
                {
                    ((FileInfo)fileObject).Delete();
                }
                this.RefreshPannels();
            }
            catch (Exception e)
            {
                this.ShowMessage(e.Message);
                return;
            }
        }

       

        private void Move()
        {
            foreach (FilePanel panel in panels)
            {
                if (panel.isDiscs)
                {
                    return;
                }
            }

            if (this.panels[0].Path == this.panels[1].Path)
            {
                return;
            }

            try
            {
                string destPath = this.activePanelIndex == 0 ? this.panels[1].Path : this.panels[0].Path;
                FileSystemInfo fileObject = this.panels[this.activePanelIndex].GetActiveObject();

                string objectName = fileObject.Name;
                string destName = Path.Combine(destPath, objectName);

                if (fileObject is FileInfo)
                {
                    ((FileInfo)fileObject).MoveTo(destName);
                }
                else
                {
                    ((DirectoryInfo)fileObject).MoveTo(destName);
                }

                this.RefreshPannels();
            }
            catch (Exception e)
            {
                this.ShowMessage(e.Message);
                return;
            }

        }

      

        private void RefreshPannels()
        {
            if (this.panels == null || this.panels.Count == 0)
            {
                return;
            }

            foreach (FilePanel panel in panels)
            {
                if (!panel.isDiscs)
                {
                    panel.UpdateContent(true);
                }
            }
        }

        private void ChangeActivePanel()
        {
            this.panels[this.activePanelIndex].Active = false;
            KeyPress -= this.panels[this.activePanelIndex].KeyboardProcessing;
            this.panels[this.activePanelIndex].UpdateContent(false);

            this.activePanelIndex++;
            if (this.activePanelIndex >= this.panels.Count)
            {
                this.activePanelIndex = 0;
            }

            this.panels[this.activePanelIndex].Active = true;
            KeyPress += this.panels[this.activePanelIndex].KeyboardProcessing;
            this.panels[this.activePanelIndex].UpdateContent(false);
        }

        private void ChangeDirectoryOrRunProcess()
        {
            FileSystemInfo fsInfo = this.panels[this.activePanelIndex].GetActiveObject();
            if (fsInfo != null)
            {
                if (fsInfo is DirectoryInfo)
                {
                    try
                    {
                        Directory.GetDirectories(fsInfo.FullName);
                    }
                    catch
                    {
                        return;
                    }

                    this.panels[this.activePanelIndex].Path = fsInfo.FullName;
                    this.panels[this.activePanelIndex].SetLists();
                    this.panels[this.activePanelIndex].UpdatePanel();
                }
                else
                {
                    Process.Start(((FileInfo)fsInfo).FullName);
                }
            }
            else
            {
                string currentPath = this.panels[this.activePanelIndex].Path;
                DirectoryInfo currentDirectory = new DirectoryInfo(currentPath);
                DirectoryInfo upLevelDirectory = currentDirectory.Parent;

                if (upLevelDirectory != null)
                {
                    this.panels[this.activePanelIndex].Path = upLevelDirectory.FullName;
                    this.panels[this.activePanelIndex].SetLists();
                    this.panels[this.activePanelIndex].UpdatePanel();
                }

                else
                {
                    this.panels[this.activePanelIndex].SetDiscs();
                    this.panels[this.activePanelIndex].UpdatePanel();
                }
            }
        }

        private void ShowKeys()
        {
            string[] menu = { "F5 Copy", "F6 Move","F9 Delete", "F10 Exit" };

            int cellLeft = this.panels[0].Left;
            int cellTop = FilePanel.panel_height * panels.Count;
            int cellWidth = FilePanel.panel_width / menu.Length;
            int cellHeight = FileManager.HEIGHT_KEYS;

            for (int i = 0; i < menu.Length; i++)
            {
                PsCon.PsCon.PrintFrameLine(cellLeft + i * cellWidth, cellTop, cellWidth, cellHeight, ConsoleColor.Red, ConsoleColor.Black);
                PsCon.PsCon.PrintString(menu[i], cellLeft + i * cellWidth + 1, cellTop + 1, ConsoleColor.Green, ConsoleColor.Black);
            }
        }

        private void ShowMessage(string message)
        {
            PsCon.PsCon.PrintString(message, 0, Console.WindowHeight - BOTTOM_OFFSET, ConsoleColor.White, ConsoleColor.Black);
        }

        private void ClearMessage()
        {
            PsCon.PsCon.PrintString(new String(' ', Console.WindowWidth), 0, Console.WindowHeight - BOTTOM_OFFSET, ConsoleColor.White, ConsoleColor.Black);
        }
    }

}
