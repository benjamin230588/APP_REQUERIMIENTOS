using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormRequerimientoView : ContentPage
{
	public FormRequerimientoView(Requerimiento model, string titulo)
	{
		InitializeComponent();
        BindingContext = new FormRequerimientoViewModel(Navigation, model, titulo);

    }
}