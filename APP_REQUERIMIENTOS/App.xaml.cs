using APP_REQUERIMIENTOS.MVVM.Vistas;

namespace APP_REQUERIMIENTOS
{
    public partial class App : Application
    {
        public static INavigation Navigate { get; internal set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new HILOSECUNDARIO();
            //new NavigationPage(new LoginView());
            //    {
            //BarTextColor = Colors.White        // Texto + íconos (incluye los 3 puntos)
            //    };

            //new NavigationPage(new LoginView());
             MainPage = new NavigationPage(new LoginView());
            //MainPage = new Pagetabe();
            //new NavigationPage(new Login());
        }
    }
}
