using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class InventoryViewModel : LinkViewModel {

    #region - Constructor -

    public InventoryViewModel(Inventory inventory) {
      Id = inventory.Id;
      Event = new EventViewModel(inventory.EventRef);
      Item = new ItemViewModel(inventory.ItemRef);
      Price = inventory.Price;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public EventViewModel Event { get; set; }
    public ItemViewModel Item { get; set; }
    public float Price { get; set; }

    #endregion

  }
}