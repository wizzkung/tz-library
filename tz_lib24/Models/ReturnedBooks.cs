namespace tz_lib24.Models
{
    public class ReturnedBooks
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public int user_id { get; set; }
        public DateTime date_issued { get; set; }
        public DateTime due_date { get; set; }
    }
}
