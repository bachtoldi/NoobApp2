using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class EventAttendanceViewModel : LinkViewModel {

    #region - Constructor -

    public EventAttendanceViewModel(EventAttendance eventAttendance) {
      Id = eventAttendance.Id;
      Event = new EventViewModel(eventAttendance.EventRef);
      AttendanceType = new AttendanceTypeViewModel(eventAttendance.AttendanceTypeRef);
      Price = eventAttendance.Price;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public EventViewModel Event { get; set; }
    public AttendanceTypeViewModel AttendanceType { get; set; }
    public float Price { get; set; }

    #endregion

  }
}