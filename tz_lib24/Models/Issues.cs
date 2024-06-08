namespace tz_lib24.Models
{
    public class Issues
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public Books book { get; set; }
        public int user_id { get; set; }
        public Users user { get; set; }
        public int quantity { get; set; }
        public DateTime issue_date { get; set; }
        public DateTime return_date { get; set; }
    }
}
