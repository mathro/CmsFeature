using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CmsFeature.Controllers
{
    public abstract class CmsFeatureControllerBase: AbpController
    {
        protected CmsFeatureControllerBase()
        {
            LocalizationSourceName = CmsFeatureConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
