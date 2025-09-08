using APP_REQUERIMIENTOS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.MVVM.VIewModel
{
    public class LoginviewModel : BaseViewModel
    {
        private string _usuario;
        private string _pasword;

       
        public string usuario
        {
            get { return _usuario; }
            set { SetValue(ref _usuario, value); }
        }
        public string pasword
        {
            get { return _pasword; }
            set { SetValue(ref _pasword, value); }
        }

    }
}
