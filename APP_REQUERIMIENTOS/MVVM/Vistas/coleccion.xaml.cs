using APP_REQUERIMIENTOS.Modelos;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class coleccion : ContentPage
{
    public List<Pruebas> lista { get; set; }

    public coleccion()
	{
		InitializeComponent();
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
        BindingContext = this;

    }
}