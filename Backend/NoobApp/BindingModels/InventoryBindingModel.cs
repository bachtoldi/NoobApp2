using NoobApp.Logic.Entities;

namespace NoobApp.Service.BindingModels {
  public class InventoryBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public EventBindingModel Event { get; set; }
    public ItemBindingModel Item { get; set; }
    public float Price { get; set; }

    #endregion

    #region - GetEntity -

    public Inventory GetEntity() {
      return new Inventory {
        Id = Id,
        EventRef = Event.GetEntity(),
        ItemRef = Item.GetEntity(),
        Price = Price
      };
    }

    #endregion

  }
}