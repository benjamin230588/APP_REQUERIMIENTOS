using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class PedidoCategoriaView : ContentPage
{
	public PedidoCategoriaView()
	{
		InitializeComponent();
        BindingContext = new PedidoCategoriaViewModel(App.Navigate);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("ddd", "d", "vvv");
    }
}