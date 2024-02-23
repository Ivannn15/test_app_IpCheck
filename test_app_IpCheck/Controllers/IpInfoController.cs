using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using test_app_IpCheck.Models;

namespace test_app_IpCheck.Controllers
{
    public class IpInfoController : Controller
    {
        private readonly HttpClient _httpClient; // Приватное поле для сервиса RequestHistoryService
        private readonly RequestHistoryService _requestHistoryService; // Конструктор контроллера

        public IpInfoController(HttpClient httpClient, RequestHistoryService requestHistoryService)
        {
            _httpClient = httpClient; // Инициализация HttpClient
            _requestHistoryService = requestHistoryService; // Инициализация сервиса RequestHistoryService
        }

        [HttpGet("{ipAddress}")]
        public async Task<IActionResult> GetIpInfo(string ipAddress) // Метод для получения информации об IP-адресе
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://ipinfo.io/{ipAddress}/geo"); // Отправка GET-запроса к API для получения информации по IP-адресу
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync(); // Получение текстового содержимого ответа

                // Сохраняем уникальные запросы в базу данных
                _requestHistoryService.AddRequestHistory(ipAddress); // Вызов метода сервиса для сохранения запроса в бд

                return Ok(responseData);
            }
            return NotFound();
        }
    }
}