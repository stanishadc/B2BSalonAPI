using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IBusinessRepository
    {
        IEnumerable<Business> GetAll();
        Business GetDataById(Guid Id);
        void CreateRecord(Business data);
        void UpdateRecord(Business data);
        void DeleteRecord(Business data);
    }
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        public BusinessRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Business> GetAll()
        {
            return FindAll().OrderBy(ow => ow.BusinessId).ToList();
        }
        public Business GetDataById(Guid Id)
        {
            return FindByCondition(client => client.BusinessId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(Business data)
        {
            Create(data);
        }
        public void UpdateRecord(Business data)
        {
            Update(data);
        }
        public void DeleteRecord(Business data)
        {
            Delete(data);
        }
    }
}


