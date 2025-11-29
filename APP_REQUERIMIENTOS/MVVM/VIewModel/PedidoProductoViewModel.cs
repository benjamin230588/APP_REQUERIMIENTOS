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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class PedidoProductoViewModel : BaseViewModel
    {
        private bool _flgindicador;
        private int _idcategoria;
        private bool _flgrefresh;
        private decimal _importetotal;
        //private int _cantidad;
        public ObservableCollection<ProductoDTO> listaproducto { get; set; }
        public static PedidoProductoViewModel instance;
        public static PedidoProductoViewModel GetInstance()
        {
           

            if (instance == null)
            {
                return null;

            }
            else return instance;
        }

        public PedidoProductoViewModel(INavigation navigation, int idcategoria)
        {
            instance = this;
            flgindicador = true;
            Navigation = navigation;
            _idcategoria = idcategoria;
            listaproducto = new ObservableCollection<ProductoDTO>();
            List<PedidoDetalleDTO> listaProd = null;
            listaProd = string.IsNullOrWhiteSpace(Preferences.Get(Constantes.detallepedido, "") ) ?  new List<PedidoDetalleDTO>() : JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
            importetotal = listaProd.Sum(x => x.SubTotal);

            Task.Run(async () => await cargarProductos());



        }
        public async Task cargarProductos()
        {
            int idcategoria = _idcategoria;
            //int idtipousuario = Preferences.Get(Preferencias.IdTipoUsuario, 0);
            List<PedidoDetalleDTO> listaProd = null;
            listaProd = string.IsNullOrWhiteSpace(Preferences.Get(Constantes.detallepedido, "")) ? new List<PedidoDetalleDTO>() : JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));


            var res = await GenericLH.Get(Constantes.url + Constantes.api_getlistaproductocategoria + idcategoria);
            if (res.codigo == 1)
            {
                var objres = JsonConvert.DeserializeObject<ObservableCollection<ProductoDTO>>(JsonConvert.SerializeObject(res.data));
                listaproducto = objres;
                foreach (var item in listaproducto)
                {
                    if (listaProd.Where(x => x.Idproducto== item.Id).Any())
                    {
                        item.NombreButon = "Eliminar";
                        item.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");
                        item.Cantidad = listaProd.Where(x => x.Idproducto == item.Id).Select(x => x.Cantidad).FirstOrDefault();
                    }
                    else
                    {
                        item.NombreButon = "Agregar";
                        item.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#165ded");
                    }
                        
                }

            }
            
            flgindicador = false;
        }

        public async Task ActualizarProductos()
        {
            int idcategoria = _idcategoria;
            //int idtipousuario = Preferences.Get(Preferencias.IdTipoUsuario, 0);
            List<PedidoDetalleDTO> listaProd = null;
            listaProd = string.IsNullOrWhiteSpace(Preferences.Get(Constantes.detallepedido, "")) ? new List<PedidoDetalleDTO>() : JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));

            foreach (var item in listaproducto)
            {
                if (listaProd.Where(x => x.Idproducto == item.Id).Any())
                {
                    item.NombreButon = "Eliminar";
                    item.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");
                    item.Cantidad = listaProd.Where(x => x.Idproducto == item.Id).Select(x => x.Cantidad).FirstOrDefault();
                }
                else
                {
                    item.NombreButon = "Agregar";
                    item.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#165ded");
                }

            }
            
        }
        public bool flgrefresh
        {
            get { return _flgrefresh; }
            set { SetValue(ref _flgrefresh, value); }
        }
        public decimal importetotal
        {
            get { return _importetotal; }
            set { SetValue(ref _importetotal, value); }
        }
        //public int cantidad
        //{
        //    get { return _cantidad; }
        //    set { SetValue(ref _cantidad, value); }
        //}
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        //public ObservableCollection<ProductoDTO> listaproducto
        //{
        //    get { return _listaproducto; }
        //    set { SetValue(ref _listaproducto, value); }
        //}




        //public async Task CrearCategoria()
        //{
        //    //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
        //    try
        //    {

        //        await App.Navigate.PushAsync(new FormCategoriaView(new CategoriaDTO(), "Nuevo Categoria"));

        //    }
        //    catch (Exception ex)
        //    {
        //        //flgindicador = false;
        //        await DisplayAlert("Error", "Error de Conexion", "Cancelar");

        //    }

        //}

        public async Task SllperComand(ProductoDTO objeto)
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {
                if (objeto == null)
                    return;

                //if (!objeto.InicializadoSlepper)
                //{
                //    objeto.InicializadoSlepper = true;
                //    return; // Ignora la primera ejecución para este ítem
                //}

                string texto = objeto.NombreButon;
                List<PedidoDetalleDTO> listaProd = null;
                if (Preferences.Get(Constantes.detallepedido, "") == "")
                {
                    listaProd = new List<PedidoDetalleDTO>();
                }
                else
                {
                    listaProd = JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
                }
                if (texto == "Eliminar")
                {
                    if (objeto.Cantidad > 0)
                    {
                        foreach (var item in listaProd)
                        {
                            if (item.Idproducto == objeto.Id)
                            {
                                // item.NombreButon = "Eliminar";
                                //item.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");
                                item.Cantidad = objeto.Cantidad;
                                item.SubTotal = objeto.Cantidad * objeto.Precio;
                            }
                        }

                        importetotal = listaProd.Sum(x => x.SubTotal);
                        Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaProd));

                    }
                    else
                    {
                        List<PedidoDetalleDTO> listaNew = listaProd.Where(p => p.Idproducto != objeto.Id).ToList();

                        //Settings.ProductListAdd = JsonConvert.SerializeObject(listaNew);
                        importetotal = listaNew.Sum(x => x.SubTotal);
                        Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaNew));
                        objeto.NombreButon = "Agregar";
                        objeto.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#165ded");
                        //objeto.Cantidad = 0;
                        //quitarlo de la lista y cambiar a agregar 


                    }


                        //Settings.ProductListAdd = JsonConvert.SerializeObject(listaNew);
                        

                }
                


                

            }
            catch (Exception ex)
            {
                //flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }
        public async Task AgregarCommnado(ProductoDTO objeto)
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {

                string texto = objeto.NombreButon;
                List<PedidoDetalleDTO> listaProd = null;
                if (Preferences.Get(Constantes.detallepedido, "") == "")
                {
                    listaProd = new List<PedidoDetalleDTO>();
                }
                else
                {
                    listaProd = JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
                }
                if (texto=="Agregar")
                {
                   
                    //si cantidad es cero no poder agregar
                    if (objeto.Cantidad == 0)
                    {
                        await DisplayAlert("Error", "Ingrese Cantidad", "Cancelar");
                        return;
                    }

                    listaProd.Add(new PedidoDetalleDTO
                    {

                        Producto = objeto.Nombre,
                        Idproducto = objeto.Id,
                        precio = objeto.Precio,
                        Cantidad = objeto.Cantidad,
                        SubTotal = objeto.Precio * objeto.Cantidad

                    });

                    importetotal = listaProd.Sum(x => x.SubTotal);
                    Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaProd));
                    objeto.NombreButon = "Eliminar";
                    objeto.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");


                }
                else
                {

                    
                    List<PedidoDetalleDTO> listaNew = listaProd.Where(p => p.Idproducto != objeto.Id).ToList();
                    
                    //Settings.ProductListAdd = JsonConvert.SerializeObject(listaNew);
                    importetotal = listaNew.Sum(x => x.SubTotal);
                    Preferences.Set(Constantes.detallepedido, JsonConvert.SerializeObject(listaNew));
                    objeto.NombreButon = "Agregar";
                    objeto.Colorfondo = Microsoft.Maui.Graphics.Color.FromArgb("#165ded");
                    objeto.Cantidad = 0;
                }



            }
            catch (Exception ex)
            {
                //flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }

        public async Task IRaPedidos()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {
                var texto = Preferences.Get(Constantes.detallepedido, "");

                ObservableCollection<PedidoDetalleDTO> listaprodu;
                 listaprodu = string.IsNullOrWhiteSpace(texto) ? new ObservableCollection<PedidoDetalleDTO>() : JsonConvert.DeserializeObject<ObservableCollection<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
                if (listaprodu.Count > 0 )
                {
                    await App.Navigate.PushAsync(new FormPedidoView());

                }
                else
                {
                    await DisplayAlert("Error", "No Hay Productos Seleccionados", "Cancelar");

                }


                // await App.Navigate.PushAsync(new FormCategoriaView(objeto, "Edicion Categoria"));


            }
            catch (Exception ex)
            {
                //flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }

        //  public ICommand CrearCategoriaComand => new Command(async () => await CrearCategoria());
        //public ICommand RefreshComand => new Command(async () => await MostrarLista());
        //public ICommand RefreshIncrementComand => new Command(async () => await MostrarListaRefrsh());
        //public ICommand Agregarcommand => new Command<ProductoDTO>(async (p) => await IrCategoria(p));

        public ICommand Sllepercommand => new Command<ProductoDTO>(async (p) => await SllperComand(p));

        public ICommand Agregarcommand => new Command<ProductoDTO>(async (p) => await AgregarCommnado(p));

        public ICommand IraPedidoscommand => new Command(async () => await IRaPedidos());

    }

}
