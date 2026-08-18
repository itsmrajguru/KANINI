using LibraryManagementAPI.DTOs;

namespace LibraryManagementAPI.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAllBooks();
        BookDto? GetBookById(int id);
        BookDto AddBook(CreateBookDto dto);
        BookDto? UpdateBook(int id, UpdateBookDto dto);
        bool DeleteBook(int id);
        object GetAvailability(int id);
    }
}
