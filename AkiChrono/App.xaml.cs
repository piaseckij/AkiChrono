using System.Windows;
using AkiChrono.Model;
using AkiChrono.Utils;
using AkiChrono.Vievmodel;
using SQLitePCL;

namespace AkiChrono;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var dbContext = new ChronoDbContext();
        var dbSeeder = new DbSeeder(dbContext);

        MainWindow = new MainWindow
        {
            DataContext = new UserWindowViewmodel(dbContext)
        };

        MainWindow.Show();
    }
}