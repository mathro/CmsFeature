using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CmsFeature.Roles.Dto;
using CmsFeature.Users.Dto;

namespace CmsFeature.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
