using Abp.Domain.Services;
using CmsFeature.CmsNamespace;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public interface ICmsManager : IDomainService
    {
        Task<Cms> GetAsync(int id);

        Task InsertOrUpdateAsync(Cms cms);
    }
}