using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class FormCategoriaViewModel : BaseViewModel
    {
        private string _titulo;
        private CategoriaDTO _objcategoria;
        private bool _flgindicador;
        public byte[] imgmedia;
        public string extension { get; set; }


        public FormCategoriaViewModel(INavigation navigation, CategoriaDTO model, string titulo)
        {
            Navigation = navigation;
            this.titulo = titulo;
            flgindicador = true;
            // objrequerimiento = (RequerimientoDTO)model.Clone();
            objcategoria = (CategoriaDTO)model.Clone();

            flgindicador = false;
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
      
        public CategoriaDTO objcategoria
        {
            get { return _objcategoria; }
            set { SetValue(ref _objcategoria, value); }
        }
        //public byte[] imgmedia
        //{
        //    get { return _imgmedia; }
        //    set { SetValue(ref _imgmedia, value); }
        //}
        public async Task GuardarCategoria()
        {

            Respuesta res;
            try
            {
                flgindicador = true;
               
                //await Task.Delay(10000);
                // Thread.Sleep(10000);
                if (objcategoria.Id == 0)
                {
                    objcategoria.UsuCreacion = Preferences.Get(Constantes.IdUsuario, 0);

                    var fecha = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                    objcategoria.FecCreacion = fecha;

                    res = await GenericLH.PostFile<CategoriaDTO>(imgmedia,extension, Constantes.url + Constantes.api_getgrabarcategoria, objcategoria);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await Application.Current.MainPage.ShowPopupAsync(popup);

                       
                        await App.Navigate.PopAsync();
                        await CategoriaViewModel.GetInstance().MostrarLista();
                    }
                }
                else
                {
                    objcategoria.UsuModificacion = Preferences.Get(Constantes.IdUsuario, 0);

                    var fecha = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
                    objcategoria.FecActualizacion = fecha;


                    res = await GenericLH.PostFile<CategoriaDTO>(imgmedia, extension,Constantes.url + Constantes.api_getmodificarcategoria, objcategoria);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await Application.Current.MainPage.ShowPopupAsync(popup);
                        
                        await App.Navigate.PopAsync();
                        await CategoriaViewModel.GetInstance().MostrarLista();


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
        public async Task VolverRequerimiento()
        {
            await App.Navigate.PopAsync();
        }

        

        public ICommand GuardarRequerimientoComand => new Command(async () => await GuardarCategoria());
        public ICommand VolverRequerimientocommand => new Command(async () => await VolverRequerimiento());

        //public ICommand CargarImagenocommand => new Command(async () => await CargarImagen());


        
    }
}

