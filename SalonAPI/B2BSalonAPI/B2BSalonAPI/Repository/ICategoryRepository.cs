using B2BSalonAPI.Models;

namespace B2BSalonAPI.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetDataById(Guid Id);
        void CreateRecord(Category data);
        void UpdateRecord(Category data);
        void DeleteRecord(Category data);
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Category> GetAll()
        {
            return FindAll()
                .OrderBy(ow => ow.CreatedDate)
                .ToList();
        }
        public Category GetDataById(Guid Id)
        {
            return FindByCondition(client => client.CategoryId.Equals(Id)).FirstOrDefault();
        }
        public void CreateRecord(Category data)
        {
            Create(data);
        }
        public void UpdateRecord(Category data)
        {
            Update(data);
        }
        public void DeleteRecord(Category data)
        {
            Delete(data);
        }
    }
}
