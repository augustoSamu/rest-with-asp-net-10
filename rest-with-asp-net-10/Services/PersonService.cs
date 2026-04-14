using rest_with_asp_net_10.Model;

namespace rest_with_asp_net_10.Services
{
    public class PersonService : IPersonService
    {
        public Person FindById(int id)
        {
            return MockPerson(id);
        }
        
        public List<Person> FindAll()
        {
            return new List<Person>
            {
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000)),
                MockPerson(new Random().Next(1, 1000))
            };
        }

        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000);
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
