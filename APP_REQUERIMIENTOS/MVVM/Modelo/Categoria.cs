using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.Modelo
{
    public class CategoriaDTO
    {
        public int Id { get; set; }


        public string Nombre { get; set; }


        public string Descripcion { get; set; }


        public string NombreArchivo { get; set; }



        public string NombreArchivoUpdate { get; set; }
        public int UsuCreacion { get; set; }

        public int? UsuModificacion { get; set; }


        public DateTime FecCreacion { get; set; }

        public DateTime? FecActualizacion { get; set; }

        public string rutaarchivo { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
