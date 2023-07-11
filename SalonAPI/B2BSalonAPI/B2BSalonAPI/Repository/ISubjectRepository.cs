using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject GetDataById(Guid Id);
        void CreateRecord(Subject data);
        void UpdateRecord(Subject data);
        void DeleteRecord(Subject data);
    }
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Subject> GetAll()
        {
            return FindAll().OrderBy(ow => ow.SubjectId).ToList();
        }
        public Subject GetDataById(Guid Id)
        {
            return FindByCondition(client => client.SubjectId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(Subject data)
        {
            Create(data);
        }
        public void UpdateRecord(Subject data)
        {
            Update(data);
        }
        public void DeleteRecord(Subject data)
        {
            Delete(data);
        }
    }
}

