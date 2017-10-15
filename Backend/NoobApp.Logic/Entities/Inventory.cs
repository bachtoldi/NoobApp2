namespace NoobApp.Logic.Entities {
  public class Inventory : BaseEntity {

    public virtual Event EventRef { get; set; }
    public virtual Item ItemRef { get; set; }
    public virtual float Price { get; set; }

  }
}
