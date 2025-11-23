using APP_REQUERIMIENTOS.MVVM.Modelo;
using APP_REQUERIMIENTOS.MVVM.VIewModel;
using System.Reflection;

namespace APP_REQUERIMIENTOS.MVVM.Vistas;

public partial class FormProductoView : ContentPage
{
    byte[] objetoimagen;

    public FormProductoViewModel vm { get; set; }
    public FormProductoView(ProductoDTO model, string titulo)
	{
		InitializeComponent();
        vm =  new FormProductoViewModel(Navigation, model, titulo);
        BindingContext = vm;

       
    }
    private async void tabPreviewImage_Tapped(object sender, TappedEventArgs e)
    {


        var result = await MediaPicker.Default.PickPhotoAsync();
        try
        {

            if (result != null)
            {


                using (var stream = await result.OpenReadAsync())
                {
                    // Copiamos la imagen a un MemoryStream, este SÍ quedará vivo
                    var memory = new MemoryStream();
                    await stream.CopyToAsync(memory);

                    // Reiniciar posición para que MAUI pueda leerlo
                    memory.Position = 0;
                    objetoimagen = memory.ToArray();
                    vm.imgmedia = objetoimagen;

                    // Asignamos imagen desde memory (NO se cierra)
                    imgPreview.Source = ImageSource.FromStream(() => memory);
                }
                vm.extension = Path.GetExtension(result.FileName);
            }
        }
        catch (Exception ex)
        {


        }

    }


}