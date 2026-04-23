using rest_with_asp_net_10.Domain;

namespace rest_with_asp_net_10.Service
{
    public interface IPersonService
    {
        List<Person> GetAll();

        Person GetById(int id);

        Person Create(Person person);

        Person Update(Person person);

        void Delete(int id);
    }
}
