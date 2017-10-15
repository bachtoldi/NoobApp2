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
  [RoutePrefix("Users")]
  public class UserController : BaseController {

    #region - Instance Variables -

    private readonly DataProvider _dataProvider;

    #endregion

    #region - Constructor -

    public UserController() {
      _dataProvider = new DataProvider();
    }

    #endregion

    #region - API -

    [HttpGet]
    [Route("")]
    public IHttpActionResult GetUsers() {
      Exception ex = null;
      LinkContainer<UserViewModel> result = null;

      try {
        var users = _dataProvider.GetEntities<User>().Select(x => new UserViewModel(x)).ToList();
        result = new LinkContainer<UserViewModel>(users);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Users"));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Post, RelValues.Child, ActionValues.Save, "Users"));

        foreach (var item in result.Items) {
          item.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Load, "Users/" + item.Id));
        }
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult GetUser([FromUri] int id) {
      Exception ex = null;
      UserViewModel result = null;

      try {
        var user = _dataProvider.GetEntity<User>(id);
        result = new UserViewModel(user);

        result.AddLink(new Link(Request.RequestUri, HttpMethod.Get, RelValues.Self, ActionValues.Refresh, "Users/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Put, RelValues.Self, ActionValues.Save, "Users/" + id));
        result.AddLink(new Link(Request.RequestUri, HttpMethod.Delete, RelValues.Self, ActionValues.Delete, "Users/" + id));
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(result, ex);
    }

    [HttpPost]
    [Route("")]
    public IHttpActionResult CreateUser([FromBody] UserBindingModel model) {
      Exception ex = null;

      try {
        var user = model.GetEntity();
        _dataProvider.SaveEntity<User>(user);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IHttpActionResult UpdateUser([FromUri] int id, [FromBody] UserBindingModel model) {
      Exception ex = null;

      try {
        var user = model.GetEntity();
        _dataProvider.SaveEntity<User>(user);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IHttpActionResult DeleteUser([FromUri] int id) {
      Exception ex = null;

      try {
        _dataProvider.DeleteEntity<User>(id);
      } catch (Exception e) {
        ex = e;
      }

      return GetHttpActionResult(ex);
    }

    #endregion

  }
}