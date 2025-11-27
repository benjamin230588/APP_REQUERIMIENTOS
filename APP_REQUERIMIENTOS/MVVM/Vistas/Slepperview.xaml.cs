using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class Slepperview : ContentPage
{
	public Slepperview()
	{
		InitializeComponent();
        BindingContext = new ProductoViewModel23();
    }
}

public class ProductoViewModel23 : INotifyPropertyChanged
{
    private int _cantidad;

    public int Cantidad
    {
        get => _cantidad;
        set
        {
            if (_cantidad != value)
            {
                _cantidad = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
