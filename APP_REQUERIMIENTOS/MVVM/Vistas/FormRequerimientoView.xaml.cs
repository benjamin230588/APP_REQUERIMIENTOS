using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormRequerimientoView : ContentPage
{
	public FormRequerimientoView(RequerimientoDTO model, string titulo)
	{
		InitializeComponent();
        BindingContext = new FormRequerimientoViewModel(Navigation, model, titulo);

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}