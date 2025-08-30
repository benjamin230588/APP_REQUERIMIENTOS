
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class Pagetabe : Microsoft.Maui.Controls.TabbedPage
{
	public Pagetabe()
	{
		InitializeComponent();
        On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

    }
}