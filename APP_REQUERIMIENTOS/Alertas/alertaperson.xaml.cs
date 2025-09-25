using CommunityToolkit.Maui.Views;

namespace APP_REQUERIMIENTOS.Alertas;

public partial class alertaperson : Popup
{
	public alertaperson()
	{
		InitializeComponent();
	}
    private void OnYesClicked(object sender, EventArgs e)
    {
        Close(true); // Devuelve true
    }

    private void OnNoClicked(object sender, EventArgs e)
    {
        Close(false); // Devuelve false
    }
}