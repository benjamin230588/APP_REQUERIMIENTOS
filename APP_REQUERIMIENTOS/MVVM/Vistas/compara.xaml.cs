using static APP_REQUERIMIENTOS.MVVM.Vistas.compara;
using System.Collections.ObjectModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class compara : ContentPage
{
    public ObservableCollection<Canal> Canales { get; set; }

    public compara()
	{
		InitializeComponent();
        Canales = new ObservableCollection<Canal>
            {
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "gata.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "gata.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "lola111.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "candotnet_botal4.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "dotnet_bot.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "lola111.png" },

                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "gata.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "gata.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "lola111.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "candotnet_botal4.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "dotnet_bot.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "lola111.png" },

                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "gata.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "gata.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "lola111.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "candotnet_botal4.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "dotnet_bot.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "lola111.png" },

                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "gata.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "gata.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "gata.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "lola111.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "candotnet_botal4.png" },
                new Canal { Id = 1, Nombre = "Comercial", Descripcion = "Canal principal de ventas", Imagen = "lola111.png" },
                new Canal { Id = 2, Nombre = "Soporte", Descripcion = "Atención al cliente y soporte", Imagen = "dotnet_bot.png" },
                new Canal { Id = 3, Nombre = "Marketing", Descripcion = "Promociones y campañas", Imagen = "dotnet_bot.png" },
                new Canal { Id = 4, Nombre = "Distribución", Descripcion = "Logística y entregas", Imagen = "lola111.png" },

            };

        // Asignar ItemsSource
        cvCanales.ItemsSource = Canales;
    }
    public class Canal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        // Ruta de imagen local o URL
        public string Imagen { get; set; }
    }
}