using System;

namespace NoobApp.Logic.DataProvider {
  public static class ConnectionString {
    public static string String = "Server=" + Environment.MachineName + "\\SQLEXPRESS; Initial Catalog=NoobApp; Integrated Security=True;";
  }
}
