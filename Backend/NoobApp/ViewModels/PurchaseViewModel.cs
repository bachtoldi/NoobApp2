using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class PurchaseViewModel : LinkViewModel {

    #region - Constructor -

    public PurchaseViewModel(Purchase purchase) {
      Id = purchase.Id;
      Inventory = new InventoryViewModel(purchase.InventoryRef);
      User = new UserViewModel(purchase.UserRef);
      Amount = purchase.Amount;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public InventoryViewModel Inventory { get; set; }
    public UserViewModel User { get; set; }
    public int Amount { get; set; }

    #endregion

  }
}