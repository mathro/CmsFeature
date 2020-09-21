using System.Threading.Tasks;
using CmsFeature.Configuration.Dto;

namespace CmsFeature.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
