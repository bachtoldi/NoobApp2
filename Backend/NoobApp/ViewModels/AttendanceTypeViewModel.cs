using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class AttendanceTypeViewModel : LinkViewModel {

    #region - Constructor -

    public AttendanceTypeViewModel(AttendanceType attendanceType) {
      Id = attendanceType.Id;
      Name = attendanceType.Name;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public string Name { get; set; }

    #endregion

  }
}