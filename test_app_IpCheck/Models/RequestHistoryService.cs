namespace test_app_IpCheck.Models
{
    public class RequestHistoryService
    {
        private readonly AppDbContext _dbContext;
        public RequestHistoryService(AppDbContext dbContext) // Конструктор класса
        {
            _dbContext = dbContext;
        }

        public void AddRequestHistory(string ipAddress) // Метод для добавления записи истории запросов
        {
            // Проверяем наличие записи с таким IP-адресом
            var existingRequest = _dbContext.RequestHistories.FirstOrDefault(r => r.IpAddress == ipAddress);

            if (existingRequest != null)
            {
                // Если запись существует, то не обновляем бд так как такой запрос удже был
            }
            else
            {
                // Если записи с таким IP-адресом нет, добавляем новую запись
                _dbContext.RequestHistories.Add(new RequestHistory
                {
                    IpAddress = ipAddress,
                    RequestTime = DateTime.Now
                });
                _dbContext.SaveChanges(); // Сохраняем изменения в базе данных
            }
        }
    }
}