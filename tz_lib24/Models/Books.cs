namespace tz_lib24.Models
{
    public class Books
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string code { get; set; }
        public int year { get; set; }
        public string publisher { get; set; }
        public string shelf { get; set; }
        public bool is_issued { get; set; }
        public int quantity { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? return_date { get; set; }
    }
}
