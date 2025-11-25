using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Vistas;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace APP_REQUERIMIENTOS
{
    public partial class App : Application
    {
        public static INavigation Navigate { get; internal set; }
        public static PrincipalMasterView MenuApp { get; internal set; }
        public App()
        {
            InitializeComponent();

            //   change
            if (Preferences.Get(Constantes.RecordarContra, false) == true)
            {
                Application.Current.MainPage = new PrincipalMasterView();
                Preferences.Set(Constantes.detallepedido, "");
                //MainPage = new NavigationPage(new FormPedidoView());
            }
            else
            {
                MainPage = new NavigationPage(new LoginView());
            }

            //MainPage = new HILOSECUNDARIO();
            //new NavigationPage(new LoginView());
            //    {
            //BarTextColor = Colors.White        // Texto + íconos (incluye los 3 puntos)
            //    };

            //new NavigationPage(new LoginView());
            // MainPage = new NavigationPage(new LoginView());
            //MainPage = new Pagetabe();
            //new NavigationPage(new Login());
        }
    }
}
