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
}