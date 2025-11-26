using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormPedidoView : ContentPage
{
    public List<PedidoDetalle> Items { get; set; }
    public FormPedidoView()
    {
        InitializeComponent();

        Items = JsonConvert.DeserializeObject<List<PedidoDetalle>>(Preferences.Get(Constantes.detallepedido, ""));

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

    private async void btnRegistrardddUsuario_Clicked(object sender, EventArgs e)
    {
        Respuesta res;
        PedidoCabecera objetoventa = new PedidoCabecera();
        var fecha = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        objetoventa.fecha = fecha;
        objetoventa.Cliente = "JOSUE";
        objetoventa.Idcliente = "0";

        objetoventa.UsuCreacion = 1;
        objetoventa.FecCreacion = fecha;

        objetoventa.lista = Items;



        res = await GenericLH.Post<PedidoCabecera>(Constantes.url + Constantes.api_getgrabarpedido, objetoventa);
        if (res.codigo == 1)
        {
            Preferences.Set(Constantes.detallepedido, "");
          
            var pages = App.Navigate.NavigationStack.ToList();
          //  var pagina23 = pages.FirstOrDefault(x => x.GetType().Name == "");

            for (int i = 0; i <= pages.Count - 1; i++)
            {
                if (i != 0)
                {
                    App.Navigate.RemovePage(pages[i]);

                }


            }

            await App.Navigate.PushAsync(new PedidoCategoriaView());

        }
    }
}
public class PedidoDetalle
    {
    
        public int Iddetalle { get; set; }
        public int Idpedido { get; set; }

        public string Idproducto { get; set; }
        public string Producto { get; set; }

        public int Cantidad { get; set; }
        public int precio { get; set; }

        public int SubTotal { get; set; }
    }

    public class PedidoCabecera
    {
        public int Idventa { get; set; }

        public string Idcliente { get; set; }
        public string Cliente { get; set; }

        public DateTime fecha { get; set; }


        public int UsuCreacion { get; set; }
        public int? UsuModificacion { get; set; }

        public DateTime FecCreacion { get; set; }

        public DateTime? FecActualizacion { get; set; }
        public List<PedidoDetalle> lista { get; set; }

    }
