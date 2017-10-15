using NoobApp.Logic.Entities;
using NoobApp.Service.Util;
using System;

namespace NoobApp.Service.ViewModels {
  public class EventViewModel : LinkViewModel {

    #region - Constructor -

    public EventViewModel(Event e) {
      Id = e.Id;
      Name = e.Name;
      StartDate = e.StartDate;
      EndDate = e.EndDate;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    #endregion

  }
}