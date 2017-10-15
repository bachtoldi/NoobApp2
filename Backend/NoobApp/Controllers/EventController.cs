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
  [RoutePrefix("Events")]
  public class EventController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public EventController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetEvents() {
      Exception ex = null;
      LinkContainer<EventViewModel> result = null;

      try {
        var events = _dataProvider.GetEntities<Event>().Select(x => new EventViewModel(x)).ToList();
        result = new LinkContainer<EventViewModel>(events);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Events"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "Events"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "Events/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetEvent([FromUri] int id) {
      Exception ex = null;
      EventViewModel result = null;

      try {
        var e = _dataProvider.GetEntity<Event>(id);
        result = new EventViewModel(e);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Events/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "Events/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "Events/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateEvent([FromBody] EventBindingModel model) {
      Exception ex = null;

      try {
        var e = model.GetEntity();
        _dataProvider.SaveEntity<Event>(e);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateEvent([FromUri] int id, [FromBody] EventBindingModel model) {
      Exception ex = null;

      try {
        var e = model.GetEntity();
        _dataProvider.SaveEntity<Event>(e);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteEvent([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<Event>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}