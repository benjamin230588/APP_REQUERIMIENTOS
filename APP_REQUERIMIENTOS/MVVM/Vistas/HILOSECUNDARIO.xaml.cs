using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class HILOSECUNDARIO : ContentPage
{
	public HILOSECUNDARIO()
	{
		InitializeComponent();
        BindingContext = new HiloSecunadario();
    }
}