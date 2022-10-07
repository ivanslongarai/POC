using POC.Domain.Entities;

namespace POC.Domain.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();
    Category GetById(Guid id);
    Category Create(Category category);
    Category Update(Category category);
    bool Remove(Category category);
}
