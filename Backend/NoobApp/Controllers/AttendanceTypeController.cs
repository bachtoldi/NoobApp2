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
  [RoutePrefix("AttendanceTypes")]
  public class AttendanceTypeController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public AttendanceTypeController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetAttendanceTypes() {
      Exception ex = null;
      LinkContainer<AttendanceTypeViewModel> result = null;

      try {
        var attendanceTypes = _dataProvider.GetEntities<AttendanceType>().Select(x => new AttendanceTypeViewModel(x)).ToList();
        result = new LinkContainer<AttendanceTypeViewModel>(attendanceTypes);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "AttendanceTypes"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "AttendanceTypes"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "AttendanceTypes/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetAttendanceType([FromUri] int id) {
      Exception ex = null;
      AttendanceTypeViewModel result = null;

      try {
        var attendanceType = _dataProvider.GetEntity<AttendanceType>(id);
        result = new AttendanceTypeViewModel(attendanceType);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "AttendanceTypes/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "AttendanceTypes/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "AttendanceTypes/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateAttendanceType([FromBody] AttendanceTypeBindingModel model) {
      Exception ex = null;

      try {
        var attendanceType = model.GetEntity();
        _dataProvider.SaveEntity(attendanceType);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateAttendanceType([FromUri] int id, [FromBody] AttendanceTypeBindingModel model) {
      Exception ex = null;

      try {
        var attendanceType = model.GetEntity();
        _dataProvider.SaveEntity(attendanceType);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteAttendanceType([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<AttendanceType>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}