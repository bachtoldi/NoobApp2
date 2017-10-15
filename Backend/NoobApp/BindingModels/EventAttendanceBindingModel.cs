using NoobApp.Logic.Entities;

namespace NoobApp.Service.BindingModels {
  public class EventAttendanceBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public EventBindingModel Event { get; set; }
    public AttendanceTypeBindingModel AttendanceType { get; set; }
    public float Price { get; set; }

    #endregion

    #region - GetEntity -

    public EventAttendance GetEntity() {
      return new EventAttendance {
        Id = Id,
        EventRef = Event.GetEntity(),
        AttendanceTypeRef = AttendanceType.GetEntity(),
        Price = Price
      };
    }

    #endregion

  }
}