using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.DTOs.Mappings;
using rest_with_asp_net_10.DTOs.V1;
using rest_with_asp_net_10.Repository;

namespace rest_with_asp_net_10.Service
{
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            IEnumerable<Person> persons = _repository.GetAll();
            return persons.ToPersonDTOList();
        }

        public PersonDTO GetById(int id)
        {
            Person person = _repository.GetById(id);
            return person.ToPersonDTO(); ;
        }

        public PersonDTO Create(PersonDTO personDTO)
        {
            Person? person = personDTO.ToPerson();
            Person createdPerson = _repository.Create(person);
            return createdPerson.ToPersonDTO();
        }

        public PersonDTO Update(PersonDTO personDTO)
        {
            Person? person = personDTO.ToPerson();
            Person updatedPerson = _repository.Update(person);
            return updatedPerson.ToPersonDTO();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
