using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TouristSitesPage : ContentPage
    {
        public TouristSitesPage()
        {
            InitializeComponent();

            // Crear una lista de sitios turísticos
            var touristSites = new List<SitioTuristico>
        {
            new SitioTuristico
            {
                Nombre = "Monasterio de Santa Catalina",
                Descripcion = "El Monasterio de Santa Catalina de Siena, o Convento de Santa Catalina, es un complejo turístico religioso ubicado en el centro histórico de Arequipa, departamento de Arequipa, Perú.",
                Alojamiento = "Le Foyer Arequipa",
                Transporte = "Recojo desde su Hotel en el centro de Arequipa",
                Tours = "Tour por el Monasterio de Santa Catalina"
            },
            // Agregar más sitios turísticos aquí
        };

            // Asignar la lista al ListView
            SitesListView.ItemsSource = touristSites;
        }

        // Manejar la selección de un sitio turístico
        private async void OnSiteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedSite = e.SelectedItem as SitioTuristico;

            // Crear una instancia de DetallesSitioTuristico y pasar los detalles
            var detallesSitio = new SitioTuristico
            {
                Nombre = selectedSite.Nombre,
                Descripcion = selectedSite.Descripcion,
                Alojamiento = selectedSite.Alojamiento,
                Transporte = selectedSite.Transporte,
                Tours = selectedSite.Tours
            };

            // Navegar a la página de detalles y pasar los detalles como parámetros
            await Navigation.PushAsync(new SiteDetailsPage(detallesSitio));

            // Desmarcar el elemento seleccionado
            SitesListView.SelectedItem = null;
        }

    }
}