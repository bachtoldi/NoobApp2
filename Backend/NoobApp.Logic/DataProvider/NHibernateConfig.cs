using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NoobApp.Logic.DataProvider {
  public partial class NHibernateConfig {

    public static ISessionFactory ConfigureHibernate() {
      Configuration cfg = new Configuration()
        .DataBaseIntegration(db => {
          db.ConnectionProvider<DriverConnectionProvider>();
          db.Driver<SqlClientDriver>();
          db.ConnectionString = ConnectionString.String;
          db.Dialect<MsSql2012Dialect>();
        });

      var fCfg = Fluently
        .Configure(cfg)
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConfig>());

      return fCfg.BuildSessionFactory();
    }

  }
}
