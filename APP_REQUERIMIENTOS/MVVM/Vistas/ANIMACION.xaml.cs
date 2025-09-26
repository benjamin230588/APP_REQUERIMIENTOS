using CommunityToolkit.Maui.Alerts;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class ANIMACION : ContentPage
{
	public ANIMACION()
	{
		InitializeComponent();
	}

    private void SKLottieView_AnimationCompleted(object sender, EventArgs e)
    {

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
       // biciAnim.
        //biciAnim.DisplaySnackbar(); // arranca la animación en loop infinito
    }
}