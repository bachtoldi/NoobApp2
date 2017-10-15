using NoobApp.Logic.Entities;

namespace NoobApp.Service.BindingModels {
  public class UserBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    #endregion

    #region - GetEntity -

    public User GetEntity() {
      return new User {
        Id = Id,
        FirstName = FirstName,
        LastName = LastName,
        DisplayName = DisplayName
      };
    }

    #endregion

  }
}