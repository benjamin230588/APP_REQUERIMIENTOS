using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormRequerimientoView : ContentPage
{
	public FormRequerimientoView(string titulo)
	{
		InitializeComponent();
        BindingContext = new FormRequerimientoViewModel(Navigation,titulo);

    }
}