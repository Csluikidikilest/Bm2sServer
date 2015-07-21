using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL
{
  public class Table
  {
    public virtual int Id { get; set; }

    [Ignore]
    public bool LazyLoaded { get; set; }

    public static T Load<T>(IDbConnection dbConnection, int id, bool lazyLoad) where T : Table
    {
      OrmLiteConfig.DialectProvider = dbConnection.GetDialectProvider();
      SqlExpressionVisitor<T> ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
      ev.And(f => f.Id == id);

      T result = dbConnection.Select<T>(ev).FirstOrDefault();

      if(result != null && lazyLoad && !result.LazyLoaded)
      {
        result.LazyLoad();
      }

      return result;
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

    public virtual void LazyLoad()
    {
      this.LazyLoaded = true;
    }

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
