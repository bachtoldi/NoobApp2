using NoobApp.Logic.Entities;
using System;

namespace NoobApp.Service.BindingModels {
  public class EventBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    #endregion

    #region - GetEntity -

    public Event GetEntity() {
      return new Event {
        Id = Id,
        Name = Name,
        StartDate = StartDate,
        EndDate = EndDate
      };
    }

    #endregion

  }
}