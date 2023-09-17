using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMapp.App.Models;
using MVVMapp.App.Views;
using System.Collections.ObjectModel;

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

    [ObservableProperty]
    private ObservableCollection<Lesson> lessonsList = new ObservableCollection<Lesson>
    {
        new Lesson(){Name = "Программирование"},
        new Lesson(){Name = "Экономика"},
        new Lesson(),
        new Lesson(),
    };

    [ObservableProperty]
    private ObservableCollection<string> stringList = new ObservableCollection<string>
    {
        "asd", "re32sdf", "asdasd12"
    };


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
