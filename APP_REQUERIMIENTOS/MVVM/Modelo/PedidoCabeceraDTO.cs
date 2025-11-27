using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.Modelo
{
    public class PedidoCabeceraDTO
    {
        public int Idventa { get; set; }

        public int Idcliente { get; set; }
        public string Cliente { get; set; }

        public DateTime fecha { get; set; }


        public int UsuCreacion { get; set; }
        public int? UsuModificacion { get; set; }

        public DateTime FecCreacion { get; set; }

        public DateTime? FecActualizacion { get; set; }
        public List<PedidoDetalleDTO> lista { get; set; }
    }
}
