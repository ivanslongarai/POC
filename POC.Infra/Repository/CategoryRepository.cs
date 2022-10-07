using MongoDB.Driver;
using POC.Domain.Entities;
using POC.Domain.Interfaces;
using POC.Infra.Data;

namespace POC.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        MongoContext _mongoDB;

        IMongoCollection<Category> _categoryCollection;

        public CategoryRepository(MongoContext mongoDB)
        {
            _mongoDB = mongoDB;
            _categoryCollection =
                _mongoDB
                    .DB
                    .GetCollection<Category>(typeof(Category).Name.ToLower());
        }

        public Category Create(Category category)
        {
            _categoryCollection.InsertOne(category);
            return category;
        }

        public Category GetById(Guid id)
        {
            var result =
                _categoryCollection.Find(Builders<Category>.Filter.Where(x => x.Id == id))
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            var result =
                _categoryCollection.Find(Builders<Category>.Filter.Empty)
                .ToList();

            return result;
        }

        public bool Remove(Category category)
        {
            _categoryCollection
                .DeleteOne(Builders<Category>
                    .Filter
                    .Where(i => i.Id == category.Id));

            return true;
        }

        public Category Update(Category category)
        {
            _categoryCollection
                .UpdateOne(Builders<Category>
                    .Filter
                    .Where(i => i.Id == category.Id),
                Builders<Category>.Update.Set("category", category));

            return category;
        }
    }
}