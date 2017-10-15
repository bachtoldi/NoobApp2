using System.Collections.Generic;

namespace NoobApp.Service.Util {
  public class LinkViewModel {

    #region - Constructor -

    public LinkViewModel() {
      _links = new List<Link>();
    }

    #endregion

    #region - Properties -

    private IList<Link> _links { get; set; }
    public IList<Link> Links {
      get {
        return _links;
      }
    }

    #endregion

    #region - Public Methods -

    public void AddLink(Link link) {
      _links.Add(link);
    }

    #endregion

  }
}