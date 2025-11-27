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
        private ObservableCollection<CategoriaDTO> _listacategoria;
        public static CategoriaViewModel instance;
        public static CategoriaViewModel GetInstance()
        {
            if (instance == null)
            {
                return new CategoriaViewModel(App.Navigate);

            }
            else return instance;
        }

        public PedidoCategoriaViewModel(INavigation navigation)
        {
            //instance = this;
            Navigation = navigation;
            listacategoria = new ObservableCollection<CategoriaDTO>();

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

    }
}
