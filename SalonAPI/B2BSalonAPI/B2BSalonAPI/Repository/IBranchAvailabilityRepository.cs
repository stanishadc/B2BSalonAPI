using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IBranchAvailabilityRepository
    {
        IEnumerable<BranchAvailability> GetAll();
        BranchAvailability GetDataById(Guid Id);
        void CreateRecord(BranchAvailability data);
        void UpdateRecord(BranchAvailability data);
        void DeleteRecord(BranchAvailability data);
    }
    public class BranchAvailabilityRepository : RepositoryBase<BranchAvailability>, IBranchAvailabilityRepository
    {
        public BranchAvailabilityRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<BranchAvailability> GetAll()
        {
            return FindAll().OrderBy(ow => ow.BranchAvailabilityId).ToList();
        }
        public BranchAvailability GetDataById(Guid Id)
        {
            return FindByCondition(client => client.BranchAvailabilityId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(BranchAvailability data)
        {
            Create(data);
        }
        public void UpdateRecord(BranchAvailability data)
        {
            Update(data);
        }
        public void DeleteRecord(BranchAvailability data)
        {
            Delete(data);
        }
    }
}
