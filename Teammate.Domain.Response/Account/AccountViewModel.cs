using Teammate.Domain.Models.Account;

namespace Teammate.Domain.ViewModel.Account
{
  public  class AccountViewModel
  {
    public bool Succeed { get; set; }
    public TokenModel TokenModel { get; set; }
    public string Message { get; set; }
  }
}
