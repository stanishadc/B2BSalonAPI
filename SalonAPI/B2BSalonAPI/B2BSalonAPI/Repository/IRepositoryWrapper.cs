namespace B2BSalonAPI.Repository
{
    public interface IRepositoryWrapper
    {
        IFAQRepository FAQ { get; }
        IBranchRepository Branch { get; }
        IBranchAvailabilityRepository BranchAvailability { get; }
        IBranchEmployeeRespository BranchEmployee { get; }
        IBusinessRepository Business { get; }
        ICategoryRepository Category { get; }
        ISubjectRepository Subject { get; }
        ISubscriptionDataRepository SubscriptionData { get; }
        ISubscriptionTypeRepository SubscriptionType { get; }
        IBranchSubscriptionRespository BranchSubscription { get; }
        IServiceRepository Service { get; }
        void Save();
    }
}