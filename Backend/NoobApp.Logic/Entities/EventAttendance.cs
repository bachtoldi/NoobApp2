namespace NoobApp.Logic.Entities {
  public class EventAttendance : BaseEntity {

    public virtual Event EventRef { get; set; }
    public virtual AttendanceType AttendanceTypeRef { get; set; }
    public virtual float Price { get; set; }

  }
}
