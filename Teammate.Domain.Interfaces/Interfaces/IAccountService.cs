using Teammate.Domain.Models.Account;
using Teammate.Domain.ViewModel.Account;

namespace Teammate.Domain.Services.Interfaces;

public interface IAccountService
{
  public Task<AccountViewModel> LoginAsync(LoginModel loginModel);
  public Task<bool> LogoutAsync(string username);
  public Task<AccountViewModel> RegisterAsync(RegisterModel registerModel);
  public Task<AccountViewModel> RegisterAdminAsync(RegisterModel registerModel);
  public Task<AccountViewModel> RefreshTokenAsync(TokenModel tokenModel);

}
