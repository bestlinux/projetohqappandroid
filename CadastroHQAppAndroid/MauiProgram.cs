using CadastroHQAppAndroid.Services;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace CadastroHQAppAndroid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        ErrorHandling.InitializeGlobalExceptionHandler();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader() // Make sure to add this line
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IAlunoService, AlunoService>();
        builder.Services.AddSingleton<IHQService, HQService>();
        return builder.Build();
    }
}
