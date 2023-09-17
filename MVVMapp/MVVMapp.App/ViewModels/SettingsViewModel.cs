using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMapp.App.DAL;
using MVVMapp.App.Models;
using Plugin.LocalNotification;

namespace MVVMapp.App.ViewModels;


public partial class SettingsViewModel : ObservableObject
{

    [ObservableProperty]
    private string? title = "Настройки";
    
    [ObservableProperty]
    private string? selectedGroup = string.Empty;

    [ObservableProperty]
    private int? selectedTimer = 0;

    [ObservableProperty]
    private List<string> groupList = new List<string> { "423402", "123123", "2133232" };

    [ObservableProperty]
    private List<int> timerValueList = new List<int> { 30, 60, 12};

    private readonly UserSettingsDB _userSettingsDB;

    public SettingsViewModel(UserSettingsDB userSettingsDB)
    {
        _userSettingsDB = userSettingsDB;
        SetSettingsfromStorage();
        if (storageGroup != "")
        {
            selectedGroup = storageGroup;
        }
        if (storageTimer != "")
        {
            selectedTimer = int.Parse(storageTimer);
        }
    }


    [RelayCommand]
    private void GroupSelected(object item)
    {
        Preferences.Set(Constants.KeyGroup, selectedGroup);
    }

    [RelayCommand]
    private void TimerSelected(object item)
    {
        Preferences.Set(Constants.KeyTimer, selectedTimer.ToString());
    }

    [RelayCommand]
    private async void SendNotify(object item)
    {
        var request = new NotificationRequest
        {
            NotificationId = 1000,
            Title = "Пара",
            Subtitle = "У вас пара",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5),
                NotifyRepeatInterval = TimeSpan.FromDays(1)
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }

    string storageTimer = "";
    string storageGroup = ""; 
    [RelayCommand]
    private async void GetSettingsAsync(object item)
    {
        await Application.Current.MainPage.DisplayAlert("Msg", $"{storageGroup}, {storageTimer}", "Ok", "Cancel");
    }

    private void SetSettingsfromStorage()
    {
        storageTimer = Preferences.Get(Constants.KeyTimer, "");
        storageGroup = Preferences.Get(Constants.KeyGroup, "");
    }

    async public void OnAppearing()
    {

    }
}
