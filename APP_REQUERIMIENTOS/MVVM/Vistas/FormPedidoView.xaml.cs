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

       
    }

    private void btnRegistrardddUsuario_Clicked(object sender, EventArgs e)
    {
        Respuesta res;
        res = await GenericLH.Post<RequerimientoDTO>(Constantes.url + Constantes.api_getgrabarequerimiento, objrequerimiento);
        if (res.codigo == 1)
        {
        }
}
public class ItemVentaDetalle
{
    public int Id { get; set; }
    public string Producto { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal => Precio * Cantidad;


        public int Iddetalle { get; set; }
        public int Idpedido { get; set; }

        public string Idproducto { get; set; }
        public string Producto { get; set; }

        public int Cantidad { get; set; }
        public int precio { get; set; }

        public int SubTotal { get; set; }
    }
