using Abp.Zero.EntityFrameworkCore;
using CmsFeature.Authorization.Roles;
using CmsFeature.Authorization.Users;
using CmsFeature.CmsNamespace;
using CmsFeature.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace CmsFeature.EntityFrameworkCore
{
    public class CmsFeatureDbContext : AbpZeroDbContext<Tenant, Role, User, CmsFeatureDbContext>
    {
        public virtual DbSet<Cms> Cmss { get; set; }

        public CmsFeatureDbContext(DbContextOptions<CmsFeatureDbContext> options)
            : base(options)
        {
        }
    }
}
