using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMapp.App.Models;
using MVVMapp.App.DAL;
using System.Collections.ObjectModel;
using MVVMapp.App.Services;
using System.ComponentModel;
using System.Diagnostics;
using Plugin.LocalNotification;

namespace MVVMapp.App.ViewModels;

public partial class ScheduleViewModel: ObservableObject
{
    private readonly RestService _restService;
    private bool _isConfigured = false;
    private Dictionary<string, string> _userSettings = new();
    public ScheduleViewModel(RestService restService)
    {
        _dayOfWeekString = Helpers.ToRussianDayOfWeek(DateTime.Now.DayOfWeek);
        _userSettings[Constants.KeyTimer] = Preferences.Get(Constants.KeyTimer, "");
        _userSettings[Constants.KeyGroup] = Preferences.Get(Constants.KeyGroup, "");
        _userSettings[Constants.KeySubGroup] = Preferences.Get(Constants.KeySubGroup, "");
        _restService = restService;

        CheckConfiguration();

        if (_isConfigured)
        {
            UpdateSchelduler();
        }
    }

    private void CheckConfiguration()
    {
        var emptySet = _userSettings.FirstOrDefault(v => !string.IsNullOrEmpty(v.Value)).Value;
        if (string.IsNullOrEmpty(emptySet))
        {
            _isConfigured = false;
        }
        else
        {
            _isConfigured = true;
        }
    }

    [ObservableProperty]
    private DateTime _appointmentDate = DateTime.Now;

    [ObservableProperty]
    private RussianDayOfWeek _dayOfWeekString;
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.PropertyName == nameof(AppointmentDate))
        {
            Debug.WriteLine($"AppointmentDate: {AppointmentDate}");
        }

    }

    [RelayCommand]
    private async Task DatePicked(DateTime date)
    {
        Debug.WriteLine($"AppointmentDate: {date}");

        DayOfWeekString = Helpers.ToRussianDayOfWeek(date.DayOfWeek);

        if (_isConfigured)
        {
            UpdateSchelduler();
        }
    }

    [ObservableProperty]
    private string? title = "Расписание";
    
    [ObservableProperty]
    private ObservableCollection<Lesson> lessonsList = new() { new Lesson { Name = "Не удалось загрузить расписание"} };

    private async void UpdateSchelduler()
    {
        var storageGroup = Preferences.Get(Constants.KeyGroup, "");
        var storageSubGroup = Preferences.Get(Constants.KeySubGroup, "");
        var storageTimer = Preferences.Get(Constants.KeyTimer, "");

        var data = await _restService.RefreshDataAsync(storageGroup, int.Parse(storageSubGroup), _appointmentDate);
        LessonsList = data.Lessons.ToObservableCollection();
        if (string.IsNullOrEmpty(storageTimer) == false)
        {
#if ANDROID
            CreateNotifyForLessons(LessonsList);
#endif
        }
    }

    private void CreateNotifyForLessons(IEnumerable<Lesson> lessons)
    {
        var storageTimer = Preferences.Get(Constants.KeyTimer, "");
        foreach (var les in lessons)
        {
            var request = new NotificationRequest()
            {
                NotificationId = les.Id,
                Title = les.Name,
                Subtitle = les.StartTime.ToShortTimeString(),
                Description = les.Locate + " " + les.TeacherName + " " + les.LessonTypeEnum,
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = _appointmentDate.AddHours(les.StartTime.Hour).AddMinutes(les.StartTime.Minute - int.Parse(storageTimer))
                }
            };

            LocalNotificationCenter.Current.Show(request);
        }
    }
}
