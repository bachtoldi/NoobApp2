using NoobApp.Logic.DataProvider;
using NoobApp.Logic.Entities;
using NoobApp.Service.BindingModels;
using NoobApp.Service.Util;
using NoobApp.Service.ViewModels;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace NoobApp.Service.Controllers {
  [RoutePrefix("Purchases")]
  public class PurchaseController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public PurchaseController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetPurchases() {
      Exception ex = null;
      LinkContainer<PurchaseViewModel> result = null;

      try {
        var purchases = _dataProvider.GetEntities<Purchase>().Select(x => new PurchaseViewModel(x)).ToList();
        result = new LinkContainer<PurchaseViewModel>(purchases);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Purchases"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "Purchases"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "Purchases/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetPurchase([FromUri] int id) {
      Exception ex = null;
      PurchaseViewModel result = null;

      try {
        var purchase = _dataProvider.GetEntity<Purchase>(id);
        result = new PurchaseViewModel(purchase);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Purchases/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "Purchases/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "Purchases/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreatePurchase([FromBody] PurchaseBindingModel model) {
      Exception ex = null;

      try {
        var purchase = model.GetEntity();
        _dataProvider.SaveEntity<Purchase>(purchase);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdatePurchase([FromUri] int id, [FromBody] PurchaseBindingModel model) {
      Exception ex = null;

      try {
        var purchase = model.GetEntity();
        _dataProvider.SaveEntity<Purchase>(purchase);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeletePurchase([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<Purchase>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}