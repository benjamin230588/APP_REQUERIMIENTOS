using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.Modelos;
using APP_REQUERIMIENTOS.MVVM.Vistas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Graphics;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class LoginviewModel : BaseViewModel
    {
        private string _usuario;
        private string _pasword;
        private bool _flgindicador;
        private bool _estadocolor;
        private Microsoft.Maui.Graphics.Color _colorprimario;

        
            
        public LoginviewModel()
        {
            colorprimario = Microsoft.Maui.Graphics.Color.FromArgb("#27F52E");
            estadocolor = true;
        }
        public Microsoft.Maui.Graphics.Color colorprimario
        {
            get { return _colorprimario; }
            set { SetValue(ref _colorprimario, value); }
        }
        public string usuario
        {
            get { return _usuario; }
            set { SetValue(ref _usuario, value); }
        }
        public string pasword
        {
            get { return _pasword; }
            set { SetValue(ref _pasword, value); }
        }
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        public bool estadocolor
        {
            get { return _estadocolor; }
            set { SetValue(ref _estadocolor, value); }
        }
        public async Task mensaje()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            Respuesta res;
            LoginReq model = new LoginReq();
            model.username = "admin";
            model.password = "123456";
            flgindicador = true;
         //   await Task.Delay(10000);
            res = await GenericLH.Post<LoginReq>(Constantes.url + Constantes.api_login, model);
            if (res.codigo == 1)
            {
                //await Navigation.PushAsync(new PrincipalView());
                Application.Current.MainPage = new PrincipalView();
            }
            else
            {


                await DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

            }
        }
        public void mensajeaelrta()
        {
            usuario = "delias";
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            colorprimario = estadocolor ? Microsoft.Maui.Graphics.Color.FromArgb("#27F52E") : Microsoft.Maui.Graphics.Color.FromArgb("#274DF5");
        }


        public async Task mensaecambio()
        {
            usuario = "delias";
            await Task.Delay(50);
            // estadocolor = true;
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            colorprimario = estadocolor ? Microsoft.Maui.Graphics.Color.FromArgb("#27F52E") : Microsoft.Maui.Graphics.Color.FromArgb("#274DF5");
        }
        public ICommand MensajeComand => new Command(async () => await mensaje());

        public ICommand SwitchToggledCommand => new Command( () =>  mensajeaelrta());

        public ICommand SwitchToggledCommandcambio => new Command(async () => await mensaecambio());
    }


}
