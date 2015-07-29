using System;
using System.Configuration;
using Bm2s.Data.POS.BLL.PointOfSale;
using ServiceStack.OrmLite;

namespace Bm2s.Data.POS.Utils
{
  public class Datas : Bm2s.Data.Utils.Datas
  {
    /// <summary>
    /// Instance of the singleton
    /// </summary>
    private static Datas __instance;

    /// <summary>
    /// Storage of the datas
    /// </summary>
    public DataStorage DataStorage { get; private set; }

    /// <summary>
    /// Gets the singleton
    /// </summary>
    public static Datas Instance
    {
      get
      {
        if (__instance == null)
        {
          __instance = new Datas();
        }

        return __instance;
      }
    }

    /// <summary>
    /// Constructor for the singleton
    /// </summary>
    protected Datas()
      : base()
    {
      this.DataStorage = new DataStorage(ConfigurationManager.AppSettings["RamStorage"] == "1", this.DbConnection);
    }

    public override void CheckDatabaseSchema()
    {
      base.CheckDatabaseSchema();
      try
      {
        this.DbConnection.CreateTableIfNotExists<Screen>();
        this.DbConnection.CreateTableIfNotExists<Button>();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
