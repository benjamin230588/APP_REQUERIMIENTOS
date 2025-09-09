namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class dale : ContentPage
{
    public dale()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var overlay = (Grid)((AbsoluteLayout)this.Content).Children[1];
        overlay.IsVisible = true; // mostrar overlay y bloquear interacción

        await Task.Delay(10000); //simula carga10

        overlay.IsVisible = false; // ocultar overlay y desbloquear
    }

    

    
}