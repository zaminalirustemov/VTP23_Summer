using Microsoft.AspNetCore.Identity;
using Participant_Panel.Entites.Domains;

namespace Participant_Panel.UI.Services
{
    public class MemberLayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public MemberLayoutService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<AppUser> GetUser()
        {
            string name = _httpContextAccessor.HttpContext.User.Identity.Name;
            AppUser appUser = await _userManager.FindByNameAsync(name);
            return appUser;
        }
    }
}
