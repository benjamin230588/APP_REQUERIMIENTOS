using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using Microsoft.Maui.Storage;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class MenuView : ContentPage
{
    public List<Menu> listamenu { get; set; }
    public string Activeusuario { get; set; }
    public MenuView()
	{
		InitializeComponent();
        string nomusuario = Preferences.Get(Constantes.nomusuario, ""); ;
        listamenu = new List<Menu>();
        Activeusuario = nomusuario;
        
        BindingContext = this;
        listarMenu();

    }
    private void listarMenu()
    {
        int idtipousuario = Preferences.Get(Constantes.IdTipoUsuario, 0);
        if (idtipousuario == 1)
        {
            listamenu.Add(new Menu { nombreicono = "gata", nombreitem = "Agenda" });
            listamenu.Add(new Menu { nombreicono = "dotnet_bot", nombreitem = "Pedidos" });
            listamenu.Add(new Menu { nombreicono = "lola111", nombreitem = "Ventas" });
            listamenu.Add(new Menu { nombreicono = "lola111", nombreitem = "Clientes" });
            listamenu.Add(new Menu { nombreicono = "ic_cerrar", nombreitem = "Salir" });

        }
        else
        {

            listamenu.Add(new Menu { nombreicono = "gata", nombreitem = "Agenda" });
            listamenu.Add(new Menu { nombreicono = "dotnet_bot", nombreitem = "Pedidos" });
            listamenu.Add(new Menu { nombreicono = "lola111", nombreitem = "Ventas" });
            listamenu.Add(new Menu { nombreicono = "lola111", nombreitem = "Clientes" });
            listamenu.Add(new Menu { nombreicono = "ic_cerrar", nombreitem = "Salir" });
        }

    }

    private void lstMenu_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Menu omenuCLS = (Menu)e.Item;
        switch (omenuCLS.nombreitem)
        {
            case "Agenda":
                App.Navigate.PushAsync(new dale()); break;
            case "Pedidos":
                App.Navigate.PushAsync(new HILOSECUNDARIO()); break;
            case "Ventas":
                App.Navigate.PushAsync(new RequerimientoView()); break;
            case "Clientes":
                App.Navigate.PushAsync(new coleccion()); break;
            case "Salir":
                App.Current.MainPage = new NavigationPage(new LoginView());
                //Setings.RecordarContra = false;
                Preferences.Set(Constantes.RecordarContra, false);

                break;
        }
        App.MenuApp.IsPresented = false;
    }
}