using CommunityToolkit.Maui.Views;

namespace APP_REQUERIMIENTOS.Alertas;

public partial class MensajeDelete : Popup
{
	public MensajeDelete()
	{
		InitializeComponent();
        this.Opened += SuccessPopup_Opened;
    }
    private async void SuccessPopup_Opened(object? sender, EventArgs e)
    {
        // animación de entrada

        await PopupFrame.FadeTo(1, 400, Easing.CubicInOut);
        await PopupFrame.ScaleTo(1, 400, Easing.SpringOut);

        // Mantener visible por 2 segundos
        await Task.Delay(2000);
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