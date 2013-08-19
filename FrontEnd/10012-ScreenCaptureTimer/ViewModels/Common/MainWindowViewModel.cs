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
            ScreenShotHelper.GetSingleton().SaveScreenImage();
        }

        private Boolean CanTirarFoto
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureScreenShot()
        {
            timer = Convert.ToInt16(ConfigurationManager.AppSettings["TimerScreenShot"].ToString());

            if (timer == 0)
            {
                Log.Error("Valor configurado não pode ser 0");
                throw new Exception("Valor configurado não pode ser 0");
            }
                

        }


        #endregion

    }
}
