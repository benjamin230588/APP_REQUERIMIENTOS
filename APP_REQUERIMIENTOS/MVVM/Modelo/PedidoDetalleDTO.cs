using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.Modelo
{
    public class PedidoDetalleDTO
    {
            public int Iddetalle { get; set; }
            public int Idpedido { get; set; }

            public int Idproducto { get; set; }
            public string Producto { get; set; }

            public int Cantidad { get; set; }
            public decimal precio { get; set; }

            public decimal SubTotal { get; set; }
        }
    }

