using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class CategoriaView : ContentPage
{
	public CategoriaView()
	{
		InitializeComponent();
        BindingContext = new CategoriaViewModel(App.Navigate);
    }
}