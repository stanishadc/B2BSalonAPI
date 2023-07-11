using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IBranchSubscriptionRespository
    {
        IEnumerable<BranchSubscription> GetAll();
        BranchSubscription GetDataById(Guid Id);
        void CreateRecord(BranchSubscription data);
        void UpdateRecord(BranchSubscription data);
        void DeleteRecord(BranchSubscription data);
    }
    public class BranchSubscriptionRespository : RepositoryBase<BranchSubscription>, IBranchSubscriptionRespository
    {
        public BranchSubscriptionRespository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<BranchSubscription> GetAll()
        {
            return FindAll().OrderBy(ow => ow.CreatedDate).ToList();
        }
        public BranchSubscription GetDataById(Guid Id)
        {
            return FindByCondition(client => client.BranchSubscriptionId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(BranchSubscription data)
        {
            Create(data);
        }
        public void UpdateRecord(BranchSubscription data)
        {
            Update(data);
        }
        public void DeleteRecord(BranchSubscription data)
        {
            Delete(data);
        }
    }
}

