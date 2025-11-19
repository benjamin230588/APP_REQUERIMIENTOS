using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.VIewModel;
using Newtonsoft.Json;
using System.Text;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormCategoriaView : ContentPage
{
    byte[] objetoimagen;
    string extension;
    public FormCategoriaView(CategoriaDTO model, string titulo)
	{
		InitializeComponent();
        BindingContext = new FormCategoriaViewModel(Navigation, model, titulo);
    }

    private async void tabPreviewImage_Tapped(object sender, TappedEventArgs e)
    {
       

        var result = await MediaPicker.Default.PickPhotoAsync();
        try {

            if (result != null)
            {


                using (var stream = await result.OpenReadAsync())
                {
                    // Copiamos la imagen a un MemoryStream, este SÍ quedará vivo
                    var memory = new MemoryStream();
                    await stream.CopyToAsync(memory);

                    // Reiniciar posición para que MAUI pueda leerlo
                    memory.Position = 0;
                    objetoimagen= memory.ToArray();
                    // Asignamos imagen desde memory (NO se cierra)
                    imgPreview.Source = ImageSource.FromStream(() => memory);
                }
                extension = Path.GetExtension(result.FileName);
            }
        }
        catch (Exception ex) { 


        }

      
    }

    private async void btnRegistrarUsuario_Clicked(object sender, EventArgs e)
    {
        using var client = new HttpClient();
        using var content = new MultipartFormDataContent();

        // Agregar JSON
        string json = JsonConvert.SerializeObject(new CategoriaDTO { Nombre="name", Descripcion="dato", FecCreacion = DateTime.Now ,UsuCreacion=1});
        content.Add(new StringContent(json, Encoding.UTF8, "application/json"), "objetojson");

        //content.Add(new StringContent("dale"), "Nombre");
        //content.Add(new StringContent("delia"), "Descripcion");
        //content.Add(new StringContent("1"), "UsuCreacion");
        //content.Add(new StringContent("2025-01-12"), "FecCreacion");

        // Agregar imagen
        content.Add(new ByteArrayContent(objetoimagen), "fotobit", $"cliente{extension}");

        // Enviar al API
        try
        {
            // Si estás usando Android emulador: reemplaza localhost con 10.0.2.2
            var url = "https://fibrasurperu-001-site4.etempurl.com/api/categoria/grabar";
            var response = await client.PostAsync(url, content);
            string resultado = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Respuesta API: {resultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar: {ex.Message}");
        }

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    
}