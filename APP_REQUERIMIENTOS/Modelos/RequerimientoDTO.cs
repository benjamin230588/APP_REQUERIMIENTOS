using System;
using System.Collections.Generic;
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
}
