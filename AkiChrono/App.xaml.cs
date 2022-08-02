using System.Windows;
using AkiChrono.Vievmodel;

namespace AkiChrono;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow
        {
            DataContext = new UserWindowViewmodel()
        };

        MainWindow.Show();
    }
}

