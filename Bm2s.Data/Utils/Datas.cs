using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using Bm2s.Data.BLL.Trade;
using Bm2s.Data.BLL.User;
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
    /// Instance of the singleton
    /// </summary>
    private static Datas __instance;

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
            case "postgresql":
              this._dbProvider = PostgreSqlDialect.Provider;
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
    /// Storage of the datas
    /// </summary>
    public DataStorage DataStorage { get; private set; }

    /// <summary>
    /// Constructor for the singleton
    /// </summary>
    private Datas()
    {
      this.CheckDatabaseSchema();
      this.DataStorage = new DataStorage(ConfigurationManager.AppSettings["RamStorage"] == "1", this.DbConnection);
    }

    /// <summary>
    /// Creation of the schemas
    /// </summary>
    public void CheckDatabaseSchema()
    {
      try
      {
        this.DbConnection.CreateTableIfNotExists<ArticleFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamily>();
        this.DbConnection.CreateTableIfNotExists<Brand>();
        this.DbConnection.CreateTableIfNotExists<Unit>();
        this.DbConnection.CreateTableIfNotExists<Article>();
        this.DbConnection.CreateTableIfNotExists<User>();
        this.DbConnection.CreateTableIfNotExists<Partner>();
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPricePartner>();
        this.DbConnection.CreateTableIfNotExists<PartnerFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPricePartnerFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticlePriceParner>();
        this.DbConnection.CreateTableIfNotExists<ArticlePriceParnerFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPricePartner>();
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPricePartnerFamily>();
        this.DbConnection.CreateTableIfNotExists<Nomenclature>();
        this.DbConnection.CreateTableIfNotExists<Price>();
        this.DbConnection.CreateTableIfNotExists<Activity>();
        this.DbConnection.CreateTableIfNotExists<Affair>();
        this.DbConnection.CreateTableIfNotExists<AffairFile>();
        this.DbConnection.CreateTableIfNotExists<HeaderStatus>();
        this.DbConnection.CreateTableIfNotExists<Header>();
        this.DbConnection.CreateTableIfNotExists<AffairHeader>();
        this.DbConnection.CreateTableIfNotExists<Vat>();
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPartnerFamilyVat>();
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPartnerVat>();
        this.DbConnection.CreateTableIfNotExists<ArticlePartnerFamilyVat>();
        this.DbConnection.CreateTableIfNotExists<ArticlePartnerVat>();
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPartnerFamilyVat>();
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPartnerVat>();
        this.DbConnection.CreateTableIfNotExists<Country>();
        this.DbConnection.CreateTableIfNotExists<CountryCurrency>();
        this.DbConnection.CreateTableIfNotExists<InventoryHeader>();
        this.DbConnection.CreateTableIfNotExists<InventoryLine>();
        this.DbConnection.CreateTableIfNotExists<Parameter>();
        this.DbConnection.CreateTableIfNotExists<Period>();
        this.DbConnection.CreateTableIfNotExists<Subscription>();
        this.DbConnection.CreateTableIfNotExists<SubscriptionPartner>();
        this.DbConnection.CreateTableIfNotExists<SelectorScreen>();
        this.DbConnection.CreateTableIfNotExists<SelectorColumn>();
        this.DbConnection.CreateTableIfNotExists<Town>();
        this.DbConnection.CreateTableIfNotExists<UnitConversion>();
        this.DbConnection.CreateTableIfNotExists<Address>();
        this.DbConnection.CreateTableIfNotExists<AddressLine>();
        this.DbConnection.CreateTableIfNotExists<AddressType>();
        this.DbConnection.CreateTableIfNotExists<PartnerAddress>();
        this.DbConnection.CreateTableIfNotExists<PartnerContact>();
        this.DbConnection.CreateTableIfNotExists<PartnerFile>();
        this.DbConnection.CreateTableIfNotExists<PartnerPartnerFamily>();
        this.DbConnection.CreateTableIfNotExists<HeaderFile>();
        this.DbConnection.CreateTableIfNotExists<HeaderFreeReference>();
        this.DbConnection.CreateTableIfNotExists<HeaderLineType>();
        this.DbConnection.CreateTableIfNotExists<HeaderLine>();
        this.DbConnection.CreateTableIfNotExists<HeaderOrigin>();
        this.DbConnection.CreateTableIfNotExists<HeaderPartnerAddress>();
        this.DbConnection.CreateTableIfNotExists<HeaderStatusStep>();
        this.DbConnection.CreateTableIfNotExists<PaymentMode>();
        this.DbConnection.CreateTableIfNotExists<Payment>();
        this.DbConnection.CreateTableIfNotExists<Reconciliation>();
        this.DbConnection.CreateTableIfNotExists<Group>();
        this.DbConnection.CreateTableIfNotExists<Module>();
        this.DbConnection.CreateTableIfNotExists<GroupModule>();
        this.DbConnection.CreateTableIfNotExists<UserActivity>();
        this.DbConnection.CreateTableIfNotExists<UserGroup>();
        this.DbConnection.CreateTableIfNotExists<UserModule>();
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// Create some datas for some tests
    /// </summary>
    public void CreateDatasForTest()
    {
      ArticleFamily arfa1 = new ArticleFamily() { Code = "ARFA1", Description = "Family 1", Designation = "Family 1", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleFamilies.Add(arfa1);

      ArticleFamily arfa2 = new ArticleFamily() { Code = "ARFA2", Description = "Family 2", Designation = "Family 2", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleFamilies.Add(arfa2);

      ArticleSubFamily arsf11 = new ArticleSubFamily() { ArticleFamilyId = arfa1.Id, Code = "ARSF11", Description = "Subfamily 11", Designation = "Subfamily 11", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleSubFamilies.Add(arsf11);

      ArticleSubFamily arsf12 = new ArticleSubFamily() { ArticleFamilyId = arfa1.Id, Code = "ARSF12", Description = "Subfamily 12", Designation = "Subfamily 12", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleSubFamilies.Add(arsf12);

      ArticleSubFamily arsf21 = new ArticleSubFamily() { ArticleFamilyId = arfa2.Id, Code = "ARSF21", Description = "Subfamily 21", Designation = "Subfamily 21", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleSubFamilies.Add(arsf21);

      ArticleSubFamily arsf22 = new ArticleSubFamily() { ArticleFamilyId = arfa2.Id, Code = "ARSF22", Description = "Subfamily 22", Designation = "Subfamily 22", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleSubFamilies.Add(arsf22);

      ArticleSubFamily arsf23 = new ArticleSubFamily() { ArticleFamilyId = arfa2.Id, Code = "ARSF23", Description = "Subfamily 23", Designation = "Subfamily 23", StartingDate = DateTime.Now };
      Datas.Instance.DataStorage.ArticleSubFamilies.Add(arsf23);

      Article arti11 = new Article() { ArticleFamilyId = arfa1.Id, ArticleSubFamilyId = arsf11.Id, Code = "ARTI11", Description = "Article 1", Designation = "Article 1" };
    }
  }
}
