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
  [RoutePrefix("Items")]
  public class ItemController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public ItemController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetItems() {
      Exception ex = null;
      LinkContainer<ItemViewModel> result = null;

      try {
        var items = _dataProvider.GetEntities<Item>().Select(x => new ItemViewModel(x)).ToList();
        result = new LinkContainer<ItemViewModel>(items);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Items"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "Items"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "Items/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetItem([FromUri] int id) {
      Exception ex = null;
      ItemViewModel result = null;

      try {
        var item = _dataProvider.GetEntity<Item>(id);
        result = new ItemViewModel(item);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Items/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "Items/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "Items/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateItem([FromBody] ItemBindingModel model) {
      Exception ex = null;

      try {
        var item = model.GetEntity();
        _dataProvider.SaveEntity<Item>(item);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateItem([FromUri] int id, [FromBody] ItemBindingModel model) {
      Exception ex = null;

      try {
        var item = model.GetEntity();
        _dataProvider.SaveEntity<Item>(item);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteItem([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<Item>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}