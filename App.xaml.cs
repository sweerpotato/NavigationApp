using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DebuggerNonUserCode]
        internal static void STAMain()
        {
            App app = new();

            app.InitializeComponent();
            _ = app.Run();
        }

        internal static void Main()
        {
            Thread guiThread = new(STAMain)
            {
                Name = "GUI"
            };

            guiThread.SetApartmentState(ApartmentState.STA);
            guiThread.Start();
        }
    }
}
