﻿using CommunityToolkit.Maui.Core.Extensions;
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
    public ScheduleViewModel(RestService restService)
    {
        storageTimer = Preferences.Get(Constants.KeyTimer, "");
        storageGroup = Preferences.Get(Constants.KeyGroup, "");
        storageSubGroup = Preferences.Get(Constants.KeySubGroup, "");

        
        _restService = restService;
    }



    [ObservableProperty]
    private DateTime _appointmentDate = DateTime.Now;

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

        UpdateSchelduler();
    }

    [ObservableProperty]
    private string? title = "Расписание";

    [ObservableProperty]
    private ObservableCollection<Lesson> lessonsList = new() { new Lesson { Name = "Из конструктора"} };

    string storageTimer;
    string storageGroup;
    string storageSubGroup;


    private void UpdateSchelduler()
    {
        var data = _restService.RefreshData(storageGroup, int.Parse(storageSubGroup), _appointmentDate);
        LessonsList = data.Lessons.ToObservableCollection();
#if ANDROID
        CreateNotifyForLessons(LessonsList);
#endif
    }

    private void CreateNotifyForLessons(IEnumerable<Lesson> lessons)
    {
        LocalNotificationCenter.Current.CancelAll();

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
                    NotifyTime = _appointmentDate.AddHours(les.StartTime.Hour).AddMinutes(les.StartTime.Minute),
                }
            };

            LocalNotificationCenter.Current.Show(request);
        }
    }
}
