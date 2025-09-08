using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.Modelos
{

    public class Pruebas
    {
        //[JsonIgnore]
        //public string invento { get; set; }

        public int idcliente { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public string codigocliente { get; set; }
        public string nombre { get; set; }
        public string nombresegundo { get; set; }
        public string apellido { get; set; }

    }
}
