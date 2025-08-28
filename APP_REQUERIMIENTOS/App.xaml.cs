using APP_REQUERIMIENTOS.MVVM.Vistas;

namespace APP_REQUERIMIENTOS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }
    }
}
