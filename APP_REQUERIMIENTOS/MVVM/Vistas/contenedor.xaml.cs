using System.Collections.ObjectModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class contenedor : ContentPage
{
    public ObservableCollection<Categoria111> Categorias { get; set; }

    public contenedor()
    {
        InitializeComponent();
        Categorias = new ObservableCollection<Categoria111>();
        CargarCategorias();
        BindingContext = this;
    }


    private void CargarCategorias()
    {
        Categorias.Add(new Categoria111
        {
            IdCategoria = 1,
            Nombre = "Verdura",
            Imagen = "productos.png"
        });

        Categorias.Add(new Categoria111
        {
            IdCategoria = 2,
            Nombre = "Útiles Escolares",
            Imagen = "categoria.png"
        });

        Categorias.Add(new Categoria111
        {
            IdCategoria = 3,
            Nombre = "Galleta",
            Imagen = "gata.png"
        });

        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
        Categorias.Add(new Categoria111
        {
            IdCategoria = 4,
            Nombre = "Computadora",
            Imagen = "cliente.png"
        });
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       // DisplayAlert("sss", "s", "ss");
    }
}
public class Categoria111
    {
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int IdCategoria { get; set; }
    }

