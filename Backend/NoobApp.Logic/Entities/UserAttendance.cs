namespace NoobApp.Logic.Entities {
  public class UserAttendance : BaseEntity {

    public virtual EventAttendance EventAttendanceRef { get; set; }
    public virtual User UserRef { get; set; }

  }
}
