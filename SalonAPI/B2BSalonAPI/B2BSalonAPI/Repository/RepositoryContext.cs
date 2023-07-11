using B2BSalonAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace B2BSalonAPI.Repository
{
    public class RepositoryContext:IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<SubscriptionData> SubscriptionDatas { get; set; }        
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchAvailability> BranchAvailabilities { get; set; }
        public DbSet<BranchEmployee> BranchEmployees { get; set; }
        public DbSet<BranchImage> BranchImages { get; set; }
        public DbSet<BranchSubscription> BranchSubscriptions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FAQ> FAQS { get; set; }
    }
}
