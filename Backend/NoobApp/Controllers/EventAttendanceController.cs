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
  [RoutePrefix("EventAttendances")]
  public class EventAttendanceController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public EventAttendanceController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetEventAttendances() {
      Exception ex = null;
      LinkContainer<EventAttendanceViewModel> result = null;

      try {
        var eventAttendance = _dataProvider.GetEntities<EventAttendance>().Select(x => new EventAttendanceViewModel(x)).ToList();
        result = new LinkContainer<EventAttendanceViewModel>(eventAttendance);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "EventAttendances"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "EventAttendances"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "EventAttendance/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetEventAttendance([FromUri] int id) {
      Exception ex = null;
      EventAttendanceViewModel result = null;

      try {
        var eventAttendance = _dataProvider.GetEntity<EventAttendance>(id);
        result = new EventAttendanceViewModel(eventAttendance);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "EventAttendances/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "EventAttendances/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "EventAttendances/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateEventAttendance([FromBody] EventAttendanceBindingModel model) {
      Exception ex = null;

      try {
        var eventAttendance = model.GetEntity();
        _dataProvider.SaveEntity<EventAttendance>(eventAttendance);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateEventAttendance([FromUri] int id, [FromBody] EventAttendanceBindingModel model) {
      Exception ex = null;

      try {
        var eventAttendance = model.GetEntity();
        _dataProvider.SaveEntity<EventAttendance>(eventAttendance);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteEventAttendance([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<EventAttendance>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}