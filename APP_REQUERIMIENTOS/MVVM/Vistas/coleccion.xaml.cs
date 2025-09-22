using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.VIewModel;
using CommunityToolkit.Maui.Core.Views;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class coleccion : ContentPage
{
    // public List<Pruebas> lista { get; set; }
    //public static Averias instance;
    public coleccion()
	{
		InitializeComponent();
        BindingContext = new RequerimientoViewModel(App.Navigate);
    }

    private void lstCategoria12_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await App.Navigate.PushAsync(new FormRequerimientoView(new RequerimientoDTO(), "Nuevo Averia"));

    }
}