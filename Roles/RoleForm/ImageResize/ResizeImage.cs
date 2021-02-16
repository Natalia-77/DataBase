﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace FormRoles.ImageResize
{
    public class ResizeImage
    {
        public static Bitmap ResizeOrigImg(Bitmap image, int nWidth, int nHeight)
        {
            int newWidth, newHeight;
            var coefH = (double)nHeight / (double)image.Height;
            var coefW = (double)nWidth / (double)image.Width;
            if (coefW >= coefH)
            {
                newHeight = (int)(image.Height * coefH);
                newWidth = (int)(image.Width * coefH);
            }
            else
            {
                newHeight = (int)(image.Height * coefW);
                newWidth = (int)(image.Width * coefW);
            }

            using (Bitmap outBmp = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb))
            {
               
                using (var g = Graphics.FromImage(outBmp))
                {
                    //g.CompositingQuality = CompositingQuality.HighQuality;
                    //g.SmoothingMode = SmoothingMode.HighQuality;
                    //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                    return new Bitmap(outBmp);
                    g.Dispose();
                }
            }
            
        }

    }
}
