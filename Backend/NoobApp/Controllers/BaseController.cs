using NoobApp.Service.Util;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoobApp.Service.Controllers {
  [AllowAnonymous]
  [RoutePrefix("")]
  public class BaseController : ApiController {

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetLinks() {
      Exception ex = null;
      LinkViewModel result = null;

      try {
        result = new LinkViewModel();
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadAttendanceTypes", "AttendanceTypes"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadEventAttendances", "EventAttendances"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadEvents", "Events"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadInventories", "Inventories"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadItems", "Items"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadPurchases", "Purchases"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadUserAttendances", "UserAttendances"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Child, "loadUsers", "Users"));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    #endregion

    #region - Private Methods -

    protected IHttpActionResult GetHttpActionResult(object result, Exception ex) {

      if (result != null && ex == null) {
        return Ok(result);
      }

      if (ex != null) {
        return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
      }

      if (result == null && ex == null) {
        return NotFound();
      }

      return InternalServerError();

    }

    protected IHttpActionResult GetHttpActionResult(Exception ex) {

      if (ex != null) {
        return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
      }

      if (ex == null) {
        return Ok();
      }

      return InternalServerError();

    }

    #endregion

  }
}
