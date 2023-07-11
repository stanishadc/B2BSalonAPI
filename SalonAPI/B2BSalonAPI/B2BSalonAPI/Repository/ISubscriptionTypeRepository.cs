using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface ISubscriptionTypeRepository
    {
        IEnumerable<SubscriptionType> GetAll();
        SubscriptionType GetDataById(Guid Id);
        void CreateRecord(SubscriptionType data);
        void UpdateRecord(SubscriptionType data);
        void DeleteRecord(SubscriptionType data);
    }
    public class SubscriptionTypeRepository : RepositoryBase<SubscriptionType>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<SubscriptionType> GetAll()
        {
            return FindAll().OrderBy(ow => ow.SubscriptionTypeId).ToList();
        }
        public SubscriptionType GetDataById(Guid Id)
        {
            return FindByCondition(client => client.SubscriptionTypeId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(SubscriptionType data)
        {
            Create(data);
        }
        public void UpdateRecord(SubscriptionType data)
        {
            Update(data);
        }
        public void DeleteRecord(SubscriptionType data)
        {
            Delete(data);
        }
    }
}
