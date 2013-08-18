using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Library.Core.GUI.WPF.ScreenShotHelper;
using Library.Core.GUI.ViewModelHelpers;

namespace ScreenCaptureTimer.ViewModels
{
    public class MainWindowViewModel
    {





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

        #region Methods

        private void DoTirarFoto()
        {
            ScreenShotHelper sc = new ScreenShotHelper();

            sc.SaveScreenImage();
            
        }

        private Boolean CanTirarFoto
        {
            get { return true; }
        }

        #endregion

    }
}
