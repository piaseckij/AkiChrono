using System.Windows;
using AkiChrono.Model;
using AkiChrono.Services;
using AkiChrono.Utils;
using AkiChrono.Vievmodel;
using Microsoft.EntityFrameworkCore.Internal;

namespace AkiChrono;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var dbContext = new ChronoDbContext();
        _ = new DbSeeder(dbContext);
        var recordService = new DbService(dbContext);

        MainWindow = new MainWindow
        {
            DataContext = new UserWindowViewmodel(dbContext, recordService)
        };

        MainWindow.Show();
    }
}