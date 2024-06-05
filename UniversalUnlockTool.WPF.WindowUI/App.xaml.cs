using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace UniversalUnlockTool.WPF.WindowUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow? mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            mainWindow = new MainWindow();
            mainWindow.Show();
            Log("App loaded! ", "AppStartup");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LocalModels.LanguageSystem.Startup();
        }

        public void Log(string message, string invoker)
        {
            if(mainWindow is not null)
            {
                mainWindow.LogTextBox.Text += DateTime.Now.ToString("[yyyy.MM.dd HH:mm]") +
                $" ({invoker}) {message}\n"; ;
            }
        }
    }

}
