using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using MVVMapp.App.Models;
using MVVMapp.App.Services;
using MVVMapp.App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.App.ViewModels;

public partial class ScheduleViewModel: ObservableObject
{

    public ObservableCollection<Item> Items { get; }

    public ScheduleViewModel()
    {

    }

    [ObservableProperty]
    private Item? selectedItem = default;

    [ObservableProperty]
    private string? title = "asd";

    [ObservableProperty]
    private bool isBusy;

    [RelayCommand]
    private async void OnAddItem(object obj)
    {
        await Shell.Current.GoToAsync(nameof(AboutPage));
    }



    async public void OnAppearing()
    {
        SelectedItem = null;
    }
}
