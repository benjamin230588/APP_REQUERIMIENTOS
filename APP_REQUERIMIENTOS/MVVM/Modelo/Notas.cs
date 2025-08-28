using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.Modelo
{
   // [AddINotifyPropertyChangedInterface]
    public class Notas
    {
        public float puntuacion { get; set; }

        public string ResultText
        {
            get
            {
                
                if (puntuacion == 0)
                {
                    return "JALADO";
                }
                else if (puntuacion > 0 && puntuacion <= 25)
                {
                    return "MALO";
                }

                else if (puntuacion > 25 && puntuacion <= 70)
                {
                    return "MEDIO";
                }

                else
                {
                    return "EXITO";
                }

            }
        }
    }
}
