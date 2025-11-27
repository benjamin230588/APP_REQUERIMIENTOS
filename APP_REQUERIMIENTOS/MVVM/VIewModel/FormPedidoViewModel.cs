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
    public class FormPedidoViewModel : BaseViewModel
    {
        private string _titulo;
        private PedidoCabeceraDTO _objpedido;
        private bool _flgindicador;
        public byte[] imgmedia;
        public string extension { get; set; }
        private List<string> _listacategoria;
        //private ObservableCollection<CategoriaDTO> _listacategoriaobjeto;

        public FormPedidoViewModel(INavigation navigation)
        {
            Navigation = navigation;
           // this.titulo = titulo;
            flgindicador = true;
            // listacategoria = cargarCategorias( model);
            // objrequerimiento = (RequerimientoDTO)model.Clone();
            //  objproducto = (ProductoDTO)model.Clone();
            //cargarCategorias();
            //Task.Run(async () => await cargarCategorias(model));


            //cargarCategorias();



        }
        public List<string> listacategoria
        {
            get { return _listacategoria; }
            set { SetValue(ref _listacategoria, value); }

        }

        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
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
        public async Task GuardarProducto()
        {

            Respuesta res;
            try
            {
                flgindicador = true;

                //await Task.Delay(10000);
                // Thread.Sleep(10000);
                if (objpedido.Idventa == 0)
                {
                    objpedido.UsuCreacion = Preferences.Get(Constantes.IdUsuario, 0);

                    var fecha = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                    objpedido.FecCreacion = DateTime.Now;
                  //  objpedido.Descripcion = "pruen";
                   // objproducto.Idcategoria = _listacategoriaobjeto.Where(x => x.Nombre == objproducto.Nombrecategoria).FirstOrDefault().Id;

                    res = await GenericLH.PostFile<PedidoCabeceraDTO>(imgmedia, extension, Constantes.url + Constantes.api_getgrabarproducto, objpedido);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await Application.Current.MainPage.ShowPopupAsync(popup);


                        await App.Navigate.PopAsync();
                        await ProductoViewModel.GetInstance().MostrarLista();
                    }
                }
                else
                {
                    objpedido.UsuModificacion = Preferences.Get(Constantes.IdUsuario, 0);

                    var fecha = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                    objpedido.FecActualizacion = fecha;
                    //objpedido.Idcategoria = _listacategoriaobjeto.Where(x => x.Nombre == objproducto.Nombrecategoria).FirstOrDefault().Id;


                    res = await GenericLH.PostFile<PedidoCabeceraDTO>(imgmedia, extension, Constantes.url + Constantes.api_getmodificarproducto, objpedido);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await Application.Current.MainPage.ShowPopupAsync(popup);

                        await App.Navigate.PopAsync();
                        await ProductoViewModel.GetInstance().MostrarLista();

                    }
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



        public ICommand GuardarRequerimientoComand => new Command(async () => await GuardarProducto());
        public ICommand VolverRequerimientocommand => new Command(async () => await VolverProducto());

        //public ICommand CargarImagenocommand => new Command(async () => await CargarImagen());



    }

}

   
