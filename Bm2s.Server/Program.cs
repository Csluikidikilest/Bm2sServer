using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;

namespace Bm2s.Server
{
  class Program
  {
    static int Main(string[] args)
    {
      IOrmLiteDialectProvider provider = null;

      switch (ConfigurationManager.AppSettings["DbProvider"].ToLower())
      {
        case "postgresql":
          provider = PostgreSqlDialect.Provider;
          break;
        default:
          provider = null;
          break;

      }

      if(provider == null)
      {
        return -1;
      }

      var dbFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["bm2s"].ConnectionString,provider);

      IDbConnection dbConnexion = dbFactory.OpenDbConnection();
      IDbCommand dbCommand = dbConnexion.CreateCommand();

      dbCommand.CreateTable<Bm2s.Data.BLL.Parameter.Unit>()

      return 0;
    }
  }
}
