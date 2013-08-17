using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Library.Core.Gui.WPF.ScreenShotHelper
{
    public class ScreenShotHelper
    {
        /// <summary>
        /// Save's Image 
        /// </summary>
        public void SaveScreenImage()
        {
            Bitmap bmp = CaptureScreen();
            String filename = String.Empty;
            DateTime dateTime = DateTime.UtcNow;
            filename = @"D:\TEMP\" + dateTime.ToLocalTime() + ".jpg";
            filename = filename.Replace("/", "");
            filename = filename.Replace(":", "");
            bmp.Save(filename);
        }

        /// <summary>
        /// Select mode to save captured image
        /// </summary>
        /// <param name="mode"></param>
        private void CaptureScreenModeSelect(String mode)
        {

            switch (mode)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    break;
            }
        }


        private Bitmap CaptureScreen()
        {
            using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(
                        Screen.PrimaryScreen.Bounds.X,
                        Screen.PrimaryScreen.Bounds.Y,
                        0, 0,
                        bmp.Size,
                        CopyPixelOperation.SourceCopy);
                }
                return bmp;
            };
        }
    }
}
