using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.Repository;

namespace rest_with_asp_net_10.Service
{
    public class PersonService : IPersonService
    {
        private Repository<Person> _repository;

        public PersonService(Repository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public Person GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
