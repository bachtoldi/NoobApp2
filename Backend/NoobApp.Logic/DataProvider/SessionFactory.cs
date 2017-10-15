using NHibernate;

namespace NoobApp.Logic.DataProvider {
  public static class SessionFactory {

    private static ISessionFactory _sessionFactory;

    static SessionFactory() {
      _sessionFactory = NHibernateConfig.ConfigureHibernate();
    }

    public static ISession Session {
      get {
        return _sessionFactory.OpenSession();
      }
    }

  }
}
