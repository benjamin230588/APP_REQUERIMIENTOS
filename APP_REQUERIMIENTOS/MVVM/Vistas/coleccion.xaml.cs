using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.VIewModel;

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
  
}