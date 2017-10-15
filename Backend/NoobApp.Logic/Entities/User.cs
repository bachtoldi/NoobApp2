namespace NoobApp.Logic.Entities {
  public class User : BaseEntity {

    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string DisplayName { get; set; }

  }
}
