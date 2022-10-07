using MongoDB.Driver;
using POC.Domain.Entities;
using POC.Domain.Interfaces;
using POC.Infra.Data;

namespace POC.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        MongoContext _mongoDB;

        IMongoCollection<Product> _productCollection;

        public ProductRepository(MongoContext mongoDB)
        {
            _mongoDB = mongoDB;
            _productCollection =
                _mongoDB
                    .DB
                    .GetCollection<Product>(typeof (Product).Name.ToLower());
        }

        public Product Create(Product product)
        {
            _productCollection.InsertOne(product);
            return product;
        }

        public Product GetById(Guid id)
        {
            var result =
                _productCollection.Find(Builders<Product>.Filter.Where(x => x.Id == id))
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            var result =
                _productCollection.Find(Builders<Product>.Filter.Empty)
                .ToList();

            return result;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var result =
                _productCollection.Find(Builders<Product>.Filter.Where(x => x.CategoryId == categoryId))
                .ToList();

            return result;
        }

        public bool Remove(Product product)
        {
            _productCollection
                .DeleteOne(Builders<Product>
                    .Filter
                    .Where(i => i.Id == product.Id));

            return true;
        }

        public Product Update(Product product)
        {
            _productCollection
                .UpdateOne(Builders<Product>
                    .Filter
                    .Where(i => i.Id == product.Id),
                Builders<Product>.Update.Set("product", product));

            return product;
        }
    }
}