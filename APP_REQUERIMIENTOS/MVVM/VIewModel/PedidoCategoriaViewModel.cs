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
    public class PedidoCategoriaViewModel : BaseViewModel
    {
        private bool _flgindicador;
        private bool _flgrefresh;
        private decimal _importetotal;
        private ObservableCollection<CategoriaDTO> _listacategoria;
        public static PedidoCategoriaViewModel instance;
        public static PedidoCategoriaViewModel GetInstance()
        {
            if (instance == null)
            {
                return null;

            }
            else return instance;
        }

        public PedidoCategoriaViewModel(INavigation navigation)
        {
            instance = this;
            Navigation = navigation;
            listacategoria = new ObservableCollection<CategoriaDTO>();
            List<PedidoDetalleDTO> listaProd = null;
            listaProd = string.IsNullOrWhiteSpace(Preferences.Get(Constantes.detallepedido, "")) ? new List<PedidoDetalleDTO>() : JsonConvert.DeserializeObject<List<PedidoDetalleDTO>>(Preferences.Get(Constantes.detallepedido, ""));
            importetotal = listaProd.Sum(x => x.SubTotal);
            Task.Run(async () => await MostrarLista());



        }

        public bool flgrefresh
        {
            get { return _flgrefresh; }
            set { SetValue(ref _flgrefresh, value); }
        }
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }
        public decimal importetotal
        {
            get { return _importetotal; }
            set { SetValue(ref _importetotal, value); }
        }
        public ObservableCollection<CategoriaDTO> listacategoria
        {
            get { return _listacategoria; }
            set { SetValue(ref _listacategoria, value); }
        }


        public async Task MostrarLista(int skip = 0, int tipo = 0)
        {
            Respuesta res;
            try
            {
                var objeto = new Paginacion { pagine = 90, skip = skip };
                ResulLista<CategoriaDTO> objres = new ResulLista<CategoriaDTO>();

                //List<RequerimientoDTO> objres = new List<RequerimientoDTO>();
                flgindicador = true;
                res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getlistacategoria, objeto);
                if (res.codigo == 1)
                {
                    objres = JsonConvert.DeserializeObject<ResulLista<CategoriaDTO>>(JsonConvert.SerializeObject(res.data));

                }
                // listarequerimiento = objres;
                if (tipo == 0)
                {
                    listacategoria.Clear();
                    flgrefresh = false;
                }

                for (int i = 0; i < objres.lista.Count; i++)
                {
                    bool valida = listacategoria.Where(x => x.Id == objres.lista[i].Id).Any();
                    if (!valida)
                    {
                        listacategoria.Add(objres.lista[i]);
                    }

                }
                flgindicador = false;
            }
            catch (Exception ex)
            {
                flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");
            }


        }
        public async Task MostrarListaRefrsh()
        {
            await MostrarLista(listacategoria.Count, 1);

        }

        public async Task CrearCategoria()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {

                await App.Navigate.PushAsync(new FormCategoriaView(new CategoriaDTO(), "Nuevo Categoria"));

            }
            catch (Exception ex)
            {
                //flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }


        public async Task IrProductos(int idcategoria)
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {



                await App.Navigate.PushAsync(new PedidoProductoView(idcategoria));


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
                if (listaprodu.Count > 0)
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
        public async Task EliminarCategoria(int id = 0)
        {

            Respuesta res;
            try
            {
                // flgindicador = true;
                //await Task.Delay(10000);
                // Thread.Sleep(10000);
                var popup23 = new MensajeDelete();
                //page.ShowPopupAsync(popup);
                var respuest = await Application.Current.MainPage.ShowPopupAsync(popup23);
                //var popup = new MensajeConfirmacion();
                // var respuest = await objeto.Page.ShowPopupAsync(popup);
                // bool respuest = await Application.Current.MainPage.DisplayAlert("Confirmacion", "Desea Eliminar?", "Si", "NO");
                if (respuest is bool confirmado && confirmado)
                {
                    flgindicador = true;


                    res = await GenericLH.Delete(Constantes.url + Constantes.api_geteliminarcategoria + "/" + id);
                    if (res.codigo == 1)
                    {

                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        await CategoriaViewModel.GetInstance().MostrarLista();
                        // await App.Navigate.PopAsync();

                    }
                    flgindicador = false;

                }



            }
            catch (Exception ex)
            {

                flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }
        public ICommand IrProductoscommand => new Command<int>(async (p) => await IrProductos(p));

        public ICommand CrearCategoriaComand => new Command(async () => await CrearCategoria());
        public ICommand RefreshComand => new Command(async () => await MostrarLista());
        public ICommand RefreshIncrementComand => new Command(async () => await MostrarListaRefrsh());


        //public ICommand seleccionadoComand => new Command(async () => await MostrarListaRefrsh());
        public ICommand EliminarComand => new Command<int>(async (p) => await EliminarCategoria(p));

        public ICommand IraPedidoscommand => new Command(async () => await IRaPedidos());


    }
}
