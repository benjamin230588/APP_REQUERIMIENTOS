using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.Modelo
{
    public class ProductoDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }



        public string Nombre { get; set; }


        public string? Descripcion { get; set; }
        public int Idcategoria { get; set; }

        private int _cantidad;


        public string Nombrecategoria { get; set; }

        public decimal Precio { get; set; }
        public string? NombreArchivo { get; set; }



        public string? NombreArchivoUpdate { get; set; }
        public int UsuCreacion { get; set; }

        public int? UsuModificacion { get; set; }


        public DateTime FecCreacion { get; set; }

        public DateTime? FecActualizacion { get; set; }

        public string rutaarchivo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int Cantidad
        {
            get => Cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    
                    OnPropertyChanged(nameof(Cantidad));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
