using APP_REQUERIMIENTOS.ClienteHttp;
using APP_REQUERIMIENTOS.Helpers;
using APP_REQUERIMIENTOS.MVVM.VIewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormPedidoView : ContentPage
{
   // public List<PedidoDetalle> Items { get; set; }
    public FormPedidoViewModel vm { get; set; }
    public FormPedidoView()
    {
        InitializeComponent();
        vm = new FormPedidoViewModel(Navigation);
        BindingContext = vm;
      
    }



   

   
}
