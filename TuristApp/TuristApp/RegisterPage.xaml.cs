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
    public partial class RegisterPage : ContentPage
    {
        DatabaseHelper database;

        public RegisterPage()
        {
            InitializeComponent();
            database = new DatabaseHelper(App.DBPath);
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string nombreUsuario = UsernameEntry.Text;
            string contraseña = PasswordEntry.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                await DisplayAlert("Error", "Por favor, ingrese nombre de usuario y contraseña.", "OK");
            }
            else
            {
                bool usuarioExiste = database.UsuarioExiste(nombreUsuario);

                if (usuarioExiste)
                {
                    await DisplayAlert("Error", "El nombre de usuario ya está en uso. Elija otro.", "OK");
                }
                else
                {
                    // Agregar el nuevo usuario a la base de datos (implementa esta lógica)
                    database.InsertarUsuario(new Usuario { NombreUsuario = nombreUsuario, Contraseña = contraseña });

                    await DisplayAlert("Registro Exitoso", "Su cuenta ha sido registrada.", "OK");

                    // Redirigir a la página de inicio de sesión
                    await Navigation.PushAsync(new LoginPage());
                }
            }
        }
        private async void OnLoginLinkClicked(object sender, EventArgs e)
        {
            // Aquí colocas el código para redirigir a la página de inicio de sesión
            await Navigation.PushAsync(new LoginPage());
        }

    }
}