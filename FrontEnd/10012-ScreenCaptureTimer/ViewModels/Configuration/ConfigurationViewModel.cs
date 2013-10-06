using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Library.Core.GUI.ViewModelHelpers;
using System.Windows;

namespace ScreenCaptureTimer.ViewModel.Configuration
{
    public class ConfigurationViewModel : ViewModelBasePageEdit
    {

        #region Fields

        #endregion

        #region Constructor

        public ConfigurationViewModel()
        {
            //InicializaTela();
        }

        #endregion

        #region Properties

        private String configurationSavePath;
        public String ConfigurationSavePath
        {
            get { return configurationSavePath; }
            set
            {
                configurationSavePath = value;
                OnPropertyChanged("ConfigurationSavePath");
            }
        }

        #endregion

        #region Commands

        private RelayCommand gravar;
        public RelayCommand Gravar
        {
            get
            {
                if (gravar == null)
                    gravar = new RelayCommand(param => DoGravar());
                return gravar;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Grava as alterações
        /// </summary>
        private void DoGravar()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            config.AppSettings.Settings["SavePath"].Value = configurationSavePath;

            config.Save();

        }

        private void InicializaTela()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSavePath = config.AppSettings.Settings["SavePath"].Value;
        }

        #endregion

    }
}
