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
        private string _nombreButon;
        private Microsoft.Maui.Graphics.Color _colorfondo;

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
            get => _cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    
                    OnPropertyChanged(nameof(Cantidad));
                }
            }
        }

        public string NombreButon
        {
            get => _nombreButon;
            set
            {
                if (_nombreButon != value)
                {
                    _nombreButon = value;

                    OnPropertyChanged(nameof(NombreButon));
                }
            }
        }

        public Microsoft.Maui.Graphics.Color Colorfondo
        {
            get => _colorfondo;
            set
            {
                if (_colorfondo != value)
                {
                    _colorfondo = value;

                    OnPropertyChanged(nameof(Colorfondo));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
