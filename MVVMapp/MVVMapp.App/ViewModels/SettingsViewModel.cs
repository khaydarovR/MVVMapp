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
    private int? selectedSubGroup = 1;

    [ObservableProperty]
    private List<string> groupList = new List<string> { "4231101", "4231111", "42311129", "4231123",
    "4231133","4231102","4221101","4221111","4221113","42211129","4221123","4221133","4221102","4221103","4211101","4211102",
    "4211111","4211123","4211133","4211103","4211104","4211112","4211113","4201101","4201111","42011129","4201123","4201133",
    "4201102","4201112"};

    [ObservableProperty]
    private List<int> timerValueList = new List<int> { 5, 10, 30, 60, 1440};

    [ObservableProperty]
    private List<int> subGroupList = new List<int> { 1, 2 };


    public SettingsViewModel()
    {
        SetSettingsfromStorage();
        if (storageGroup != "")
        {
            selectedGroup = storageGroup;
        }
        if (storageTimer != "")
        {
            selectedTimer = int.Parse(storageTimer);
        }
        if (storageSubGroup != "")
        {
            selectedSubGroup = int.Parse(storageSubGroup);
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
    private void SubGroupSelected(object item)
    {
        Preferences.Set(Constants.KeySubGroup, selectedSubGroup.ToString());
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
            }
        };

#if ANDROID
        await LocalNotificationCenter.Current.Show(request);
#endif
    }

    string storageTimer = "";
    string storageGroup = ""; 
    string storageSubGroup = ""; 
    [RelayCommand]
    private async void GetSettingsAsync(object item)
    {
        await Application.Current.MainPage.DisplayAlert("Msg", $"{storageGroup}, {storageTimer}, {storageSubGroup}", "Ok", "Cancel");
    }

    private void SetSettingsfromStorage()
    {
        storageTimer = Preferences.Get(Constants.KeyTimer, "");
        storageGroup = Preferences.Get(Constants.KeyGroup, "");
        storageSubGroup = Preferences.Get(Constants.KeySubGroup, "");
    }

    async public void OnAppearing()
    {

    }
}
