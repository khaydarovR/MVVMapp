using MVVMapp.App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVVMapp.App.Services;

public class RestService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public StudDayOfWeek StudDayOfWeek { get; private set; }

    public RestService()
    {
        _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7117/") };
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<StudDayOfWeek> RefreshDataAsync(string group, int subGroup, DateTime date)
    {
        StudDayOfWeek = new();

        try
        {
            HttpResponseMessage response = await _client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                StudDayOfWeek = JsonSerializer.Deserialize<StudDayOfWeek>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return StudDayOfWeek;
    }

    public StudDayOfWeek RefreshData(string group, int subGroup, DateTime date)
    {
        string lessonName = "Сегодня дата";
        if(date.Day == 23)
        {
            lessonName = "Другая дата";
        }

        StudDayOfWeek = new()
        {
            DayInWeek = DayOfWeek.Monday,
            Group = group,
            WeekType = WeekTypeEnum.Вверхняя,
            Lessons = new List<Lesson>
            {
                new Lesson {Name = lessonName, StartTime = new TimeOnly(8, 0)},
                new Lesson {Name = "Экономика", StartTime = new TimeOnly(9, 40)},
                new Lesson {Name = "ММоделирование эк систем", StartTime = new TimeOnly(11, 50)},
            }
        };

        return StudDayOfWeek;
    }
}
