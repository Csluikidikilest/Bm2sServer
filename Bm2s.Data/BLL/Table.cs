using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;
namespace Bm2s.Data.BLL
{
  public class Table
  {
    public virtual int Id { get; protected set; }

    public static T Load<T>(IDbConnection dbConnection, int id) where T : Table
    {
      OrmLiteConfig.DialectProvider = dbConnection.GetDialectProvider();
      SqlExpressionVisitor<T> ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
      ev.And(f => f.Id == id);

      return dbConnection.Select<T>(ev).FirstOrDefault();
    }

    public static List<T> LoadAll<T>(IDbConnection dbConnection) where T : Table
    {
      return dbConnection.Select<T>();
    }

    public virtual void Delete<T>(IDbConnection dbConnection) where T : Table
    {
      dbConnection.Delete<T>(ev => ev.Where(x => x.Id == this.Id));
    }

    protected virtual void Insert<T>(IDbConnection dbConnection) where T : Table
    {
      dbConnection.Insert(this);

      int id = 0;
      int.TryParse(dbConnection.GetLastInsertId().ToString(), out id);
      this.Id = id;
    }

    public virtual void LazyLoad(IDbConnection dbConnection) { }

    public virtual void Save<T>(IDbConnection dbConnection) where T : Table
    {
      if (this.Id > 0)
      {
        this.Update<T>(dbConnection);
      }
      else
      {
        this.Insert<T>(dbConnection);
      }
    }

    protected virtual void Update<T>(IDbConnection dbConnection) where T : Table
    {
      dbConnection.Update(this as T, f => f.Id == this.Id);
    }
  }
}
