using Microsoft.AspNetCore.Mvc;
using POC.Domain.Entities;
using POC.Domain.Interfaces;

namespace POC.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly ILogger<CategoryController> _logger;

    public CategoryController(
        ILogger<CategoryController> logger,
        ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public IEnumerable<Category> Get()
    {
        return _categoryRepository.GetCategories();
    }

    [HttpPost]
    public Category Insert(Category category)
    {
        var insertCategory = new Category(category.Name);
        return _categoryRepository.Create(insertCategory);
    }    
}
