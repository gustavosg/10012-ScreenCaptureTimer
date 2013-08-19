using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Library.Core.Util.Logger;
using Library.Core.Util.Singleton;

namespace Library.Core.GUI.WPF.ScreenShotHelper
{
    public class ScreenShotHelper : Singleton<ScreenShotHelper>
    {

        public ScreenShotHelper()
        {

        }

        /// <summary>
        /// Save's Image 
        /// </summary>
        public void SaveScreenImage()
        {
            try
            {
                Log.Info("Iniciando captura da tela...");

                Bitmap bmp = CaptureScreen();
                String dateTime = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                FileInfo filename = new FileInfo(@"D:\TEMP\" + dateTime + ".jpg");
                bmp.Save(filename.FullName, ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                Log.Info("Captura da tela realizado com sucesso!");
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
