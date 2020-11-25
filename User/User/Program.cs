using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace FileManager
{

    public delegate void OnKey(ConsoleKeyInfo key);

    class Program
    {      

        static void Main(string[] args)
        {
            FileManager manager = new FileManager();
            manager.Explore();
        }
    }
}
