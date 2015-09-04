using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;

namespace Bm2s.Data.Utils
{
  /// <summary>
  /// Data access point
  /// </summary>
  public class Datas
  {
    /// <summary>
    /// Database provider
    /// </summary>
    private IOrmLiteDialectProvider _dbProvider;

    /// <summary>
    /// Gets the database provider
    /// </summary>
    public IOrmLiteDialectProvider DbProvider
    {
      get
      {
        if (this._dbProvider == null)
        {
          switch (ConfigurationManager.AppSettings["DbProvider"].ToLower())
          {
            case "oracle":
              this._dbProvider = OracleDialect.Provider;
              break;
            case "mysql" :
              this._dbProvider = MySqlDialect.Provider;
              break;
            case "postgresql":
              this._dbProvider = PostgreSqlDialect.Provider;
              break;
            case "mssqlserver":
              this._dbProvider = SqlServerDialect.Provider;
              break;
            default:
              this._dbProvider = null;
              break;
          }
        }

        return this._dbProvider;
      }
    }

    /// <summary>
    /// Database connection
    /// </summary>
    private IDbConnection _dbConnection;

    /// <summary>
    /// Gets the database connection
    /// </summary>
    public IDbConnection DbConnection
    {
      get
      {
        if (this._dbConnection == null)
        {
          this._dbConnection = this.DbConnectionFactory.OpenDbConnection();
        }

        return this._dbConnection;
      }
    }

    /// <summary>
    /// Database connection factory
    /// </summary>
    private IDbConnectionFactory _dbConnectionFactory;

    /// <summary>
    /// Gets the database connection factory
    /// </summary>
    public IDbConnectionFactory DbConnectionFactory
    {
      get
      {
        if (this._dbConnectionFactory == null)
        {
          this._dbConnectionFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["bm2s"].ConnectionString, this.DbProvider);
        }

        return this._dbConnectionFactory;
      }
    }

    /// <summary>
    /// Constructor for the singleton
    /// </summary>
    protected Datas()
    {
      this.CheckDatabaseSchema();
    }

    /// <summary>
    /// Creation of the schemas
    /// </summary>
    public virtual void CheckDatabaseSchema()
    {
    }

    /// <summary>
    /// Create datas for the first use
    /// </summary>
    public virtual void CheckFirstUseDatas()
    {
    }
  }
}
