namespace rest_with_asp_net_10.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        T Create(T item);

        T Update(T item);

        void Delete(int id);

        bool Exists(int id);
    }
}
