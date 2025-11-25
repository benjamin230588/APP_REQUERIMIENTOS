using APP_REQUERIMIENTOS.Helpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class benja : ContentPage
{
    public List<Articulo> Lista { get; set; }
    int contador = 1;
    public benja()
	{
		InitializeComponent();
        Lista = new List<Articulo>()
        {
            new Articulo(){ Nombre="S/50.0 Lomo Saltado de Carne Fino Alfredo", Precio=10 },
            new Articulo(){ Nombre="S/50.0 Crne Saltado de Pollo", Precio=20 },
            new Articulo(){ Nombre="S/50.0 Platano Carne Fino Alfredo", Precio=18 },

            new Articulo(){ Nombre="S/50.0 Arroz Saltado de Carne Fino Alfredo", Precio=10 },
            new Articulo(){ Nombre="S/50.0 Fideo Saltado de Carne Fino Alfredo", Precio=20 },
            new Articulo(){ Nombre="S/50.0 Guiso Saltado Fino Alfredo", Precio=18 },

            new Articulo(){ Nombre="S/50.0 Chifa Saltado de Carne Fino Alfredo", Precio=10 },
            new Articulo(){ Nombre="S/50.0 Sopa Saltado de Carne Fino Alfredo", Precio=20 },
            new Articulo(){ Nombre="S/50.0 Lomo Saltado de Carne Fino Alfredo", Precio=18 },

             new Articulo(){ Nombre="LSS 65", Precio=10 },
            new Articulo(){ Nombre="MAQ 100", Precio=20 },
            new Articulo(){ Nombre="LSE 80 I", Precio=18 },

            new Articulo(){ Nombre="LSS 65", Precio=10 },
            new Articulo(){ Nombre="MAQ 100", Precio=20 },
            new Articulo(){ Nombre="LSE 80 I", Precio=18 }
        };

        cvItems.ItemsSource = Lista;
    }
    //private void Accion_Clicked(object sender, EventArgs e)
    //{
    //    var boton = (Button)sender;
    //    var item = (ItemModel)boton.CommandParameter;

    //    item.Cantidad++; // acción simple
       
    //}
   

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        
        //lblcantidad.Text = e.NewValue.ToString();
    }
    public class Articulo : INotifyPropertyChanged
    {
        private int _cantidad;

        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await App.Navigate.PushAsync(new FormPedidoView());

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
       // MenuItem oMenuItem = sender as MenuItem;
        var btn = sender as Button;

        // aquí YA VIENE EL OBJETO COMPLETO DEL ITEM
        var item = btn.CommandParameter as Articulo;

        List<ItemVentaDetalle> listaProd = null;
        if (Preferences.Get(Constantes.detallepedido, "") == "")
        {
            listaProd = new List<ItemVentaDetalle>();
        }
        else
        {
            listaProd = JsonConvert.DeserializeObject<List<ItemVentaDetalle>>(Preferences.Get(Constantes.detallepedido, ""));
        }

        listaProd.Add(new ItemVentaDetalle
        {
            Id = 1,
            Producto = item.Nombre,
            Precio = item.Precio,
            Cantidad = item.Cantidad
        });

        
        Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaProd));

       // DisplayAlert("Item", $"Nombre: {item.Cantidad}", "OK");
    }
}