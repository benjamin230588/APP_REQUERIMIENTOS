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
}