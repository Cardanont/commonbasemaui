using Microsoft.Extensions.Logging;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo
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

            builder.Services.AddSingleton<Repositories.BaseRepository<Customer>>();
            builder.Services.AddSingleton<Repositories.BaseRepository<Order>>();
            builder.Services.AddSingleton<Repositories.BaseRepository<Passport>>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}