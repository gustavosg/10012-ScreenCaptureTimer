using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Library.Core.Util.Logger;
using System.IO;

namespace Library.Core.GUI.WPF.ScreenShotHelper
{
    public class ScreenShotHelper
    {
        /// <summary>
        /// Save's Image 
        /// </summary>
        public void SaveScreenImage()
        {
            try
            {
                Bitmap bmp = CaptureScreen();
                String dateTime = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                FileInfo filename = new FileInfo(@"D:\TEMP\" + dateTime + ".jpg");
                //filename = filename.Replace("/", "");
                //filename = filename.Replace(":", "");
                bmp.Save(filename.FullName, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                throw ex;
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Bitmap CaptureScreen()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.CopyFromScreen(
                Screen.PrimaryScreen.Bounds.X,
                Screen.PrimaryScreen.Bounds.Y,
                0, 0,
                bmp.Size,
                CopyPixelOperation.SourceCopy);

            return bmp;
        }
    }
}
