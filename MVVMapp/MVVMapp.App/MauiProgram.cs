    using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MVVMapp.App.DAL;
using MVVMapp.App.Models;
using MVVMapp.App.Services;
using MVVMapp.App.ViewModels;
using MVVMapp.App.Views;
using Plugin.LocalNotification;
using System.Globalization;

namespace MVVMapp.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat;

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
#if ANDROID
                .UseLocalNotification()
#endif
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

            builder.Services.AddScoped<ScheduleViewModel>();
            builder.Services.AddScoped<SchedulePage>();

            builder.Services.AddScoped<SettingsViewModel>();
            builder.Services.AddScoped<SelfSettingsPage>();

            builder.Services.AddSingleton<ILessonsDataStore, LessonsDataStore>();
            builder.Services.AddSingleton<RestService>();

            return builder.Build();
        }
    }
}