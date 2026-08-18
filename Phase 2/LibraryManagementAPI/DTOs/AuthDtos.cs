using System.ComponentModel.DataAnnotations;
using LibraryManagementAPI.Models.Enums;


/* Best defination of DTO(Data Transfer Object)

in MERN Stack, When we need some data from the user we were taking the only data, 
we need from req.body ex...const{id,name}=req.body

but in .NET
We've created a separate file for this API data transfer called Data Transfer Object
Why do we need this?
So
DTO to separate the API contract from the database entity. The DTO controls what data the 
API receives or returns,while the Book entity represents the data that EF Core works with 
for database operations. 

Book = how my application/database represents a book.
BookDto = what information I want to transfer through my API.*/
namespace LibraryManagementAPI.DTOs
{
    // What the client sends to register a new user
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required!")]
        [MaxLength(50)]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = "";

        // Default role is Member, Admin can change this
        public UserRole Role { get; set; } = UserRole.Member;
    }

    // What the client sends to log in
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; } = "";
    }

    // What we send back after successful login
    public class AuthResponseDto
    {
        public string Token { get; set; } = "";
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
    }
}
