using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
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
    public class PedidoProductoViewModel : BaseViewModel
    {
        private bool _flgindicador;
        private bool _flgrefresh;
        //private int _cantidad;
        private ObservableCollection<ProductoDTO> _listaproducto;
        public static CategoriaViewModel instance;
        public static CategoriaViewModel GetInstance()
        {
            if (instance == null)
            {
                return new CategoriaViewModel(App.Navigate);

            }
            else return instance;
        }

        public PedidoProductoViewModel(INavigation navigation , int idcategoria)
        {
            //instance = this;
            flgindicador = true;
            Navigation = navigation;
            listaproducto = new ObservableCollection<ProductoDTO>();

            Task.Run(async () => await cargarProductos(idcategoria));



        }
        public async Task cargarProductos(int idcategoria)
        {
            //int idtipousuario = Preferences.Get(Preferencias.IdTipoUsuario, 0);
            var res = await GenericLH.Get(Constantes.url + Constantes.api_getlistaproductocategoria + idcategoria);
            if (res.codigo == 1)
            {
                var objres = JsonConvert.DeserializeObject<ObservableCollection<ProductoDTO>>(JsonConvert.SerializeObject(res.data));
                listaproducto = objres;
            }
            flgindicador = false;
        }
        public bool flgrefresh
        {
            get { return _flgrefresh; }
            set { SetValue(ref _flgrefresh, value); }
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

        public ObservableCollection<ProductoDTO> listaproducto
        {
            get { return _listaproducto; }
            set { SetValue(ref _listaproducto, value); }
        }


        public async Task MostrarLista(int skip = 0, int tipo = 0)
        {
            Respuesta res;
            try
            {
                var objeto = new Paginacion { pagine = 90, skip = skip };
                ResulLista<ProductoDTO> objres = new ResulLista<ProductoDTO>();

                //List<RequerimientoDTO> objres = new List<RequerimientoDTO>();
                flgindicador = true;
                res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getlistacategoria, objeto);
                if (res.codigo == 1)
                {
                    objres = JsonConvert.DeserializeObject<ResulLista<ProductoDTO>>(JsonConvert.SerializeObject(res.data));

                }
                // listarequerimiento = objres;
                if (tipo == 0)
                {
                    listaproducto.Clear();
                    flgrefresh = false;
                }

                for (int i = 0; i < objres.lista.Count; i++)
                {
                    bool valida = listaproducto.Where(x => x.Id == objres.lista[i].Id).Any();
                    if (!valida)
                    {
                        listaproducto.Add(objres.lista[i]);
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
            await MostrarLista(listaproducto.Count, 1);

        }

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


       
      
      //  public ICommand CrearCategoriaComand => new Command(async () => await CrearCategoria());
        public ICommand RefreshComand => new Command(async () => await MostrarLista());
        public ICommand RefreshIncrementComand => new Command(async () => await MostrarListaRefrsh());
        public ICommand Agregarcommand => new Command<ProductoDTO>(async (p) => await IrCategoria(p));

        public ICommand Sllepercommand => new Command<ProductoDTO>(async (p) => await IrCategoria(p));

        //public ICommand seleccionadoComand => new Command(async () => await MostrarListaRefrsh());

    }

}
