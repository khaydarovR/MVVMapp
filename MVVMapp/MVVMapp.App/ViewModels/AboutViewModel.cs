﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace MVVMapp.App.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? title = "О приложении";

        [RelayCommand]
        private async Task OpenWeb()
        {
            //await Browser.OpenAsync("https://learn.microsoft.com/en-us/dotnet/maui/?view=net-maui-7.0");
        }
    }
}