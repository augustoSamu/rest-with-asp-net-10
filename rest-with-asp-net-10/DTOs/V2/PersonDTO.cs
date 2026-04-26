namespace rest_with_asp_net_10.DTOs.V2
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
