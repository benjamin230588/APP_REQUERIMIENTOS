using APP_REQUERIMIENTOS.Alertas;
using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.Vistas;
using CommunityToolkit.Maui.Views;
using Microsoft.VisualBasic;
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
    public  class RequerimientoViewModel : BaseViewModel
    {
        
        private bool _flgindicador;
        private bool _flgrefresh;
        private ObservableCollection<RequerimientoDTO> _listarequerimiento;
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
            listarequerimiento = new ObservableCollection<RequerimientoDTO>();
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

        public ObservableCollection<RequerimientoDTO> listarequerimiento
        {
            get { return _listarequerimiento; }
            set { SetValue(ref _listarequerimiento, value); }
        }
       

        public async Task MostrarLista(int skip=0,int tipo=0)
        {
            Respuesta res;
            try
            {
                var objeto = new Paginacion { pagine = 20, skip = skip};
                ResulLista<RequerimientoDTO> objres = new ResulLista<RequerimientoDTO>();

                //List<RequerimientoDTO> objres = new List<RequerimientoDTO>();
                flgindicador = true;
                res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getlistarequerimiento,objeto);
                if (res.codigo == 1)
                {
                    objres = JsonConvert.DeserializeObject<ResulLista<RequerimientoDTO>>(JsonConvert.SerializeObject(res.data));

                }
                // listarequerimiento = objres;
                if (tipo == 0)
                {
                    listarequerimiento.Clear();
                    flgrefresh = false;
                }
                
                for (int i = 0; i < objres.lista.Count; i++)
                {
                    bool valida = listarequerimiento.Where(x => x.Id == objres.lista[i].Id).Any();
                    if (!valida)
                    {
                        listarequerimiento.Add(objres.lista[i]);
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
            await MostrarLista(listarequerimiento.Count,1);

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

        public async Task EliminarRequerimiento(ParametrosNavegacion objeto)
        {

            Respuesta res;
            try
            {
                // flgindicador = true;
                //await Task.Delay(10000);
                // Thread.Sleep(10000);

                var popup = new MensajeConfirmacion();
                var respuest = await objeto.Page.ShowPopupAsync(popup);
               // bool respuest = await Application.Current.MainPage.DisplayAlert("Confirmacion", "Desea Eliminar?", "Si", "NO");
                if (respuest is bool confirmado && confirmado)
                {
                    flgindicador = true;


                    res = await GenericLH.Delete(Constantes.url + Constantes.api_geteliminarrequerimiento + "/" + objeto.Id);
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
        public ICommand RefreshComand => new Command(async () => await MostrarLista());
        public ICommand RefreshIncrementComand => new Command(async () => await MostrarListaRefrsh());

        
        //public ICommand seleccionadoComand => new Command(async () => await MostrarListaRefrsh());
        public ICommand EliminarComand => new Command<ParametrosNavegacion>(async (p) => await EliminarRequerimiento(p));

    }



}
