using APP_REQUERIMIENTOS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class FormRequerimientoViewModel : BaseViewModel
    {
        private string _titulo;
       


        public FormRequerimientoViewModel(INavigation navigation, string titulo)
        {
            Navigation = navigation;
            this.titulo = titulo;
            
        }


        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }

    }
}
