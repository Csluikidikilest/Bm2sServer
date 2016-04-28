using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bm2s.Data.Utils.BLL
{
  public class DataRow
  {
    public virtual int Id { get; set; }

    public static T Load<T>(IDbConnection dbConnection, int id, bool lazyLoad) where T : DataRow
    {
      OrmLiteConfig.DialectProvider = dbConnection.GetDialectProvider();
      SqlExpressionVisitor<T> ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
      ev.And(f => f.Id == id);

      T result = dbConnection.Select<T>(ev).FirstOrDefault();

      return result;
    }

    public static List<T> LoadAll<T>(IDbConnection dbConnection) where T : DataRow
    {
      return dbConnection.Select<T>();
    }

    public virtual void Delete<T>(IDbConnection dbConnection) where T : DataRow
    {
      dbConnection.Delete<T>(ev => ev.Where(x => x.Id == this.Id));
    }

    protected virtual void Insert<T>(IDbConnection dbConnection) where T : DataRow
    {
      try
      {
        dbConnection.Insert(this);

        int id = 0;
        int.TryParse(dbConnection.GetLastInsertId().ToString(), out id);
        this.Id = id;
      }
      catch(Exception ex)
      {
        Console.WriteLine("Error when trying to insert " + this.GetType().ToString().ToLower() + ": " + this.ToString());
        Console.WriteLine("Reason: " + ex.Message);
      }
    }

    public virtual void Save<T>(IDbConnection dbConnection) where T : DataRow
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

    protected virtual void Update<T>(IDbConnection dbConnection) where T : DataRow
    {
      try
      {
        dbConnection.Update(this as T, f => f.Id == this.Id);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error when trying to update " + this.GetType().ToString().ToLower() + ": " + this.ToString());
        Console.WriteLine("Reason: " + ex.Message);
      }
    }

    public override string ToString()
    {
      StringBuilder result = new StringBuilder();
      Type type = this.GetType();

      result.Append("{ ");
      foreach (PropertyInfo propertyInfo in type.GetProperties())
      {
        switch (propertyInfo.PropertyType.Name.ToLower())
        {
          case "string":
            if (propertyInfo.GetValue(this) == null)
            {
              result.Append(propertyInfo.Name + ": null");
            }
            else
            {
              result.Append(propertyInfo.Name + ": '" + propertyInfo.GetValue(this) + "'");
            }
            break;
          case "int32":
          case "datetime":
          case "float":
          case "decimal":
          case "boolean":
            result.Append(propertyInfo.Name + ": " + propertyInfo.GetValue(this));
            break;
        }
        result.Append(", ");
      }

      result = result.Remove(result.Length - 2, 2);
      result.Append(" }");

      return result.ToString();
    }
  }
}
