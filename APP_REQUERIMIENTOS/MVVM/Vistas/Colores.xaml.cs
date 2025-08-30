using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class Colores : ContentPage
{
    string hexValue;

    public Colores()
	{
		InitializeComponent();
	}

    private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
    {
	    double red= sldRed.Value;
       
        double green = sldGreen.Value;
        double blue = sldBlue.Value;

        Color color = Color.FromRgb(red, green, blue);

        SetColor(color);
        //DisplayAlert("mmm", red.ToString(), "cc");

    }
    private void SetColor(Color color)
    {
        //Debug.WriteLine(color.ToString());
        //btnRandom.BackgroundColor = color;
        CONTENEDOR.BackgroundColor = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        //var toast = Toast.Make("Color copied",
          //     CommunityToolkit.Maui.Core.ToastDuration.Short,
            //   12);
        //await toast.Show();
    }

    private async void btndale_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SliderPeso());
    }
}