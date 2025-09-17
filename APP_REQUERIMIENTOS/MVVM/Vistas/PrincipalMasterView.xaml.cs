using Microsoft.Maui.Controls;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class PrincipalMasterView : FlyoutPage
{
	public PrincipalMasterView()
    {
		InitializeComponent();
        App.Navigate = Navigacion.Navigation;

    }
}