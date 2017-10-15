using NoobApp.Logic.Entities;
using NoobApp.Service.Util;

namespace NoobApp.Service.ViewModels {
  public class ItemViewModel : LinkViewModel {

    #region - Constructor -

    public ItemViewModel(Item item) {
      Id = item.Id;
      Name = item.Name;
      Image = item.Image;
    }

    #endregion

    #region - Properties -

    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Image { get; set; }

    #endregion

  }
}