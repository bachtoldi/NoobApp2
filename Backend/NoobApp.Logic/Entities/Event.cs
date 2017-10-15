using System;

namespace NoobApp.Logic.Entities {
  public class Event : BaseEntity {

    public virtual string Name { get; set; }
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime EndDate { get; set; }

  }
}
