using POC.Domain.Entities;

namespace POC.Domain.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product GetById(Guid id);
    IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    Product Create(Product product);
    Product Update(Product product);
    bool Remove(Product product);
}
