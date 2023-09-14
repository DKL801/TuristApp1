using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristApp
{
    public partial class App : Application
    {
        public static string DBPath { get; set; }
        public App()
        {
            InitializeComponent();

            DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydb.db3");

            // Resto del código de inicio de la aplicación
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
