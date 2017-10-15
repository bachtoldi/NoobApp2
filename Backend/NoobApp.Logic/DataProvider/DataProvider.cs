using NoobApp.Logic.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NoobApp.Logic.DataProvider {
  public class DataProvider {

    public T GetEntity<T>(int id) where T : BaseEntity {
      var session = SessionFactory.Session;

      using (var transaction = session.BeginTransaction()) {
        var entity = session.Get<T>(id);
        transaction.Commit();
        session.Close();
        return entity;
      }
    }

    public IList<T> GetEntities<T>() where T : BaseEntity {
      var session = SessionFactory.Session;

      using (var transaction = session.BeginTransaction()) {
        var list = session.QueryOver<T>().List().ToList();
        transaction.Commit();
        session.Close();
        return list;
      }
    }

    public void SaveEntity<T>(T entity) where T : BaseEntity {
      var session = SessionFactory.Session;

      using (var transaction = session.BeginTransaction()) {
        session.SaveOrUpdate(entity);
        transaction.Commit();
        session.Close();
      }
    }

    public void DeleteEntity<T>(int id) where T : BaseEntity {
      var session = SessionFactory.Session;

      using (var transaction = session.BeginTransaction()) {
        var entity = GetEntity<T>(id);
        session.Delete(entity);
        transaction.Commit();
        session.Close();
      }
    }

  }
}
