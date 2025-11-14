using ComedorComunitario.Data.AdminCode;
using ComedorComunitario.Data.Services;
using ComedorComunitario.Data.ViewModel;
using ComedorComunitario.Views;
using Microsoft.Extensions.Logging;

namespace ComedorComunitario
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<GoogleSheetsService>();
            builder.Services.AddSingleton<HomeAdminCode>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomePage>(); 

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
