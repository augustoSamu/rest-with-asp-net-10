using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.DTOs.Mappings;
using rest_with_asp_net_10.DTOs.V2;
using rest_with_asp_net_10.Repository;

namespace rest_with_asp_net_10.Service
{
    public class PersonServiceV2
    {
        private IRepository<Person> _repository;

        public PersonServiceV2(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public PersonDTO Create(PersonDTO personDTO)
        {
            Person? person = personDTO.ToPerson();
            Person createdPerson = _repository.Create(person);
            return createdPerson.ToPersonDTO();
        }
    }
}
