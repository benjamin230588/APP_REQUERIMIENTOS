using APP_REQUERIMIENTOS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class HiloSecunadario : BaseViewModel
    {
        private string _pasword;
        public string pasword
        {
            get { return _pasword; }
            set { SetValue(ref _pasword, value); }
        }
        public HiloSecunadario()
        {
            pasword = "fernanda";
        }

        public async Task InigresarLogin()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {


                Task.Run(() =>
                {

                    pasword = "SOFIA";
                    // Código en HILO SECUNDARIO
                    //  var texto = "Hola desde otro hilo";

                    //textBox1.Text = texto; // ← Esto lanza excepción si se ejecuta realmente en hilo secundario
                });

                
            }
            catch (Exception ex)
            {
               

            }

        }

        public ICommand IngresarComand => new Command(async () => await InigresarLogin());


    }
}
