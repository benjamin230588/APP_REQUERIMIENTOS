using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.Helpers
{
    public class Constantes
    {

        //public const string url = "http://fibrasurperu-001-site6.mtempurl.com";
        public const string url = "https://fibrasurperu-001-site4.etempurl.com";

        
        //public const string url = "http://192.168.1.92:45470";

        //ttp://localhost:5045/swagger/index.html
       // http://localhost:5045
       // https://localhost:44357/api/cliente/lista
    

        public const string api_login = "/api/login/Ingreso";
        public const string api_getlistarequerimiento = "/api/Requerimiento/Lista";
        public const string api_getlistacategoria = "/api/Categoria/Lista";
        public const string api_getgrabarequerimiento = "/api/Requerimiento/Grabar";
        public const string api_geteliminarrequerimiento = "/api/Requerimiento/delete";
        public const string api_getmodificarequerimiento = "/api/Requerimiento/Modificar";

        public const string api_getaveria = "/Averias/Index";

        public const string IdUsuario = "IdUsuario";
        public const string nomusuario = "nomusuario";
        public const string IdTipoUsuario = "IdTipoUsuario";

        public const string RecordarContra = "RecordarContra";
        public const string idNewToken = "idNewToken";
        public const string idversion = "idversion";

    }
}
