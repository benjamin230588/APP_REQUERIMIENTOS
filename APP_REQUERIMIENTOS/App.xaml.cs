using APP_REQUERIMIENTOS.MVVM.Vistas;

namespace APP_REQUERIMIENTOS
{
    public partial class App : Application
    {
        public static INavigation Navigate { get; internal set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
            //new NavigationPage(new LoginView());
            // MainPage = new LoginView();
            //MainPage = new Pagetabe();
            //new NavigationPage(new Login());
        }
    }
}
