using APP_REQUERIMIENTOS.MVVM.Modelo;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class Inicio : ContentPage
{
    public Login listamenu { get; set; }
    public Inicio()
	{
		InitializeComponent();
        listamenu = new Login();
        BindingContext = this;
        //listamenu.usuario = "GABY";
        listamenu = new Login { usuario = "LUNA", pasword = "EEE" };
    }

    private  void Button_Clicked(object sender, EventArgs e)
    {
        //string usuario = txtusuario.Text;
      /* private void txtboton_Clicked(object sender, EventArgs e)
        {
            string obj = objeto.usuario;
            objeto = new Login { usuario = "LUNA", pasword = "EEE" };
            BindingContext = objeto;
            //objeto.usuario = "DELIA";
            //DisplayAlert("titulo",obj,"cancel");
        }*/
        //  txtusuario.Text = "ALONDRA";
         //DisplayAlert("titulo", txtusuario.Text, "cancel");
        Application.Current.MainPage = new NavigationPage( new NotaView());
       // await Navigation.PushAsync(new NotaView());
    }

    private  void btndale_Clicked(object sender, EventArgs e)
    {
         listamenu = new Login { usuario = "FIORELLA", pasword = "EEE" };
        //BindingContext = otro;
        //DisplayAlert("titulo", "Mensaje de hoy", "cancel");
        //string cadena = "delia";


    }
}