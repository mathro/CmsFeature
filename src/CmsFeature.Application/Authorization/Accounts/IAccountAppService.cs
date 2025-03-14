﻿using System.Threading.Tasks;
using Abp.Application.Services;
using CmsFeature.Authorization.Accounts.Dto;

namespace CmsFeature.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
