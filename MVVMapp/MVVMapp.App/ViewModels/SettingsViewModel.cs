using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVMapp.App.ViewModels;


public partial class SettingsViewModel : ObservableObject
{
    public SettingsViewModel()
    {

    }

    [ObservableProperty]
    private string? title = "Настройки";

    [ObservableProperty]
    private List<string> groupList = new List<string> { "423402", "123123" };

    async public void OnAppearing()
    {

    }
}
