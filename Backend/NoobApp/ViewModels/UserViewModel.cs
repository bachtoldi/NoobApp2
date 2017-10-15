using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class UserViewModel : LinkViewModel {

    #region - Constructor -

    public UserViewModel(User user) {
      Id = user.Id;
      FirstName = user.FirstName;
      LastName = user.LastName;
      DisplayName = user.DisplayName;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    #endregion

  }
}