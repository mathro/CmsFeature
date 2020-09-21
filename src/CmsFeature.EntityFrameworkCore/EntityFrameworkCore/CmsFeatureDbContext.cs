using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CmsFeature.Authorization.Roles;
using CmsFeature.Authorization.Users;
using CmsFeature.MultiTenancy;

namespace CmsFeature.EntityFrameworkCore
{
    public class CmsFeatureDbContext : AbpZeroDbContext<Tenant, Role, User, CmsFeatureDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CmsFeatureDbContext(DbContextOptions<CmsFeatureDbContext> options)
            : base(options)
        {
        }
    }
}
