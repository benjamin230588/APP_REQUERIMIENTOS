using APP_REQUERIMIENTOS.MVVM.Vistas;

namespace APP_REQUERIMIENTOS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new LoginView());
            MainPage = new otro();
            //MainPage = new Pagetabe();
            //new NavigationPage(new Login());
        }
    }
}
