using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        DatabaseHelper database;

        public LoginPage()
        {
            InitializeComponent();
            database = new DatabaseHelper(App.DBPath);
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string nombreUsuario = UsernameEntry.Text;
            string contraseña = PasswordEntry.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                await DisplayAlert("Error", "Por favor, ingrese nombre de usuario y contraseña.", "OK");
            }
            else
            {
                bool isValid = database.LoginUsuario(nombreUsuario, contraseña);

                if (isValid)
                {
                    // Iniciar sesión exitosamente
                    await Navigation.PushAsync(new TouristSitesPage());
                }
                else
                {
                    await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos.", "OK");
                }
            }
        }
        async void OnRegisterLinkClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}