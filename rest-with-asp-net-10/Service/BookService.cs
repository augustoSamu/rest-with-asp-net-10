using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.Repository;

namespace rest_with_asp_net_10.Service
{
    public class BookService : IBookService
    {
        private readonly Repository<Book> _repository;

        public BookService(Repository<Book> repository)
        {
            _repository = repository;
        }
        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
