using System.Windows;
using Library.Core.Util.Logger;
using ScreenCaptureTimer.ViewModels;

namespace ScreenCaptureTimer
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Log.Info("Iniciando aplicação...");

            this.DataContext = new MainWindowViewModel();

            InitializeComponent();
        }
    }
}
