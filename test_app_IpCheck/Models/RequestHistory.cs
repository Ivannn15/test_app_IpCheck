namespace test_app_IpCheck.Models
{
    public class RequestHistory
    {
        public int Id { get; set; } // Идентификатор записи
        public string IpAddress { get; set; } // IP-адрес, по которому был сделан запрос
        public DateTime RequestTime { get; set; } // Время запроса
    }
}
