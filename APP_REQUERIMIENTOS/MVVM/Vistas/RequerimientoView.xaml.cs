using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class RequerimientoView : ContentPage
{
	public RequerimientoView()
	{
		InitializeComponent();
        BindingContext = new RequerimientoViewModel(App.Navigate);
    }
}