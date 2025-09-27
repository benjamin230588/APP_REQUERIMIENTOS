using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using CommunityToolkit.Maui.Views;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class FormRequerimientoViewModel : BaseViewModel
    {
        private string _titulo;
        private RequerimientoDTO _objrequerimiento;
        private bool _flgindicador;


        public FormRequerimientoViewModel(INavigation navigation, RequerimientoDTO model ,string titulo)
        {
            Navigation = navigation;
            this.titulo = titulo;
            objrequerimiento = model;
            
        }

        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }
        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        public RequerimientoDTO objrequerimiento
        {
            get { return _objrequerimiento; }
            set { SetValue(ref _objrequerimiento, value); }
        }
        public async Task GuardarRequerimiento(Page page)
        {
            
           Respuesta res;
           try
            {
                flgindicador = true;
                 //await Task.Delay(10000);
               // Thread.Sleep(10000);
                if (objrequerimiento.Id==0)
                {
                    res = await GenericLH.Post<RequerimientoDTO>(Constantes.url + Constantes.api_getgrabarequerimiento, objrequerimiento);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await page.ShowPopupAsync(popup);

                        await RequerimientoViewModel.GetInstance().MostrarLista();
                        await App.Navigate.PopAsync();

                    }
                }
                else
                {
                    res = await GenericLH.Put<RequerimientoDTO>(Constantes.url + Constantes.api_getmodificarequerimiento, objrequerimiento);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        var popup = new MensajeConfirmacion();
                        var result = await page.ShowPopupAsync(popup);
                        await RequerimientoViewModel.GetInstance().MostrarLista();
                        await App.Navigate.PopAsync();

                    }
                }
                flgindicador = false;

            }
            catch (Exception ex)
            {
               

            }

        }
      
        public ICommand GuardarRequerimientoComand => new Command<Page>(async (p) => await GuardarRequerimiento(p));

    }
}
