using LibraryManagementAPI.DTOs;

namespace LibraryManagementAPI.Interfaces
{
    // Contract for all category-related operations
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();
        CategoryDto? GetCategoryById(int id);
        CategoryDto CreateCategory(CreateCategoryDto dto);
        CategoryDto? UpdateCategory(int id, CreateCategoryDto dto);
        bool DeleteCategory(int id);
    }
}
