using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        Service GetDataById(Guid Id);
        void CreateRecord(Service data);
        void UpdateRecord(Service data);
        void DeleteRecord(Service data);
    }
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Service> GetAll()
        {
            return FindAll()
                .OrderBy(ow => ow.CreatedDate)
                .ToList();
        }
        public Service GetDataById(Guid Id)
        {
            return FindByCondition(client => client.ServiceId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(Service data)
        {
            Create(data);
        }
        public void UpdateRecord(Service data)
        {
            Update(data);
        }
        public void DeleteRecord(Service data)
        {
            Delete(data);
        }
    }
}

