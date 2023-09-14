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
    public partial class SiteDetailsPage : ContentPage
    {
        public SiteDetailsPage(SitioTuristico detallesSitio)
        {
            InitializeComponent();
            // Usar los detalles recibidos para llenar la interfaz de usuario
            NombreLabel.Text = detallesSitio.Nombre;
            DescripcionLabel.Text = detallesSitio.Descripcion;
            AlojamientoLabel.Text = detallesSitio.Alojamiento;
            TransporteLabel.Text = detallesSitio.Transporte;
            ToursLabel.Text = detallesSitio.Tours;
        }
    }
}