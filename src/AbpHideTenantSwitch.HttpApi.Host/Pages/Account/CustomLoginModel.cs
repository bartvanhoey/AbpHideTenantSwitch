using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace AbpHideTenantSwitch.HttpApi.Host.Pages.Account
{
    public class CustomLoginModel : LoginModel
    {
        private readonly ITenantRepository _tenantRepository;

        public CustomLoginModel(IAuthenticationSchemeProvider schemeProvider, IOptions<AbpAccountOptions> accountOptions, IOptions<IdentityOptions> identityOptions, ITenantRepository tenantRepository, IdentityDynamicClaimsPrincipalContributorCache contributorCache)
        : base(schemeProvider, accountOptions, identityOptions, contributorCache)
        {
            _tenantRepository = tenantRepository;
        }

        public override async Task<IActionResult> OnPostAsync(string action)
        {
            var user = await FindUserAsync(LoginInput.UserNameOrEmailAddress);
            using (CurrentTenant.Change(user?.TenantId))
            {
                return await base.OnPostAsync(action);
            }
        }

        protected virtual async Task<IdentityUser> FindUserAsync(string uniqueUserNameOrEmailAddress)
        {
            IdentityUser user = null;
            using (CurrentTenant.Change(null))
            {
                user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
                       await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

                if (user != null)
                {
                    return user;
                }
            }

            foreach (var tenant in await _tenantRepository.GetListAsync())
            {
                using (CurrentTenant.Change(tenant.Id))
                {
                    user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
                           await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

                    if (user != null)
                    {
                        return user;
                    }
                }
            }
            return null;
        }
    }
}