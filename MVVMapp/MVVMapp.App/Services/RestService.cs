﻿using MVVMapp.App.Models;
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
        _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7023/") };
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<StudDayOfWeek> RefreshDataAsync(string group, int subGroup, DateTime date)
    {
        try
        {
            string json = JsonSerializer.Serialize<DateTime>(date, _serializerOptions);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"api/SdStud/Gen?group={group}&subgroup={subGroup}", requestContent);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<Lesson>>(content, _serializerOptions);

                var model = new StudDayOfWeek()
                {
                    Lessons = data,
                    Group = group,
                };
                return model;
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
                new Lesson {Name = lessonName},
                new Lesson {Name = "Экономика"},
                new Lesson {Name = "ММоделирование эк систем",},
            }
        };

        return StudDayOfWeek;
    }
}
