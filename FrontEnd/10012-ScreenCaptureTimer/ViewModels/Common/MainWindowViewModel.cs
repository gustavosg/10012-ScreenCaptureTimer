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
using System.Configuration;
using System.Windows;
using Library.Core.Util;

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
#if !DEBUG

            if (!System.Diagnostics.Buildger.IsAttached)
            {
                VerificarInstancias();

                ConfigureScreenShot();

                ActivateScreenShot();
            }
#endif
        }

        #endregion

        #region Commands

        private RelayCommand capturaTela;
        public RelayCommand CapturaTela
        {
            get
            {
                if (capturaTela == null)
                    capturaTela = new RelayCommand(param => DoCapturarTela(), param => CanCapturarTela);
                return capturaTela;
            }
        }

        #endregion

        #region Métodos

        // --------------------------------------------------------------------------------
        // Commands

        /// <summary>
        /// Captura imagem da tela no momento da chamada
        /// </summary>
        public void DoCapturarTela()
        {
            ScreenShotHelper.GetSingleton().SaveScreenImage();
        }

        private Boolean CanCapturarTela
        {
            get { return true; }
        }

        /// <summary>
        /// Verifica a configuração do timer para capturar a tela
        /// </summary>
        private void ConfigureScreenShot()
        {
            timer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["TimerScreenShot"]);
            //ConfigurationManager.AppSettings["TimerScreenShot"].ToString());

            try
            {
                if (timer == 0)
                {
                    MessageBox.Show("Variável TimerScreenShot não pode ser igual a 0 na configuração do sistema!");
                    throw new Exception("Variável TimerScreenShot não pode ser igual a 0 na configuração do sistema!");
                }
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

        /// <summary>
        /// Processo que realizará a captura da tela
        /// </summary>
        private void ActivateScreenShot()
        {
            System.Threading.Thread thread = new System.Threading.Thread(CapturarTela);

            thread.Start();
        }

        /// <summary>
        /// Captura imagem da tela
        /// </summary>
        private void CapturarTela()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(timer * 1000);

                DoCapturarTela();
            }
        }

        // --------------------------------------------------------------------------------
        // Commands

        private void VerificarInstancias()
        {
            if (SystemUtil.GetSingleton().IsAnotherProcessRunning())
            {
                MessageBox.Show("Já existe outra aplicação executando... Aplicação sendo finalizada.");
                Application.Current.Shutdown();
            }
        }

        #endregion

    }
}
