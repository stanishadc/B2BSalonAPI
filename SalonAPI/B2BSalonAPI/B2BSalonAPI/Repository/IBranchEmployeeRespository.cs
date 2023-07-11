using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IBranchEmployeeRespository
    {
        IEnumerable<BranchEmployee> GetAll();
        BranchEmployee GetDataById(Guid Id);
        void CreateRecord(BranchEmployee data);
        void UpdateRecord(BranchEmployee data);
        void DeleteRecord(BranchEmployee data);
    }
    public class BranchEmployeeRespository : RepositoryBase<BranchEmployee>, IBranchEmployeeRespository
    {
        public BranchEmployeeRespository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<BranchEmployee> GetAll()
        {
            return FindAll().OrderBy(ow => ow.BranchEmployeeId).ToList();
        }
        public BranchEmployee GetDataById(Guid Id)
        {
            return FindByCondition(client => client.BranchEmployeeId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(BranchEmployee data)
        {
            Create(data);
        }
        public void UpdateRecord(BranchEmployee data)
        {
            Update(data);
        }
        public void DeleteRecord(BranchEmployee data)
        {
            Delete(data);
        }
    }
}
