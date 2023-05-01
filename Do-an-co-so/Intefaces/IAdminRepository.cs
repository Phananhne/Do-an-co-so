using Do_an_co_so.Models;
namespace Do_an_co_so.Intefaces
{
    public interface IAdminRepository
    {
        public CookieUserItem Validate(LoginViewModel model);
        public Task<bool> HaveAccount(ForgotViewModel model);
        public Task<bool> HaveAccount(string userName, string password);
        public Task ResetPassWord(ResetViewModel model);
        public string CreateResetPasswordLink(string adminUserName);
        public Task ChangePasswordUser(ChangePasswordViewModel model, int id);
    }
}
