﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace UniversalUnlockTool.WPF.WindowUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Models.LanguageSystem.Startup();
        }
    }

}
