using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class UserAttendanceViewModel : LinkViewModel {

    #region - Constructor -

    public UserAttendanceViewModel(UserAttendance userAttendance) {
      Id = userAttendance.Id;
      EventAttendance = new EventAttendanceViewModel(userAttendance.EventAttendanceRef);
      User = new UserViewModel(userAttendance.UserRef);
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public EventAttendanceViewModel EventAttendance { get; set; }
    public UserViewModel User { get; set; }

    #endregion

  }
}