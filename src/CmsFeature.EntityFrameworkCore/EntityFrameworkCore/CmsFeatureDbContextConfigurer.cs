using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CmsFeature.EntityFrameworkCore
{
    public static class CmsFeatureDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CmsFeatureDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CmsFeatureDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
