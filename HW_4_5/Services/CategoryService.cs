using AutoMapper;
using HW_4_5.Dto;
using HW_4_5.Models;
using HW_4_5.Repositories.Abstractions;
using HW_4_5.Services.Abstractions;

namespace HW_4_5.Services;

/// <summary>
/// Category service.
/// </summary>
public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryService"/> class.
    /// </summary>
    /// <param name="categoryRepository">An implementation of the <see cref="ICategoryRepository"/> interface.</param>
    /// <param name="mapper">An implementation of the <see cref="IMapper"/> interface.</param>
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Used to get all categories.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<CategoryListDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        var categoriesMap = _mapper.Map<ICollection<CategoryListDto>>(categories);

        return categoriesMap;
    }

    /// <summary>
    /// Used to get one category.
    /// </summary>
    /// <param name="id">Category id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<CategoryDto> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        var categoryMap = _mapper.Map<CategoryDto>(category);

        return categoryMap;
    }

    /// <summary>
    ///  Used to create category.
    /// </summary>
    /// <param name="categoryDto">Category to create <see cref="CategoryDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateCategory(CategoryDto categoryDto)
    {
        var categories = await _categoryRepository.GetAllAsync();

        var foundCategory = categories
            .FirstOrDefault(category => category.CategoryName.Trim().ToUpper() == categoryDto.CategoryName.Trim().ToUpper());

        if (foundCategory != null)
        {
            Console.WriteLine("Category already exists");
            return false;
        }

        var categoryMap = _mapper.Map<Category>(categoryDto);

        var isCategoryCreated = await _categoryRepository.CreateAsync(categoryMap);

        if (!isCategoryCreated)
        {
            Console.WriteLine("Something went wrong while saving the category");
            return false;
        }

        return true;
    }
}