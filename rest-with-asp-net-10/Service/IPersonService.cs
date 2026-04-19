using rest_with_asp_net_10.Model;

namespace rest_with_asp_net_10.Service
{
    public interface IPersonService
    {
        Person FindById(int id);

        List<Person> FindAll();

        Person Create(Person person);

        Person Update(Person person);

        void Delete(int id);
    }
}
