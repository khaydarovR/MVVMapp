using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMapp.App.DAL;
using MVVMapp.App.Models;

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
    private List<int> timerValueList = new List<int> { 123, 12343};

    private readonly UserSettingsDB _userSettingsDB;


    public SettingsViewModel(UserSettingsDB userSettingsDB)
    {
        _userSettingsDB = userSettingsDB;
    }


    UserSetting setting = new UserSetting();
    [RelayCommand]
    private void GroupSelected(object item)
    {
        setting.Group = selectedGroup;
    }



    async public void OnAppearing()
    {

    }
}
