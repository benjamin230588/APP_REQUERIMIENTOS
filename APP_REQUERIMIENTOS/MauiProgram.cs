using APP_REQUERIMIENTOS.Handlers;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace APP_REQUERIMIENTOS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit().UseSkiaSharp();

            builder
                .UseMauiApp<App>();
#if ANDROID
            // Mapea la Toolbar nativa para tintar overflow, nav icon y menu icons
            Microsoft.Maui.Handlers.ToolbarHandler.Mapper.AppendToMapping("TintOverflow", (handler, view) =>
            {
                try
                {
                    var toolbar = handler.PlatformView; // AndroidX.AppCompat.Widget.Toolbar
                    if (toolbar == null) return;

                    // 1) Overflow icon (tres puntitos)
                    var overflow = toolbar.OverflowIcon;
                    if (overflow != null)
                    {
                        // Mutate antes de tintar para evitar afectar otros drawables
                        overflow = overflow.Mutate();
                        overflow.SetColorFilter(Android.Graphics.Color.White, Android.Graphics.PorterDuff.Mode.SrcIn);
                        toolbar.OverflowIcon = overflow;
                    }

                    // 2) Navigation (flecha atrás)
                    var navIcon = toolbar.NavigationIcon;
                    if (navIcon != null)
                    {
                        navIcon = navIcon.Mutate();
                        navIcon.SetColorFilter(Android.Graphics.Color.White, Android.Graphics.PorterDuff.Mode.SrcIn);
                        toolbar.NavigationIcon = navIcon;
                    }

                    // 3) Si ya hay íconos en el Menu, los tintamos también (por si se inflaron temprano)
                    var menu = toolbar.Menu;
                    if (menu != null)
                    {
                        for (int i = 0; i < menu.Size(); i++)
                        {
                            var item = menu.GetItem(i);
                            var icon = item?.Icon;
                            if (icon != null)
                            {
                                icon = icon.Mutate();
                                icon.SetColorFilter(Android.Graphics.Color.White, Android.Graphics.PorterDuff.Mode.SrcIn);
                                item.SetIcon(icon);
                            }
                        }
                    }

                    // Opcional: si el menú se infla después, esto puede volver a aplicarse.
                    // Podrías volver a aplicar el tint en un pequeño delay si no se ve inmediatamente.
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error tint toolbar: {ex}");
                }
            });
#endif


#if DEBUG
            builder.Logging.AddDebug();
#endif
           //FormHandler.RemoveBorders();
            //handlers.AddHandler<NoSwipeTabbedPage, Platforms.Android.NoSwipeTabbedPageHandler>();
            return builder.Build();
        }
    }
}
