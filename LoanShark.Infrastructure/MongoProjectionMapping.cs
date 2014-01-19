using LoanShark.Application;
using LoanShark.Core.Origination.Projections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LoanShark.Infrastructure
{
    public class MongoProjectionMapping : IBootstrapTask
    {
        public void Run()
        {
            BsonClassMap.RegisterClassMap<AcceptedLoan>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.ApplicationId);
                //cm.SetIdMember(cm.GetMemberMap(x => x.ApplicationId).SetIdGenerator(StringObjectIdGenerator.Instance));
            });
        }
    }
}
