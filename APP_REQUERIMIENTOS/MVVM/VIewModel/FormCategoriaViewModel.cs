using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class FormCategoriaViewModel : BaseViewModel
    {
        private string _titulo;
        private CategoriaDTO _objcategoria;
        private bool _flgindicador;

        public FormCategoriaViewModel(INavigation navigation, CategoriaDTO model, string titulo)
        {
            Navigation = navigation;
            this.titulo = titulo;
            // objrequerimiento = (RequerimientoDTO)model.Clone();
            objcategoria = (CategoriaDTO)model.Clone();


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

        public async Task GuardarRequerimiento()
        {

            Respuesta res;
            try
            {
                flgindicador = true;
                //await Task.Delay(10000);
                // Thread.Sleep(10000);
                if (objcategoria.Id == 0)
                {
                    res = await GenericLH.Post<CategoriaDTO>(Constantes.url + Constantes.api_getgrabarequerimiento, objcategoria);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await Application.Current.MainPage.ShowPopupAsync(popup);

                        await RequerimientoViewModel.GetInstance().MostrarLista();
                        await App.Navigate.PopAsync();

                    }
                }
                else
                {
                    res = await GenericLH.Put<CategoriaDTO>(Constantes.url + Constantes.api_getmodificarequerimiento, objcategoria);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await Application.Current.MainPage.ShowPopupAsync(popup);
                        await RequerimientoViewModel.GetInstance().MostrarLista();
                        await App.Navigate.PopAsync();

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

        public ICommand GuardarRequerimientoComand => new Command(async () => await GuardarRequerimiento());
        public ICommand VolverRequerimientocommand => new Command(async () => await VolverRequerimiento());

    }
}

