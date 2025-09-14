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

  
}