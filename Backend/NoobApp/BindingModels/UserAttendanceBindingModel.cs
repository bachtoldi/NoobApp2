using NoobApp.Logic.Entities;

namespace NoobApp.Service.BindingModels {
  public class UserAttendanceBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public EventAttendanceBindingModel EventAttendance { get; set; }
    public UserBindingModel User { get; set; }

    #endregion

    #region - GetEntity -

    public UserAttendance GetEntity() {
      return new UserAttendance {
        Id = Id,
        EventAttendanceRef = EventAttendance.GetEntity(),
        UserRef = User.GetEntity()
      };
    }

    #endregion

  }
}