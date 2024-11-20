namespace LinkExchange.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<LinkModel> Links {  get; set; }
        
        public UserModel(string username, string password, DateTime date) {
            Username = username;
            Password = password;
            CreatedDate = date;
        }


    }

}
