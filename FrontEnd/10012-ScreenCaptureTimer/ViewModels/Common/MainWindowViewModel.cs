// --------------------------------------------------------------------------------
// Detalhes do Sistema: 10012 - ScreenCaptureTimer
// Descrição: 
//
// --------------------------------------------------------------------------------
//
//
//
//
// --------------------------------------------------------------------------------

using System;

using Library.Core.GUI.WPF.ScreenShotHelper;
using Library.Core.GUI.ViewModelHelpers;
using Library.Core.Util.Logger;
using Library.Core.Util.Singleton;
using System.Configuration;
using System.Windows;

namespace ScreenCaptureTimer.ViewModels
{
    public class MainWindowViewModel
    {

        #region Fields

        private Int16 timer = 0;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {

            ConfigureScreenShot();

            ActivateScreenShot();

        }

        #endregion

        #region Commands

        private RelayCommand tirarFoto;
        public RelayCommand TirarFoto
        {
            get
            {
                if (tirarFoto == null)
                    tirarFoto = new RelayCommand(param => DoTirarFoto(), param => CanTirarFoto);
                return tirarFoto;
            }
        }

        #endregion

        #region Métodos

        // --------------------------------------------------------------------------------
        // Geral

        /// <summary>
        /// Tira foto da tela
        /// </summary>
        public void DoTirarFoto()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(timer * 1000);

                ScreenShotHelper.GetSingleton().SaveScreenImage();
            }
        }

        private Boolean CanTirarFoto
        {
            get { return true; }
        }

        /// <summary>
        /// Verifica a configuração do timer para capturar a tela
        /// </summary>
        private void ConfigureScreenShot()
        {
            timer = Convert.ToInt16(ConfigurationManager.AppSettings["TimerScreenShot"].ToString());

            if (timer == 0)
            {
                try
                {
                    MessageBox.Show("Variável TimerScreenShot não pode ser igual a 0 na configuração do sistema!");
                    throw new Exception("Variável TimerScreenShot não pode ser igual a 0 na configuração do sistema!");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
                finally
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void ActivateScreenShot()
        {
            Log.Info("Iniciando capturas da tela do computador atual...");

            System.Threading.Thread thread = new System.Threading.Thread(DoTirarFoto);

            thread.Start();
                
        }


        #endregion

    }
}
