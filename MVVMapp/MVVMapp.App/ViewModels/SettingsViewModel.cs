using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMapp.App.DAL;

namespace MVVMapp.App.ViewModels;


public partial class SettingsViewModel : ObservableObject
{

    [ObservableProperty]
    private string? title = "Настройки";
    
    [ObservableProperty]
    private string? selectedGroup = string.Empty;

    [ObservableProperty]
    private List<string> groupList = new List<string> { "423402", "123123" };

    [ObservableProperty]
    private List<int> timerValueList = new List<int> { 5, 15, 30, 60 };

    private readonly UserSettingsDB _userSettingsDB;


    public SettingsViewModel(UserSettingsDB userSettingsDB)
    {
        _userSettingsDB = userSettingsDB;
    }


    [RelayCommand]
    private void ItemSelected(object item)
    {
        selectedGroup = item as string;
    }


    async public void OnAppearing()
    {

    }
}
