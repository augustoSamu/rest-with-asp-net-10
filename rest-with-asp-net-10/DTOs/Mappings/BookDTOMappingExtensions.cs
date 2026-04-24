using rest_with_asp_net_10.Domain;

namespace rest_with_asp_net_10.DTOs.Mappings
{
    public static class BookDTOMappingExtensions
    {
        public static BookDTO? ToBookDTO(this Book book)
        {
            if (book is null)
                return null;

            return new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                LauchDate = book.LauchDate
            };
        }

        public static Book? ToBook(this BookDTO bookDTO)
        {
            if (bookDTO is null)
                return null;

            return new Book()
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Price = bookDTO.Price,
                LauchDate = bookDTO.LauchDate
            };
        }

        public static IEnumerable<BookDTO>? ToBookDTOList(this IEnumerable<Book> books)
        {
            if (books is null || !books.Any())
                return null;

            return books.Select(b => new BookDTO()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price,
                LauchDate = b.LauchDate
            }).ToList();
        }
    }
}
