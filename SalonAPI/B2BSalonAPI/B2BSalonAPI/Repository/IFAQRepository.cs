using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface IFAQRepository
    {
        FAQ GetDataById(Guid FAQId);
        void CreateRecord(FAQ fAQ);
        void UpdateRecord(FAQ fAQ);
        void DeleteRecord(FAQ fAQ);
    }
    public class FAQRepository : RepositoryBase<FAQ>, IFAQRepository
    {
        public FAQRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public FAQ GetDataById(Guid FAQId)
        {
            return FindByCondition(client => client.FAQId.Equals(FAQId)).FirstOrDefault();
        }
        public void CreateRecord(FAQ fAQ)
        {
            Create(fAQ);
        }
        public void UpdateRecord(FAQ fAQ)
        {
            Update(fAQ);
        }
        public void DeleteRecord(FAQ fAQ)
        {
            Delete(fAQ);
        }
    }
}
