using rest_with_asp_net_10.Model;
using rest_with_asp_net_10.Model.Context;

namespace rest_with_asp_net_10.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private MSSQLContext _context;

        public PersonRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(int id)
        {
            return _context.Persons.Find(id);
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();

            return person;
        }

        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);

            if (existingPerson is null)
                return null;

            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();

            return person;
        }

        public void Delete(int id)
        {
            var existingPerson = _context.Persons.Find(id);

            if (existingPerson is null)
                return;

            _context.Remove(existingPerson);
            _context.SaveChanges();
        }
    }
}
