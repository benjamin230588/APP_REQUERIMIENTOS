using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
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
        private Requerimiento _objrequerimiento;


        public FormRequerimientoViewModel(INavigation navigation, Requerimiento model ,string titulo)
        {
            Navigation = navigation;
            this.titulo = titulo;
            objrequerimiento = model;
            
        }


        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        public Requerimiento objrequerimiento
        {
            get { return _objrequerimiento; }
            set { SetValue(ref _objrequerimiento, value); }
        }
        public async Task GuardarRequerimiento()
        {
            
           Respuesta res;
           try
            {
                res = await GenericLH.Post<Requerimiento>(Constantes.url + Constantes.api_getgrabarequerimiento, objrequerimiento);
                if (res.codigo == 1)
                {
                    //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                    await RequerimientoViewModel.GetInstance().MostrarLista();
                    await App.Navigate.PopAsync();

                }
            }
            catch (Exception ex)
            {
               

            }

        }
        public ICommand GuardarRequerimientoComand => new Command(async () => await GuardarRequerimiento());

    }
}
