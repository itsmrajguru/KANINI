using LibraryManagementAPI.DTOs;

namespace LibraryManagementAPI.Interfaces
{
    /*Interface is nothing a fixed logic class
    that is called by diffrent services
    so that diffrent services like fakeDB or database
    can call this class to run the logic in it
    that is supported directly by the controller
    in short , we made work of the controller easy
    now the controller will only handle requests , but the 
    bussines logic is written in the services...*/

    /* Interface is basically a contract saying:
    "Any class that wants to act as a Book service must provide these operations." */
    public interface IAuthorService
    {
        List<AuthorDto> GetAllAuthors();
        AuthorDto? GetAuthorById(int id);
        List<BookDto> GetBooksByAuthor(int authorId);
        AuthorDto CreateAuthor(CreateAuthorDto dto);
        AuthorDto? UpdateAuthor(int id, CreateAuthorDto dto);
        bool DeleteAuthor(int id);
    }
}
