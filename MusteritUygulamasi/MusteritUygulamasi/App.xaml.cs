using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MusteritUygulamasi.Model;

namespace MusteritUygulamasi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new MusteriContext());
            facade.EnsureCreated();
           
        }


    }

}
