namespace rest_with_asp_net_10.DTOs.V1
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LauchDate { get; set; }
    }
}
