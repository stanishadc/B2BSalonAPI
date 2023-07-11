using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface ISubscriptionDataRepository
    {
        IEnumerable<SubscriptionData> GetAll();
        SubscriptionData GetDataById(Guid Id);
        void CreateRecord(SubscriptionData data);
        void UpdateRecord(SubscriptionData data);
        void DeleteRecord(SubscriptionData data);
    }
    public class SubscriptionDataRepository : RepositoryBase<SubscriptionData>, ISubscriptionDataRepository
    {
        public SubscriptionDataRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<SubscriptionData> GetAll()
        {
            return FindAll().OrderBy(ow => ow.SubscriptionDataId).ToList();
        }
        public SubscriptionData GetDataById(Guid Id)
        {
            return FindByCondition(client => client.SubscriptionDataId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(SubscriptionData data)
        {
            Create(data);
        }
        public void UpdateRecord(SubscriptionData data)
        {
            Update(data);
        }
        public void DeleteRecord(SubscriptionData data)
        {
            Delete(data);
        }
    }
}