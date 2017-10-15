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
  [RoutePrefix("Inventories")]
  public class InventoryController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public InventoryController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetInventories() {
      Exception ex = null;
      LinkContainer<InventoryViewModel> result = null;

      try {
        var inventories = _dataProvider.GetEntities<Inventory>().Select(x => new InventoryViewModel(x)).ToList();
        result = new LinkContainer<InventoryViewModel>(inventories);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Inventories"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "Inventories"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "Inventories/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetInventory([FromUri] int id) {
      Exception ex = null;
      InventoryViewModel result = null;

      try {
        var inventory = _dataProvider.GetEntity<Inventory>(id);
        result = new InventoryViewModel(inventory);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Inventories/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "Inventories/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "Inventories/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateInventory([FromBody] InventoryBindingModel model) {
      Exception ex = null;

      try {
        var inventory = model.GetEntity();
        _dataProvider.SaveEntity<Inventory>(inventory);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateInventory([FromUri] int id, [FromBody] InventoryBindingModel model) {
      Exception ex = null;

      try {
        var inventory = model.GetEntity();
        _dataProvider.SaveEntity<Inventory>(inventory);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteInventory([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<Inventory>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}