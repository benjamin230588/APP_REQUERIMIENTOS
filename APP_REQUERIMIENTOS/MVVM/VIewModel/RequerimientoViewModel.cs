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
        private bool _flgrefresh;
        private List<RequerimientoDTO> _listarequerimiento;
        public static RequerimientoViewModel instance;
        public static RequerimientoViewModel GetInstance()
        {
            if (instance == null)
            {
                return new RequerimientoViewModel(App.Navigate);

            }
            else return instance;
        }

        public RequerimientoViewModel(INavigation navigation)
        {
            instance = this;
            Navigation = navigation;
            MostrarLista();
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
                flgindicador = true;
                res = await GenericLH.GetAll(Constantes.url + Constantes.api_getlistarequerimiento);
                if (res.codigo == 1)
                {
                    objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));

                }
                listarequerimiento = objres;
                flgindicador = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");
            }


        }
        public async Task MostrarListaRefrsh()
        {
            Respuesta res;
            try
            {
                List<RequerimientoDTO> objres = new List<RequerimientoDTO>();
                flgrefresh = true;
                res = await GenericLH.GetAll(Constantes.url + Constantes.api_getlistarequerimiento);
                if (res.codigo == 1)
                {
                    objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));

                }
                listarequerimiento = objres;
                flgrefresh = false;
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

              
                   
                    await App.Navigate.PushAsync(new FormRequerimientoView(new RequerimientoDTO(), "Nuevo Requerimiento"));
                    
                



            }
            catch (Exception ex)
            {
                //flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }


        public async Task IrRequerimiento(RequerimientoDTO objeto)
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {



                await App.Navigate.PushAsync(new FormRequerimientoView(objeto, "Edicion Requerimiento"));


            }
            catch (Exception ex)
            {
                flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }

        public async Task EliminarRequerimiento(int idreq)
        {

            Respuesta res;
            try
            {
        // flgindicador = true;
        //await Task.Delay(10000);
        // Thread.Sleep(10000);
                bool respuest = await Application.Current.MainPage.DisplayAlert("Confirmacion", "Desea Eliminar?", "Si", "NO");
                if (respuest == true)
                {
                    flgindicador = true;
                    res = await GenericLH.Delete(Constantes.url + Constantes.api_geteliminarrequerimiento + "/" + idreq);
                    if (res.codigo == 1)
                    {
                        //   objres = JsonConvert.DeserializeObject<List<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));
                        await RequerimientoViewModel.GetInstance().MostrarLista();
                        // await App.Navigate.PopAsync();

                    }
                    flgindicador = false;

                }
                   


            }
            catch (Exception ex)
            {


            }

        }
        public ICommand IrRequerimientocommand => new Command<RequerimientoDTO>(async (p) => await IrRequerimiento(p));

        public ICommand CrearRequerimientoComand => new Command(async () => await CrearRequerimiento());
        public ICommand RefreshComand => new Command(async () => await MostrarListaRefrsh());
        public ICommand seleccionadoComand => new Command(async () => await MostrarListaRefrsh());
        public ICommand EliminarComand => new Command<int>(async (id) => await EliminarRequerimiento(id));

    }



}
