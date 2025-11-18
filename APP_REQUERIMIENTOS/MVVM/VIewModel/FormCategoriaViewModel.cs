using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class FormCategoriaViewModel : BaseViewModel
    {
        private string _titulo;
        public FormCategoriaViewModel(INavigation navigation, Categoria model, string titulo)
        {
            Navigation = navigation;
            this.titulo = titulo;
           // objrequerimiento = (RequerimientoDTO)model.Clone();


        }
        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }

    }
}
