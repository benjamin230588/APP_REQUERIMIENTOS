using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using Microsoft.Maui.Storage;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class MenuView : ContentPage
{
    public List<Menu> listamenu { get; set; }
    public string Activeusuario { get; set; }
    private Grid _ultimoSeleccionado;
    private Grid _lastSelectedGrid = null;
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
            //listamenu.Add(new Menu { nombreicono = "gata", nombreitem = "Agenda Cita" });
            listamenu.Add(new Menu { nombreicono = "realizarpedido", nombreitem = "Realizar Pedido" });
            listamenu.Add(new Menu { nombreicono = "buscarpedidos", nombreitem = "Mis Pedidos" });
            listamenu.Add(new Menu { nombreicono = "categoria", nombreitem = "Categoria" });
            listamenu.Add(new Menu { nombreicono = "productos", nombreitem = "Productos" });
            listamenu.Add(new Menu { nombreicono = "usuarios", nombreitem = "Usuarios" });
            listamenu.Add(new Menu { nombreicono = "notificacion", nombreitem = "Notificaciones" });
            listamenu.Add(new Menu { nombreicono = "cerrar", nombreitem = "Salir" });

        }
        else
        {

            //listamenu.Add(new Menu { nombreicono = "gata", nombreitem = "Agenda" });
            listamenu.Add(new Menu { nombreicono = "dotnet_bot", nombreitem = "Pedidos" });
            listamenu.Add(new Menu { nombreicono = "lola111", nombreitem = "Ventas" });
            listamenu.Add(new Menu { nombreicono = "lola111", nombreitem = "Clientes" });
            listamenu.Add(new Menu { nombreicono = "ic_cerrar", nombreitem = "Salir" });
        }

    }

    //private async void cvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    var selectedItem = (Menu)e.CurrentSelection.FirstOrDefault();
    //    if (selectedItem == null)
    //        return;
    //    switch (selectedItem.nombreitem)
    //    {
    //        case "Requerimiento":
    //            App.Navigate.PushAsync(new RequerimientoView()); break;
    //        case "Realizar Pedido":
    //            App.Navigate.PushAsync(new contenedor()); break;
    //        case "Mis Pedidos":
    //            App.Navigate.PushAsync(new RequerimientoView()); break;
    //        case "Categoria":
    //            App.Navigate.PushAsync(new CategoriaView()); break;
    //        case "Productos":
    //            App.Navigate.PushAsync(new coleccion()); break;
    //        case "Salir":
    //            App.Current.MainPage = new NavigationPage(new LoginView());
    //            //Setings.RecordarContra = false;
    //            Preferences.Set(Constantes.RecordarContra, false);

    //            break;
    //    }
    //    App.MenuApp.IsPresented = false;
    //    await Task.Delay(100);
    //    cvMenu.SelectedItem = null;
    //}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
      //  DisplayAlert("dd","ddd","dd");
        var grid = (Grid)sender;
        if (grid == null) return;

        var item = grid.BindingContext;
        var selectedItem = (Menu)item;
        // VisualStateManager.GoToState(grid, "Selected");



        // Validar que el BindingContext sea del tipo correcto
        // if (grid.BindingContext is not Menu selectedItem) return;

        //if (_lastSelectedGrid != null)
        //{
        //    VisualStateManager.GoToState(_lastSelectedGrid, "Normal");
        //}
        //if (_lastSelectedItem != null && _lastSelectedItem != selectedItem)
        //{
        //    foreach (var child in cvMenu.VisibleCells()) // pseudo-código, ver abajo cómo obtener los grids visibles
        //    {
        //        if (child.BindingContext == _lastSelectedItem)
        //            VisualStateManager.GoToState(child, "Normal");
        //    }
        //}
        //// Marcar el actual
        VisualStateManager.GoToState(grid, "Selected");
        await Task.Delay(200); // 200 ms dura el color
        VisualStateManager.GoToState(grid, "Normal");
      //  _lastSelectedGrid = grid;
        // cvMenu.SelectedItem = item;
        //// await Task.Delay(150);
        //await Task.Delay(3000);
        //cvMenu.SelectedItem = item;
        //await Task.Delay(3000);

        // int index = cvMenu.ItemsSource.Cast<Menu>().ToList().IndexOf(selectedItem);
        //cvMenu.se = index;
        switch (selectedItem.nombreitem)
        {
            case "Requerimiento":
              
                await App.Navigate.PushAsync(new RequerimientoView()); break;
            case "Realizar Pedido":
                
                await App.Navigate.PushAsync(new PedidoCategoriaView()); break;
            case "Mis Pedidos":
                await App.Navigate.PushAsync(new RequerimientoView()); break;
            case "Categoria":
                await App.Navigate.PushAsync(new CategoriaView()); break;
            case "Productos":
                await App.Navigate.PushAsync(new ProductoView()); break;
            case "Salir":
                App.Current.MainPage = new NavigationPage(new LoginView());
                //Setings.RecordarContra = false;
                Preferences.Set(Constantes.RecordarContra, false);

                break;
        }
       // cvMenu.SelectedItem = item;
       App.MenuApp.IsPresented = false;
       
    }
    private void LimpiarSeleccion()
    {
        if (cvMenu == null || cvMenu.ItemsSource == null)
            return;

        foreach (var obj in cvMenu.ItemsSource)
        {
            var cell = cvMenu.FindByName<Grid>("root");
            if (cell != null)
                VisualStateManager.GoToState(cell, "Normal");
        }
    }
    // Forzar selección manual para que el VisualState cambie
    // cvMenu.SelectedItem = item;
    //VisualStateManager.GoToState(grid, "Selected");

    //    // Guardar referencia
    //    _ultimoSeleccionado = grid;


    //private void lstMenu_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    Menu omenuCLS = (Menu)e.Item;
    //    switch (omenuCLS.nombreitem)
    //    {
    //        case "Agenda":
    //            App.Navigate.PushAsync(new dale()); break;
    //        case "Pedidos":
    //            App.Navigate.PushAsync(new HILOSECUNDARIO()); break;
    //        case "Ventas":
    //            App.Navigate.PushAsync(new RequerimientoView()); break;
    //        case "Clientes":
    //            App.Navigate.PushAsync(new coleccion()); break;
    //        case "Salir":
    //            App.Current.MainPage = new NavigationPage(new LoginView());
    //            //Setings.RecordarContra = false;
    //            Preferences.Set(Constantes.RecordarContra, false);

    //            break;
    //    }
    //    App.MenuApp.IsPresented = false;
    //}
}