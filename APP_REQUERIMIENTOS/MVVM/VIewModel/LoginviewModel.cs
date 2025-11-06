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
        private bool _estadoSwitch;
        private Microsoft.Maui.Graphics.Color _colorSwitch;

        
            
        public LoginviewModel()
        {
            colorSwitch = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");
            estadoSwitch = true;
            usuario = "admin";
            pasword = "123456";
        }

        public Microsoft.Maui.Graphics.Color colorSwitch
        {
            get { return _colorSwitch; }
            set { SetValue(ref _colorSwitch, value); }
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

        public bool estadoSwitch
        {
            get { return _estadoSwitch; }
            set { SetValue(ref _estadoSwitch, value); }
        }
        public async Task InigresarLogin()
        {
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            try
            {
                Respuesta res;
                LoginReq model = new LoginReq();
                model.username = usuario;
                model.password = pasword;
                flgindicador = true;
                res = await GenericLH.Post<LoginReq>(Constantes.url + Constantes.api_login, model);
                if (res.codigo == 1)
                {
                    //await Navigation.PushAsync(new PrincipalView());
                    //Application.Current.MainPage = new PrincipalView();
                    Application.Current.MainPage = new PrincipalMasterView();
                }
                else
                {


                    await DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

                }
                flgindicador = false;
            }
            catch (Exception ex)
            {
                flgindicador = false;
                await DisplayAlert("Error", "Error de Conexion", "Cancelar");
                
            }

        }
        public void changeColorSwitch()
        {
            //usuario = "delias";
            //await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
            colorSwitch = estadoSwitch ? Microsoft.Maui.Graphics.Color.FromArgb("#FF0000") : Microsoft.Maui.Graphics.Color.FromArgb("#FFFFFF");
        }


       
        public ICommand IngresarComand => new Command(async () => await InigresarLogin());

        public ICommand SwitchToggledCommand => new Command( () =>  changeColorSwitch());

        //public ICommand SwitchToggledCommandcambio => new Command(async () => await mensaecambio());
    }


}
