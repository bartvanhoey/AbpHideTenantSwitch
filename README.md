# AbpHideTenantSwitchRepo

A step-by-step guide to hide the tenant switch of an ABP Framework login page.


1) LoginPage.HttpApi.Host.csproj
<!-- <PackageReference Include="Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic" Version="4.4.3" /> -->
2) Copy module Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic in your project
3) Add Reference to Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic 	
   dotnet add reference ../../src/Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic/Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.csproj
4) comment out and replace
	<!-- <Import Project="..\..\..\..\configureawait.props" /> -->
	<Import Project="..\..\common.props" />
5) comment out in Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.csproj
  <!-- <ItemGroup>
    <ProjectReference Include="..\..\..\..\framework\src\Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy\Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy.csproj" />
    <ProjectReference Include="..\..\..\..\framework\src\Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared\Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.csproj" />
  </ItemGroup> -->
 
6) change Target DOTNET framework
<!-- <TargetFramework>net6.0</TargetFramework> -->
    <TargetFramework>net5.0</TargetFramework> 
  
7) Comment out or delete

   <!-- <ItemGroup>
    <ProjectReference Include="..\..\..\..\framework\src\Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy\Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy.csproj" />
    <ProjectReference Include="..\..\..\..\framework\src\Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared\Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.csproj" />
  </ItemGroup> -->
  
  
8) Add packages in Theme.Basic Project
   abp add-package Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy
   abp add-package Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared
 
9) dotnet build Theme.Basic Project
 

10) Goto Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic\Themes\Basic\Themes\Basic\Layouts\Account.cshtml
Comment out if statement below

           @* @if (MultiTenancyOptions.Value.IsEnabled &&
                  (TenantResolveResultAccessor.Result?.AppliedResolvers?.Contains(CookieTenantResolveContributor.ContributorName) == true ||
                   TenantResolveResultAccessor.Result?.AppliedResolvers?.Contains(QueryStringTenantResolveContributor.ContributorName) == true))
                {
                    <div class="card shadow-sm rounded mb-3">
                        <div class="card-body px-5">
                            <div class="row">
                                <div class="col">
                                    <span style="font-size: .8em;" class="text-uppercase text-muted">@MultiTenancyStringLocalizer["Tenant"]</span><br />
                                    <h6 class="m-0 d-inline-block">
                                        @if (CurrentTenant.Id == null)
                                        {
                                            <span>
                                                @MultiTenancyStringLocalizer["NotSelected"]
                                            </span>
                                        }
                                        else
                                        {
                                            <strong>@(CurrentTenant.Name ?? CurrentTenant.Id.Value.ToString())</strong>
                                        }
                                    </h6>
                                </div>
                                <div class="col-auto">
                                    <a id="AbpTenantSwitchLink" href="javascript:;" class="btn btn-sm mt-3 btn-outline-primary">@MultiTenancyStringLocalizer["Switch"]</a>
                                </div>
                            </div>
                        </div>
                    </div>
                }


11) Add in HttpApiHostModule method below right under the ConfigureServices method

// import using statements
private void ConfigureTenantResolver(ServiceConfigurationContext context, IConfiguration configuration)
{
	Configure<AbpTenantResolveOptions>(options =>
		 {
			 options.TenantResolvers.Clear();
			 options.TenantResolvers.Add(new CurrentUserTenantResolveContributor());
		 });
}

12) Call method CookieTenantResolveContributor from the ConfigureServices method

public override void ConfigureServices(ServiceConfigurationContext context)
{
 // other code here ...	
 
  ConfigureTenantResolver(context, configuration);
}


13) add Pages/Account folder to HttpApi.Host project
14) add class CustomLoginModel to Account folder

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.TenantManagement;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace YourProjectName.HttpApi.Host.Pages.Account
{
    public class CustomLoginModel : LoginModel
    {
        private readonly ITenantRepository _tenantRepository;

        public CustomLoginModel(IAuthenticationSchemeProvider schemeProvider, IOptions<AbpAccountOptions> accountOptions, IOptions<IdentityOptions> identityOptions, ITenantRepository tenantRepository) : base(schemeProvider, accountOptions, identityOptions)
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


12) add Login.cshtml file to Account folder

13)add a file login.css to the wwwroot folder of the HttpApi.Host project.

.abp-background {
    background-color:  red !important;
}

14) Open file AbpBlazorCustomizeLoginPageHttpApiHostModule.cs and update the ConfigureBundles() method.private void ConfigureBundles()
   {
     Configure<AbpBundlingOptions>(options =>
     {
       options.StyleBundles.Configure(
                 BasicThemeBundles.Styles.Global,
                 bundle =>
             {
               bundle.AddFiles("/global-styles.css");
               bundle.AddFiles("/login.css");
             }
             );
     });
   }