using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Tableware
{
    static class CaptchaGeneration
    {
        private static string _cod;
        
        static CaptchaGeneration()
        {

        }
        static int[] number = new int[4];
        private static void GenerationCode()
        {
            Random random = new Random();
            _cod = ((char)random.Next(33, 122)).ToString();
            for (int i = 0; i < 3; i++)
            {
                _cod += ((char)random.Next(33, 122)).ToString();
                
            }
        }
        private static System.Drawing.Point[] GenerationLine() 
        {
            Random random = new Random();
            System.Drawing.Point[] points = new System.Drawing.Point[random.Next(2, 5)];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new System.Drawing.Point((150 / points.Length) * i, random.Next(40));
            }
            return points;
        }
        private static BitmapSource GenerateBitmap()
        {
            Bitmap bitmap = new Bitmap(150, 40);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Font font = new Font("Arial", 20);
                
                g.DrawString(_cod, font, System.Drawing.Brushes.Green, 1, 1);
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 4);
                g.DrawLines(pen, GenerationLine());
            }
            return Convert(bitmap);
        }
        public static BitmapSource Convert(System.Drawing.Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);
            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
        public static BitmapSource GetBitmap()
        {
            GenerationCode();
         
            return GenerateBitmap();
        }

        public static bool CheckCode(string code)
        {
            return _cod == code;
        }
    }
}
