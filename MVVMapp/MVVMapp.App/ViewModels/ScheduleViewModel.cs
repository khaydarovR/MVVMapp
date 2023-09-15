using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMapp.App.Views;

namespace MVVMapp.App.ViewModels;

public partial class ScheduleViewModel: ObservableObject
{

    public ScheduleViewModel()
    {

    }

    [ObservableProperty]
    private DateOnly? selectedDate = default;

    [ObservableProperty]
    private string? title = "Расписание";


    [RelayCommand]
    private async void OnAddItem(object obj)
    {
        await Shell.Current.GoToAsync(nameof(AboutPage));
    }



    async public void OnAppearing()
    {
        selectedDate = null;
    }
}
