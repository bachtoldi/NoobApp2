using NoobApp.Logic.Entities;

namespace NoobApp.Service.BindingModels {
  public class PurchaseBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public InventoryBindingModel Inventory { get; set; }
    public UserBindingModel User { get; set; }
    public int Amount { get; set; }

    #endregion

    #region - GetEntity -

    public Purchase GetEntity() {
      return new Purchase {
        Id = Id,
        InventoryRef = Inventory.GetEntity(),
        UserRef = User.GetEntity(),
        Amount = Amount
      };
    }

    #endregion

  }
}