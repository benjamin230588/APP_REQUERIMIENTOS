using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.Vistas;
using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class FormPedidoViewModel : BaseViewModel
    {
        private string _titulo;
        private PedidoCabeceraDTO _objpedido;
        private bool _flgindicador;
        public byte[] imgmedia;
        private decimal _totalpedido;

        public string extension { get; set; }

        private ObservableCollection<PedidoDetalleDTO> _listaproductos;
        //private ObservableCollection<CategoriaDTO> _listacategoriaobjeto;

        public FormPedidoViewModel(INavigation navigation)
        {
            Navigation = navigation;
           // this.titulo = titulo;
           
            Task.Run(async () => await CargarDatosAsync());

            //listaproductos = JsonConvert.DeserializeObject<ObservableCollection<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
            //totalpedido = listaproductos.Sum(x => x.SubTotal);
            //flgindicador = false;
            // listacategoria = cargarCategorias( model);
            // objrequerimiento = (RequerimientoDTO)model.Clone();
            //  objproducto = (ProductoDTO)model.Clone();
            //cargarCategorias();
            //Task.Run(async () => await cargarCategorias(model));


            //cargarCategorias();



        }
        public async Task CargarDatosAsync()
        {
            //flgindicador = true;
            flgindicador = true;

           // await Task.Delay(5000); // permite que la UI se actualice
            listaproductos = JsonConvert.DeserializeObject<ObservableCollection<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
            totalpedido = listaproductos.Sum(x => x.SubTotal);
            flgindicador = false;
            //listaproductos = JsonConvert.DeserializeObject<ObservableCollection<PedidoDetalleDTO>>(
            //    Preferences.Get(Constantes.detallepedido, "")
            //);

            //totalpedido = listaproductos.Sum(x => x.SubTotal);

            //flgindicador = false;
        }
        public ObservableCollection<PedidoDetalleDTO> listaproductos
        {
            get { return _listaproductos; }
            set { SetValue(ref _listaproductos, value); }

        }

        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        public decimal totalpedido
        {
            get { return _totalpedido; }
            set { SetValue(ref _totalpedido, value); }
        }
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        public PedidoCabeceraDTO objpedido
        {
            get { return _objpedido; }
            set { SetValue(ref _objpedido ,value); }
        }

        //public async Task cargarCategorias()
        //{
        //    //int idtipousuario = Preferences.Get(Preferencias.IdTipoUsuario, 0);
        //    var res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getlistacategoria, new Paginacion { pagine = 30, skip = 0 });
        //    if (res.codigo == 1)
        //    {
        //        var objres = JsonConvert.DeserializeObject<ResulLista<CategoriaDTO>>(JsonConvert.SerializeObject(res.data));
        //        _listacategoriaobjeto = objres.lista;
        //        listacategoria = _listacategoriaobjeto.Select(x => x.Nombre).ToList();
        //        //objproducto = (ProductoDTO)OBJMODEL.Clone();

        //    }

        //}
        public async Task cargarCategorias(ProductoDTO OBJMODEL)
        {
            //int idtipousuario = Preferences.Get(Preferencias.IdTipoUsuario, 0);
            var res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getlistacategoria, new Paginacion { pagine = 30, skip = 0 });
            if (res.codigo == 1)
            {
                var objres = JsonConvert.DeserializeObject<ResulLista<CategoriaDTO>>(JsonConvert.SerializeObject(res.data));
                //_listacategoriaobjeto = objres.lista;
                //listacategoria = _listacategoriaobjeto.Select(x => x.Nombre).ToList();
                objpedido = (PedidoCabeceraDTO)OBJMODEL.Clone();

            }
            flgindicador = false;
        }
        //public List<string> cargarCategorias()
        //{

        //        return new List<string>() { "FRUTAS", "DULCES", "Realizado", "Cerrado" };



        //}

        //public byte[] imgmedia
        //{
        //    get { return _imgmedia; }
        //    set { SetValue(ref _imgmedia, value); }
        //}

        public async Task EliminarDetalle(PedidoDetalleDTO OBJMODEL)
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error de Conexion", "Cancelar");

            //  int idtipousuario = Preferences.Get(Preferencias.IdTipoUsuario, 0);
            //ImageButton img = sender as ImageButton;
            //DetalleVentaCLS oProductoCLS = (DetalleVentaCLS)img.BindingContext;
            //int iidproducto = oProductoCLS.iidproducto;
              List<PedidoDetalleDTO> listaProd = null;
              flgindicador = true;
                //List<DetalleVentaCLS> listaSetting = JsonConvert.DeserializeObject<List<DetalleVentaCLS>>(Settings.ProductListAdd);

              listaProd = JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));

              List<PedidoDetalleDTO> listaNew = listaProd.Where(p => p.Idproducto !=  OBJMODEL.Idproducto).ToList();
                
              totalpedido = listaNew.Sum(x => x.SubTotal);
              Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaNew));

              ObservableCollection<PedidoDetalleDTO> listaObservable =
              new ObservableCollection<PedidoDetalleDTO>(listaNew);
              listaproductos = listaObservable;
              if (PedidoProductoViewModel.GetInstance() != null)
              {
               await PedidoProductoViewModel.GetInstance().cargarProductos();

                PedidoProductoViewModel.GetInstance().importetotal = totalpedido;
              }
                if (PedidoCategoriaViewModel.GetInstance() != null)
                {
                
                    PedidoCategoriaViewModel.GetInstance().importetotal = totalpedido;
                }
            flgindicador = false;


        }
        public async Task GuardarPedido()
        {

            Respuesta res;
            try
            {

                if (listaproductos.Count==0)
                {
                    await DisplayAlert("Error", "Debe de Elegir Productos", "Cancelar");

                    return;
                }

                flgindicador = true;

                
                PedidoCabeceraDTO objetoventa = new PedidoCabeceraDTO();
                var fecha = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                objetoventa.fecha = fecha;
                objetoventa.Cliente = "JOSUE";
                objetoventa.Idcliente = 0;

                objetoventa.UsuCreacion = 1;
                objetoventa.FecCreacion = fecha;

                objetoventa.lista = listaproductos.ToList();



                res = await GenericLH.Post<PedidoCabeceraDTO>(Constantes.url + Constantes.api_getgrabarpedido, objetoventa);
                if (res.codigo == 1)
                {
                    Preferences.Set(Constantes.detallepedido, "");
                    var popup = new MensajeConfirmacion();
                    var result = await Application.Current.MainPage.ShowPopupAsync(popup);


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

                flgindicador = false;

            }
            catch (Exception ex)
            {
                flgindicador = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }
        public async Task VolverProducto()
        {
            await App.Navigate.PopAsync();
        }



        public ICommand GuardarPedidoComand => new Command(async () => await GuardarPedido());
        public ICommand Volvercommand => new Command(async () => await VolverProducto());

        public ICommand Eliminarcommand => new Command<PedidoDetalleDTO>(async (p) => await EliminarDetalle(p));



    }

}

   
