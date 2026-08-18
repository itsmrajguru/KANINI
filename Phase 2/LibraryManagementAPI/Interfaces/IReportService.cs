using LibraryManagementAPI.DTOs;

namespace LibraryManagementAPI.Interfaces
{
    // Contract for admin report operations
    public interface IReportService
    {
        List<BookDto> GetMostBorrowedBooks(int top = 10);
        List<MemberDto> GetMostActiveMembers(int top = 10);
    }
}
