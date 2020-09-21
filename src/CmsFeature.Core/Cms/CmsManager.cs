using Abp.Domain.Repositories;
using Abp.UI;
using EventCloud.Events;
using System.Threading.Tasks;

namespace CmsFeature.CmsNamespace
{
    public class CmsManager : ICmsManager
    {
        private readonly IRepository<Cms> _cmsRepository;

        public CmsManager(IRepository<Cms> cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public async Task<Cms> GetAsync(int id)
        {
            var cms = await _cmsRepository.FirstOrDefaultAsync(id);
            if (cms == null)
            {
                throw new UserFriendlyException("Could not found the cms content, maybe it's deleted!");
            }

            return cms;
        }

        public async Task InsertOrUpdateAsync(Cms cms)
        {
            if (cms.Id == 0)
                await _cmsRepository.InsertAsync(cms);
            else
                await _cmsRepository.UpdateAsync(cms);
        }
    }
}
