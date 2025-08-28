using Microsoft.VisualBasic;
using Newtonsoft.Json;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using System.Reflection;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class LoginView : ContentPage
{
	//public Login objeto { get; set; }
    public LoginView()
	{
		InitializeComponent();
        //objeto = new Login { usuario = "camila", pasword = "TODOO" };
        //BindingContext = objeto;
    }

    private async void btningresar_Clicked(object sender, EventArgs e)
    {
        Respuesta res;
        LoginReq model = new LoginReq();
        model.username = "admin";
        model.password = "123456";

        res = await GenericLH.Post<LoginReq>(Constantes.url + Constantes.api_login, model);
        if (res.codigo == 1)
        {
            await DisplayAlert("Mensaje", "Usuario Logueado", "Cancelar");

        }
        else
        {
            
            
            await DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

        }
        //Application.Current.MainPage = new NotaView();
        //
    }
    /*
private void txtboton_Clicked(object sender, EventArgs e)
{
    string obj = objeto.usuario;
    objeto = new Login { usuario = "LUNA", pasword = "EEE" };
    BindingContext = objeto;
    //objeto.usuario = "DELIA";
    //DisplayAlert("titulo",obj,"cancel");
}
*/
}