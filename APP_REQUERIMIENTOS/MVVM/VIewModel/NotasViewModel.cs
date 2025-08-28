using APP_REQUERIMIENTOS.MVVM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class NotasViewModel
    {

        public Notas nota { get; set; }
        public NotasViewModel() {

            nota = new Notas();
            nota.puntuacion = 20;
        }
            
    }
}
