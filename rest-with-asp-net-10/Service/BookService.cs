using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.DTOs;
using rest_with_asp_net_10.DTOs.Mappings;
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
            IEnumerable<Book> books = _repository.GetAll();
            return books.ToBookDTOList();
        }

        public BookDTO GetById(int id)
        {
            Book book = _repository.GetById(id);
            return book.ToBookDTO();
        }

        public BookDTO Create(BookDTO bookDTO)
        {
            Book? book = bookDTO.ToBook();
            Book createdBook = _repository.Create(book);
            return createdBook.ToBookDTO();
        }

        public BookDTO Update(BookDTO bookDTO)
        {
            Book? book = bookDTO.ToBook();
            Book updatedBook = _repository.Update(book);
            return updatedBook.ToBookDTO();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
