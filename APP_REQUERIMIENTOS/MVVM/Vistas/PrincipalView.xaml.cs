using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class PrincipalView : Microsoft.Maui.Controls.TabbedPage
{
	public PrincipalView()
    {
		InitializeComponent();
      
        On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

    }
}