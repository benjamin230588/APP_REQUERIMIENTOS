using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.Vistas;
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
    public  class RequerimientoViewModel : BaseViewModel
    {
        
        private bool _flgindicador;
        private List<RequerimientoDTO> _listarequerimiento;
      


        public RequerimientoViewModel(INavigation navigation)
        {
            Navigation = navigation;
            MostrarLista();
        }
       
       
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        public  List<RequerimientoDTO> listarequerimiento
        {
            get { return _listarequerimiento; }
            set { SetValue(ref _listarequerimiento, value); }
        }
       

        public async Task MostrarLista()
        {
            Respuesta res;
            try
            {


                List<RequerimientoDTO> objres = new List<RequerimientoDTO>();

                res = await GenericLH.GetAll(Constantes.url + Constantes.api_getlistarequerimiento);
                if (res.codigo == 1)
                {
                    objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));

                }
                listarequerimiento = objres;
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");
            }


        }

        public async Task CrearRequerimiento()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {



                await Navigation.PushAsync(new FormRequerimientoView("Nuevo Averia"));


            }
            catch (Exception ex)
            {
                flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }

        public ICommand CrearRequerimientoComand => new Command(async () => await CrearRequerimiento());

      }


    
}
