using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.VIewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Views;

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

    

    //private async void Button_Clicked(object sender, EventArgs e)
    //{
    //    // await App.Navigate.PushAsync(new FormRequerimientoView(new RequerimientoDTO(), "Nuevo Averia"));
    //    var prueba= Snackbar.Make("delia");
    //    await prueba.Show(); // 
    //                           //DisplayAlert("Error", "Error de Conexion", "Cancelar");
    //}

    //private async void SwipeItem_Invoked(object sender, EventArgs e)
    //{
    //    await DisplayAlert("Error", "Error de Conexion", "Cancelar");
    //}

    //private  async void Button_Clicked_1(object sender, EventArgs e)
    //{
    //    // var prueba = Snackbar.Make("delia");
    //    //await prueba.Show(); // 
    //    //var toast = Toast.Make("Este es un toast");
    //    //await toast.Show(); // ?? muestra el toast
    //    var popup = new alertaperson();
    //    var result = await this.ShowPopupAsync(popup);
        
    //    if (result is bool confirmado && confirmado)
    //    {
    //        await DisplayAlert("Resultado", "Has confirmado con SÍ", "OK");
    //    }
    //    /*
    //    else
    //    {
    //        await DisplayAlert("Resultado", "Has elegido NO", "OK");
    //    }*/
    //}
}