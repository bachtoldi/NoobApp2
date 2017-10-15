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
  [RoutePrefix("UserAttendances")]
  public class UserAttendanceController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public UserAttendanceController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetUserAttendances() {
      Exception ex = null;
      LinkContainer<UserAttendanceViewModel> result = null;

      try {
        var userAttendances = _dataProvider.GetEntities<UserAttendance>().Select(x => new UserAttendanceViewModel(x)).ToList();
        result = new LinkContainer<UserAttendanceViewModel>(userAttendances);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "UserAttendances"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "UserAttendances"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "UserAttendances/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetUserAttendance([FromUri] int id) {
      Exception ex = null;
      UserAttendanceViewModel result = null;

      try {
        var userAttendance = _dataProvider.GetEntity<UserAttendance>(id);
        result = new UserAttendanceViewModel(userAttendance);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "UserAttendances/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "UserAttendances/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "UserAttendances/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateUserAttendance([FromBody] UserAttendanceBindingModel model) {
      Exception ex = null;

      try {
        var userAttendance = model.GetEntity();
        _dataProvider.SaveEntity<UserAttendance>(userAttendance);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateUserAttendance([FromUri] int id, [FromBody] UserAttendanceBindingModel model) {
      Exception ex = null;

      try {
        var userAttendance = model.GetEntity();
        _dataProvider.SaveEntity<UserAttendance>(userAttendance);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteUserAttendance([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<UserAttendance>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}