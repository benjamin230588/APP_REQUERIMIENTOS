using APP_REQUERIMIENTOS.Modelos;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class SinPatron : ContentPage
{
    public List<Pruebas> lista { get; set; }
    public SinPatron()
	{
		InitializeComponent();
		//var lista = new List<Pruebas>();
         lista = new List<Pruebas>();
         lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });
        lista.Add(new Pruebas() { apellido = "dd", nombre = "cc", nombresegundo = "sedee" });

        lista.Add(new Pruebas() { apellido = "CONTEXTO", nombre = "huaman", nombresegundo = "jota" });
        lstCategoria12.BindingContext = lista;

        // lstCategoria12.ItemsSource = lista;
        //BindingContext = this;

    }
}