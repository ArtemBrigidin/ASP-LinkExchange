namespace LinkExchange.Models
{
    public class LinkModel
    {
        public int id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public enum LinkStatus
        {
            Available,
            Sold,
            Panding
        }

        public LinkModel(string url, string description, int price, DateTime createdTime, UserModel user)
        {
            Url = url;
            Description = description;
            Price = price;
            CreatedTime = createdTime;
            User = user;
        }

        // добавить в конструктор
        // передачу пользователя и
        // сделать статистику продаж
        // у пользователя
    }
}
