using HW_4_6.Dto;

namespace HW_4_6.Services.Abstractions;

/// <summary>
/// Category service interface.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Used to get all categories.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<CategoryListDto>> GetAllCategoriesAsync();

    /// <summary>
    /// Used to get one category.
    /// </summary>
    /// <param name="id">Category id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CategoryDto> GetCategoryById(int id);

    /// <summary>
    ///  Used to create category.
    /// </summary>
    /// <param name="categoryDto">Category to create <see cref="CategoryDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> CreateCategory(CategoryDto categoryDto);

    /// <summary>
    /// Used to update category.
    /// </summary>
    /// <param name="categoryDto">Category to update <see cref="CategoryDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> UpdateCategory(CategoryDto categoryDto);

    /// <summary>
    /// Used to delete category.
    /// </summary>
    /// <param name="id">Category id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> DeleteCategory(int id);
}