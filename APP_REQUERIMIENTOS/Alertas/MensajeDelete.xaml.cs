using CommunityToolkit.Maui.Views;

namespace APP_REQUERIMIENTOS.Alertas;

public partial class MensajeDelete : Popup
{
	public MensajeDelete()
	{
		InitializeComponent();
	}
    private void OnOkClickedSI(object sender, EventArgs e)
    {
        // Cierra el popup (puedes devolver resultado si usas Popup<T>)
        Close(true);
    }
    private void OnOkClickedNO(object sender, EventArgs e)
    {
        // Cierra el popup (puedes devolver resultado si usas Popup<T>)
        Close(false);
    }
}