using NoobApp.Logic.Entities;

namespace NoobApp.Service.BindingModels {
  public class ItemBindingModel {

    #region - Properties -

    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Image { get; set; }

    #endregion

    #region - GetEntity -

    public Item GetEntity() {
      return new Item {
        Id = Id,
        Name = Name,
        Image = Image
      };
    }

    #endregion

  }
}