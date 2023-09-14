﻿using Microsoft.Extensions.Logging;
using MVVMapp.App.Models;
using MVVMapp.App.Services;
using MVVMapp.App.ViewModels;
using MVVMapp.App.Views;

namespace MVVMapp.App
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
                    fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
                    fonts.AddFont("fa-brands-400.ttf", "FontAwesomeBrands");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                });

#if DEBUG
		builder.Logging.AddDebug();
		builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif
            builder.Services.AddSingleton<IDataStore<Item>, MockDataStore>();
            builder.Services.AddScoped<ItemsViewModel>();
            builder.Services.AddScoped<ItemsPage>();
            builder.Services.AddScoped<ItemDetailViewModel>();
            builder.Services.AddScoped<ItemDetailPage>();
            builder.Services.AddScoped<NewItemViewModel>();
            builder.Services.AddScoped<NewItemPage>();

            return builder.Build();
        }
    }
}