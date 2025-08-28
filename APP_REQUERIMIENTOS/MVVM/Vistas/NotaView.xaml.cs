using APP_REQUERIMIENTOS.MVVM.VIewModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class NotaView : ContentPage
{
	public NotaView()
	{
		InitializeComponent();
		BindingContext = new NotasViewModel();
	}

    private  void btnabre_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new otro();
         //await Navigation.PushAsync(new otro());
    }
}