using rest_with_asp_net_10.Model;
using rest_with_asp_net_10.Model.Context;

namespace rest_with_asp_net_10.Services
{
    public class PersonService : IPersonService
    {
        private MSSQLContext _context;

        public PersonService(MSSQLContext context)
        {
            _context = context;
        }

        public Person FindById(int id)
        {
            return MockPerson(id);
        }
        
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person Create(Person person)
        {
            person.Id = new Random().Next(9);
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {

        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = $"John {i}",
                LastName = $"Doe {i}",
                Address = $"123 Main {i}",
                Gender = i % 2 == 0 ? "Male" : "Female"
            };
        }

    }
}
