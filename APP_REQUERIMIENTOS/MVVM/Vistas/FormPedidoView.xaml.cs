using APP_REQUERIMIENTOS.Helpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormPedidoView : ContentPage
{
    public List<ItemVentaDetalle> Items { get; set; }
    public FormPedidoView()
	{
		InitializeComponent();

        Items = JsonConvert.DeserializeObject<List<ItemVentaDetalle>>(Preferences.Get(Constantes.detallepedido, ""));

        BindingContext = this;
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

        List<ItemVentaDetalle> listaProd = null;
        if (Preferences.Get(Constantes.detallepedido, "") == "")
        {
            listaProd = new List<ItemVentaDetalle>();
        }
        else {
            listaProd = JsonConvert.DeserializeObject<List<ItemVentaDetalle>>(Preferences.Get(Constantes.detallepedido, ""));
        }

        listaProd.Add(new ItemVentaDetalle
        {
            Id = 1,
            Producto = "delia fdf",
            Precio = 123,
            Cantidad = 50
        });

        listaProd.Add(new ItemVentaDetalle
        {
            Id = 1,
            Producto = "Arrroz con pollo",
            Precio = 123,
            Cantidad = 50
        });
        Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaProd));
    }

    private void btnRegistrardddUsuario_Clicked(object sender, EventArgs e)
    {
        
            Items = JsonConvert.DeserializeObject<List<ItemVentaDetalle>>(Preferences.Get(Constantes.detallepedido, ""));
       
           BindingContext = this;
    }
}
public class ItemVentaDetalle
{
    public int Id { get; set; }
    public string Producto { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal => Precio * Cantidad;
}
