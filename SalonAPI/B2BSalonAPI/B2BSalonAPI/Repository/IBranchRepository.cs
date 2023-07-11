using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetAll();
        Branch GetDataById(Guid Id);
        void CreateRecord(Branch data);
        void UpdateRecord(Branch data);
        void DeleteRecord(Branch data);
    }
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Branch> GetAll()
        {
            return FindAll()
                .OrderBy(ow => ow.CreatedDate)
                .ToList();
        }
        public Branch GetDataById(Guid Id)
        {
            return FindByCondition(client => client.BranchId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(Branch data)
        {
            Create(data);
        }
        public void UpdateRecord(Branch data)
        {
            Update(data);
        }
        public void DeleteRecord(Branch data)
        {
            Delete(data);
        }
    }
}
