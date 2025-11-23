using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class ProductoView : ContentPage
{
	public ProductoView()
	{
		InitializeComponent();
        BindingContext = new ProductoViewModel(App.Navigate);
    }
}