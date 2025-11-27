using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.VIewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormPedidoView : ContentPage
{
   // public List<PedidoDetalle> Items { get; set; }
    public FormPedidoViewModel vm { get; set; }
    public FormPedidoView()
    {
        InitializeComponent();
        vm = new FormPedidoViewModel(Navigation);
        BindingContext = vm;
        //Items = JsonConvert.DeserializeObject<List<PedidoDetalle>>(Preferences.Get(Constantes.detallepedido, ""));

        //BindingContext = this;
        //Items = new ObservableCollection<ItemVentaDetalle>()
        //{
        //    new ItemVentaDetalle { Id = 1, Producto = "Coca Cola 500ml", Precio = 3.50m, Cantidad = 2 },
        //    new ItemVentaDetalle { Id = 2, Producto = "Hamburguesa", Precio = 12.00m, Cantidad = 1 },
        //    new ItemVentaDetalle { Id = 3, Producto = "Papas Fritas", Precio = 5.00m, Cantidad = 1 }
        //};
        //BindingContext = this;
    }



    private void btnVolverLogin_Clicked(object sender, EventArgs e)
    {


    }

   
}
