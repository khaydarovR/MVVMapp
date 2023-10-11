using MVVMapp.App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
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
        //_client = new HttpClient() { BaseAddress = new Uri("https://localhost:7023/") };

        _client = new HttpClient() { BaseAddress = new Uri("http://195.58.51.167/") };
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    /// <summary>
    /// Получение расписания на определённую дату
    /// </summary>
    /// <param name="group"></param>
    /// <param name="subGroup"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public async Task<StudDayOfWeek> RefreshDataAsync(string group, int subGroup, DateTime date)
    {
        var serviceResponse = new StudDayOfWeek();
        try
        {
            string json = JsonSerializer.Serialize<DateTime>(date, _serializerOptions);
            StringContent requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"api/SdStud/Gen?group={group}&subgroup={subGroup}", requestContent);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<Lesson>>(content, _serializerOptions);

                serviceResponse.Lessons = data;
                serviceResponse.Group = group;

                return serviceResponse;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return serviceResponse;
    }


    /// <summary>
    /// Получение найденных групп с таблицы
    /// </summary>
    /// <returns></returns>
    public async Task<List<string>> GetGroupsFromServer()
    {
        var serviceResponse = new List<string>() { "Сервер не ответил" };
        try
        {
            var response = await _client.GetAsync("api/Common/Groups");
            if (response.IsSuccessStatusCode)
            {
                serviceResponse = await response.Content.ReadFromJsonAsync<List<string>>();

                return serviceResponse;
            }
            else
            {
                serviceResponse.Add(await response.Content.ReadAsStringAsync());
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return serviceResponse;
    }

    /// <summary>
    /// Проверка работоспособности сервера
    /// </summary>
    /// <returns></returns>
    public async Task<string> PingService()
    {
        var serviceResponse = "Сервер не ответил";
        try
        {
            var response = await _client.GetAsync("ping");
            if (response.IsSuccessStatusCode)
            {
                serviceResponse = await response.Content.ReadAsStringAsync();
                return serviceResponse;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return serviceResponse;
    }
}