using Mapster;
using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.DTOs.V1;
using rest_with_asp_net_10.Repository;

namespace rest_with_asp_net_10.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _repository.GetAll().Adapt<List<BookDTO>>();
        }

        public BookDTO GetById(int id)
        {
            return _repository.GetById(id).Adapt<BookDTO>();
        }

        public BookDTO Create(BookDTO bookDTO)
        {
            Book? book = bookDTO.Adapt<Book>();
            Book createdBook = _repository.Create(book);
            return createdBook.Adapt<BookDTO>();
        }

        public BookDTO Update(BookDTO bookDTO)
        {
            Book? book = bookDTO.Adapt<Book>();
            Book updatedBook = _repository.Update(book);
            return updatedBook.Adapt<BookDTO>();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
