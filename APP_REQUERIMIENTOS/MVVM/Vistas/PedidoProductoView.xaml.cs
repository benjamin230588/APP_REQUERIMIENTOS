using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class PedidoProductoView : ContentPage
{
	public PedidoProductoView( int idcategoria)
	{
		InitializeComponent();
        BindingContext = new PedidoProductoViewModel(App.Navigate,idcategoria);
    }
}