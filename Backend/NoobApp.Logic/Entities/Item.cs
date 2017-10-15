namespace NoobApp.Logic.Entities {
  public class Item : BaseEntity {

    public virtual string Name { get; set; }
    public virtual byte[] Image { get; set; }

  }
}
