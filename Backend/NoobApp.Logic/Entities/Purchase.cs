namespace NoobApp.Logic.Entities {
  public class Purchase : BaseEntity {

    public virtual Inventory InventoryRef { get; set; }
    public virtual User UserRef { get; set; }
    public virtual int Amount { get; set; }

  }
}
