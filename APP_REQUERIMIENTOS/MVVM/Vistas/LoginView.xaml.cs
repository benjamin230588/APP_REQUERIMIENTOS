using Microsoft.VisualBasic;
using Newtonsoft.Json;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using System.Reflection;
using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class LoginView : ContentPage
{
	//public Login objeto { get; set; }
    public LoginView()
	{
		InitializeComponent();

        BindingContext = new LoginviewModel();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void validacontra_Toggled(object sender, ToggledEventArgs e)
    {
        if (validacontra.IsToggled)
        {
           // validacontra.Handler?.UpdateValue(nameof(Switch.ThumbColor));
            var sw = (Switch)sender;
            sw.Handler?.UpdateValue(nameof(Switch.ThumbColor));
            validacontra.ThumbColor = Microsoft.Maui.Graphics.Colors.Red;
            validacontra.OnColor= Microsoft.Maui.Graphics.Colors.Red;
        }
        else
        {
            validacontra.ThumbColor = Microsoft.Maui.Graphics.Colors.White;
        }

    }
}