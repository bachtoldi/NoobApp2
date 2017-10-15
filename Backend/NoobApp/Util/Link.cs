using System;
using System.Net.Http;

namespace NoobApp.Service.Util {
  public class Link {

    #region - Constructor -

    public Link(Uri requestUri, HttpMethod method, string relValue, string actionValue, string path, string query = "") {
      var uriBuilder = new UriBuilder() {
        Scheme = requestUri.Scheme,
        Host = requestUri.Host,
        Port = requestUri.Port,
        Path = path,
        Query = query,
      };

      RelValue = relValue;
      Method = method.Method;
      ActionValue = actionValue;
      Href = uriBuilder.Uri.AbsoluteUri;
    }

    #endregion

    #region - Properties -

    public string RelValue { get; set; }
    public string Method { get; set; }
    public string ActionValue { get; set; }

    public string Href { get; set; }

    #endregion

  }
}