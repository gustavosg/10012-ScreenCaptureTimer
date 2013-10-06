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
using System.Configuration;
using System.Windows;
using Library.Core.GUI.ViewModelHelpers;
using Library.Core.GUI.WPF.ScreenShotHelper;
using Library.Core.Util;
using Library.Core.Util.Logger;

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
            VerificarInstancias();

            ConfigureScreenShot();

            ActivateScreenShot();
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

        private RelayCommand abrirConfiguracoes;
        public RelayCommand Configuracoes
        {
            get
            {
                if (abrirConfiguracoes == null)
                    abrirConfiguracoes = new RelayCommand(param => DoConfiguracoes());
                return abrirConfiguracoes;
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

        public void DoConfiguracoes()
        {
            

        }

        /// <summary>
        /// Verifica a configuração do timer para capturar a tela
        /// </summary>
        private void ConfigureScreenShot()
        {
            timer = Convert.ToInt16(ConfigurationManager.AppSettings["TimerScreenShot"]);

            if (timer != null)

                try
                {
                    if (timer == 0)
                    {
                        MessageBox.Show("Variável TimerScreenShot não pode ser igual a 0 na configuração do sistema!");
                        //throw new Exception("Variável TimerScreenShot não pode ser igual a 0 na configuração do sistema!");
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
        }

        /// <summary>
        /// Processo que realizará a captura da tela
        /// </summary>
        private void ActivateScreenShot()
        {
            try
            {
                System.Threading.Thread thread = new System.Threading.Thread(CapturarTela);

                thread.Start();
            }
            catch (Exception ex)
            {
                Log.Info(ex.Message);
            }
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
            if (SystemUtil.IsAnotherProcessRunning())
            {
                MessageBox.Show("Já existe outra aplicação executando... Aplicação sendo finalizada.");
                Application.Current.Shutdown();
            }
        }

        #endregion

    }
}
