﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CmsFeature.Configuration.Dto;

namespace CmsFeature.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CmsFeatureAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
