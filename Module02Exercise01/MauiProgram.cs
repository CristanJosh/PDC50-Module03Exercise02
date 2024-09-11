using Microsoft.Extensions.Logging;
using Module02Exercise01.View;
using Module02Exercise01.Services;

namespace Module02Exercise01
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

#if DEBUG
            //Service
            builder.Services.AddSingleton<IMyService, MyService>();

            //contentpage
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<OfflinePage>();

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
