using System.Collections.Generic;

namespace NoobApp.Service.Util {
  public class LinkContainer<T> : LinkViewModel where T : class {

    #region - Constructor -

    public LinkContainer() {
      Items = new List<T>();
    }

    public LinkContainer(IList<T> items) {
      Items = items;
    }

    #endregion

    #region - Properties -

    public IList<T> Items { get; set; }

    #endregion

  }
}