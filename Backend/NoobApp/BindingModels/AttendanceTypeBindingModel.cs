using NoobApp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoobApp.Service.BindingModels {
  public class AttendanceTypeBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public string Name { get; set; }

    #endregion

    #region - GetEntity -

    public AttendanceType GetEntity() {
      return new AttendanceType {
        Id = Id,
        Name = Name
      };
    }

    #endregion

  }
}