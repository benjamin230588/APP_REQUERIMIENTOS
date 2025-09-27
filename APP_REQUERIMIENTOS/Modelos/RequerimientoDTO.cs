using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.Modelos
{
    public class RequerimientoDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Detalle { get; set; }
        public DateTime? FechaProgramada { get; set; }
        public int Estado { get; set; }
        public string NommbreEstado { get; set; }
        public string Observacion1 { get; set; }

        public string NombreCliente { get; set; }
        public string CodigoCliente { get; set; }
    }

    public class ResulLista<T>
    {
        public int cantidadregistro { get; set; }
        public ObservableCollection<T> lista { get; set; }
    }
    public class Paginacion
    {
        public int pagine { get; set; }

        public int skip { get; set; }
    }
}
