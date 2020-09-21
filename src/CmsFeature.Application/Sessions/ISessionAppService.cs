using System.Threading.Tasks;
using Abp.Application.Services;
using CmsFeature.Sessions.Dto;

namespace CmsFeature.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
