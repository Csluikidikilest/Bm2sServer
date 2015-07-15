using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using Bm2s.Data.BLL.Trade;
using Bm2s.Data.BLL.User;
using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;

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

      if (provider == null)
      {
        return -1;
      }

      var dbFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["bm2s"].ConnectionString, provider);

      IDbConnection dbConnection = dbFactory.OpenDbConnection();

      Console.Write("Check database schema : ");
      if (CheckDatabaseSchema(dbConnection))
      {
        Console.WriteLine("[OK]");
      }
      else
      {
        return -2;
      }

      return 0;
    }

    public static bool CheckDatabaseSchema(IDbConnection dbConnection)
    {
      try
      {
        dbConnection.CreateTableIfNotExists<ArticleFamily>();
        dbConnection.CreateTableIfNotExists<ArticleSubFamily>();
        dbConnection.CreateTableIfNotExists<Brand>();
        dbConnection.CreateTableIfNotExists<Unit>();
        dbConnection.CreateTableIfNotExists<Article>();
        dbConnection.CreateTableIfNotExists<User>();
        dbConnection.CreateTableIfNotExists<Partner>();
        dbConnection.CreateTableIfNotExists<ArticleFamilyPricePartner>();
        dbConnection.CreateTableIfNotExists<PartnerFamily>();
        dbConnection.CreateTableIfNotExists<ArticleFamilyPricePartnerFamily>();
        dbConnection.CreateTableIfNotExists<ArticlePriceParner>();
        dbConnection.CreateTableIfNotExists<ArticlePriceParnerFamily>();
        dbConnection.CreateTableIfNotExists<ArticleSubFamilyPricePartner>();
        dbConnection.CreateTableIfNotExists<ArticleSubFamilyPricePartnerFamily>();
        dbConnection.CreateTableIfNotExists<Nomenclature>();
        dbConnection.CreateTableIfNotExists<Price>();
        dbConnection.CreateTableIfNotExists<Activity>();
        dbConnection.CreateTableIfNotExists<Affair>();
        dbConnection.CreateTableIfNotExists<AffairFile>();
        dbConnection.CreateTableIfNotExists<HeaderStatus>();
        dbConnection.CreateTableIfNotExists<Header>();
        dbConnection.CreateTableIfNotExists<AffairHeader>();
        dbConnection.CreateTableIfNotExists<Vat>();
        dbConnection.CreateTableIfNotExists<ArticleFamilyPartnerFamilyVat>();
        dbConnection.CreateTableIfNotExists<ArticleFamilyPartnerVat>();
        dbConnection.CreateTableIfNotExists<ArticlePartnerFamilyVat>();
        dbConnection.CreateTableIfNotExists<ArticlePartnerVat>();
        dbConnection.CreateTableIfNotExists<ArticleSubFamilyPartnerFamilyVat>();
        dbConnection.CreateTableIfNotExists<ArticleSubFamilyPartnerVat>();
        dbConnection.CreateTableIfNotExists<Country>();
        dbConnection.CreateTableIfNotExists<CountryCurrency>();
        dbConnection.CreateTableIfNotExists<InventoryHeader>();
        dbConnection.CreateTableIfNotExists<InventoryLine>();
        dbConnection.CreateTableIfNotExists<Parameter>();
        dbConnection.CreateTableIfNotExists<Period>();
        dbConnection.CreateTableIfNotExists<SelectorScreen>();
        dbConnection.CreateTableIfNotExists<SelectorColumn>();
        dbConnection.CreateTableIfNotExists<Town>();
        dbConnection.CreateTableIfNotExists<UnitConversion>();
        dbConnection.CreateTableIfNotExists<Address>();
        dbConnection.CreateTableIfNotExists<AddressLine>();
        dbConnection.CreateTableIfNotExists<AddressType>();
        dbConnection.CreateTableIfNotExists<PartnerAddress>();
        dbConnection.CreateTableIfNotExists<PartnerContact>();
        dbConnection.CreateTableIfNotExists<PartnerFile>();
        dbConnection.CreateTableIfNotExists<PartnerPartnerFamily>();
        dbConnection.CreateTableIfNotExists<HeaderFile>();
        dbConnection.CreateTableIfNotExists<HeaderFreeReference>();
        dbConnection.CreateTableIfNotExists<HeaderLineType>();
        dbConnection.CreateTableIfNotExists<HeaderLine>();
        dbConnection.CreateTableIfNotExists<HeaderOrigin>();
        dbConnection.CreateTableIfNotExists<HeaderPartnerAddress>();
        dbConnection.CreateTableIfNotExists<HeaderStatusStep>();
        dbConnection.CreateTableIfNotExists<PaymentMode>();
        dbConnection.CreateTableIfNotExists<Payment>();
        dbConnection.CreateTableIfNotExists<Reconciliation>();
        dbConnection.CreateTableIfNotExists<Group>();
        dbConnection.CreateTableIfNotExists<Module>();
        dbConnection.CreateTableIfNotExists<GroupModule>();
        dbConnection.CreateTableIfNotExists<UserActivity>();
        dbConnection.CreateTableIfNotExists<UserGroup>();
        dbConnection.CreateTableIfNotExists<UserModule>();

        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }
  }
}
