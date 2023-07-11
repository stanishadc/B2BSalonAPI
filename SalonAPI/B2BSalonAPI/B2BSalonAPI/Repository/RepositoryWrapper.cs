namespace B2BSalonAPI.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
        private IFAQRepository _faq;
        public IFAQRepository FAQ
        {
            get
            {
                if (_faq == null)
                {
                    _faq = new FAQRepository(_repoContext);
                }
                return _faq;
            }
        }
        private ISubjectRepository _subject;
        public ISubjectRepository Subject
        {
            get
            {
                if (_subject == null)
                {
                    _subject = new SubjectRepository(_repoContext);
                }
                return _subject;
            }
        }
        private ISubscriptionDataRepository _subscriptionData;
        public ISubscriptionDataRepository SubscriptionData
        {
            get
            {
                if (_subscriptionData == null)
                {
                    _subscriptionData = new SubscriptionDataRepository(_repoContext);
                }
                return _subscriptionData;
            }
        }
        private ISubscriptionTypeRepository _subscriptionType;
        public ISubscriptionTypeRepository SubscriptionType
        {
            get
            {
                if (_subscriptionType == null)
                {
                    _subscriptionType = new SubscriptionTypeRepository(_repoContext);
                }
                return _subscriptionType;
            }
        }
        private IBranchRepository _branch;
        public IBranchRepository Branch
        {
            get
            {
                if (_branch == null)
                {
                    _branch = new BranchRepository(_repoContext);
                }
                return _branch;
            }
        }
        private ICategoryRepository _category;
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }
        private IBusinessRepository _business;
        public IBusinessRepository Business
        {
            get
            {
                if (_business == null)
                {
                    _business = new BusinessRepository(_repoContext);
                }
                return _business;
            }
        }
        private IBranchEmployeeRespository _branchEmployee;
        public IBranchEmployeeRespository BranchEmployee
        {
            get
            {
                if (_branchEmployee == null)
                {
                    _branchEmployee = new BranchEmployeeRespository(_repoContext);
                }
                return _branchEmployee;
            }
        }
        private IBranchAvailabilityRepository _branchAvailability;
        public IBranchAvailabilityRepository BranchAvailability
        {
            get
            {
                if (_branchAvailability == null)
                {
                    _branchAvailability = new BranchAvailabilityRepository(_repoContext);
                }
                return _branchAvailability;
            }
        }
        private IServiceRepository _service;
        public IServiceRepository Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new ServiceRepository(_repoContext);
                }
                return _service;
            }
        }
        private IBranchSubscriptionRespository _branchSubscription;
        public IBranchSubscriptionRespository BranchSubscription
        {
            get
            {
                if (_branchSubscription == null)
                {
                    _branchSubscription = new BranchSubscriptionRespository(_repoContext);
                }
                return _branchSubscription;
            }
        }
    }
}
