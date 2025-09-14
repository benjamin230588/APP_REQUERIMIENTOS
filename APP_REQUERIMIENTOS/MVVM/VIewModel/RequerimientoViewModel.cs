using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
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
        private List<Requerimiento> _listarequerimiento;
      


        public RequerimientoViewModel()
        {
            listarequerimiento = null;
           
        }
       
       
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        public  List<Requerimiento> listarequerimiento
        {
            get { return _listarequerimiento; }
            set { SetValue(ref _listarequerimiento, value); }
        }
        public async Task InigresarLogin()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {
               
                flgindicador = false;
            }
            catch (Exception ex)
            {
                flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }

        }
      


        public ICommand IngresarComand => new Command(async () => await InigresarLogin());

      }


    
}
