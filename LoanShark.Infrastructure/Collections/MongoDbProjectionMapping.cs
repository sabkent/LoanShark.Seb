using LoanShark.Application;
using LoanShark.Core.Collections.Projections;
using MongoDB.Bson.Serialization;

namespace LoanShark.Infrastructure.Collections
{
    public sealed class MongoDbProjectionMapping : IBootstrapTask
    {
        public void Run()
        {
            BsonClassMap.RegisterClassMap<Debt>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.Id);
            });
        }
    }
}
