using LoanShark.Core;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LoanShark.Infrastructure
{
    public class MongoDbReadModelRepository : IReadModelRepository
    {
        private MongoDatabase _mongoDatabase;

        public MongoDbReadModelRepository()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            _mongoDatabase = server.GetDatabase("LoanShark");
        }

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> query)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof (T).ToString());
            return collection.Find(Query<T>.Where(query)).ToList();
        }

        public void Save<T>(T projection)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).ToString());
            collection.Save(projection);
        }

        public void Remove<T>(Expression<Func<T, bool>> query)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof (T).ToString());
            collection.Remove(Query<T>.Where(query));
        }
    }
}
