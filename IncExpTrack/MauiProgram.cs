﻿using IncExpTrack.MVVM.Models;
using IncExpTrack.Repositories;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace IncExpTrack
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");
                    fonts.AddFont("Roboto-Black.ttf", "Strong");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<BaseRepository<Transaction>>();

            return builder.Build();
        }
    }
}