using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.BLL.Trade;
using Bm2s.Data.Common.BLL.User;
using ServiceStack.OrmLite;

namespace Bm2s.Data.Common.Utils
{
  /// <summary>
  /// Data access point
  /// </summary>
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

    /// <summary>
    /// Creation of the schemas
    /// </summary>
    public override void CheckDatabaseSchema()
    {
      base.CheckDatabaseSchema();

      try
      {
        Console.Write("Table creation ArticleFamily: ");
        this.DbConnection.CreateTableIfNotExists<ArticleFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamily: ");
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Brand: ");
        this.DbConnection.CreateTableIfNotExists<Brand>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Unit: ");
        this.DbConnection.CreateTableIfNotExists<Unit>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Article: ");
        this.DbConnection.CreateTableIfNotExists<Article>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Language: ");
        this.DbConnection.CreateTableIfNotExists<Language>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation User: ");
        this.DbConnection.CreateTableIfNotExists<User>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Partner: ");
        this.DbConnection.CreateTableIfNotExists<Partner>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPricePartner: ");
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPricePartner>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<PartnerFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPricePartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPricePartnerFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePricePartner: ");
        this.DbConnection.CreateTableIfNotExists<ArticlePricePartner>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePricePartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<ArticlePricePartnerFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPricePartner: ");
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPricePartner>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPricePartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPricePartnerFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Nomenclature: ");
        this.DbConnection.CreateTableIfNotExists<Nomenclature>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Price: ");
        this.DbConnection.CreateTableIfNotExists<Price>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Activity: ");
        this.DbConnection.CreateTableIfNotExists<Activity>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Affair: ");
        this.DbConnection.CreateTableIfNotExists<Affair>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AffairFile: ");
        this.DbConnection.CreateTableIfNotExists<AffairFile>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderStatus: ");
        this.DbConnection.CreateTableIfNotExists<HeaderStatus>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Header: ");
        this.DbConnection.CreateTableIfNotExists<Header>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AffairHeader: ");
        this.DbConnection.CreateTableIfNotExists<AffairHeader>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Vat: ");
        this.DbConnection.CreateTableIfNotExists<Vat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPartnerFamilyVat: ");
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPartnerFamilyVat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPartnerVat: ");
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPartnerVat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePartnerFamilyVat: ");
        this.DbConnection.CreateTableIfNotExists<ArticlePartnerFamilyVat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePartnerVat: ");
        this.DbConnection.CreateTableIfNotExists<ArticlePartnerVat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPartnerFamilyVat: ");
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPartnerFamilyVat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPartnerVat: ");
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamilyPartnerVat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Country: ");
        this.DbConnection.CreateTableIfNotExists<Country>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation CountryCurrency: ");
        this.DbConnection.CreateTableIfNotExists<CountryCurrency>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation InventoryHeader: ");
        this.DbConnection.CreateTableIfNotExists<InventoryHeader>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation InventoryLine: ");
        this.DbConnection.CreateTableIfNotExists<InventoryLine>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Parameter: ");
        this.DbConnection.CreateTableIfNotExists<Parameter>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Period: ");
        this.DbConnection.CreateTableIfNotExists<Period>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Subscription: ");
        this.DbConnection.CreateTableIfNotExists<Subscription>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation SubscriptionPartner: ");
        this.DbConnection.CreateTableIfNotExists<SubscriptionPartner>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Town: ");
        this.DbConnection.CreateTableIfNotExists<Town>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UnitConversion: ");
        this.DbConnection.CreateTableIfNotExists<UnitConversion>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Address: ");
        this.DbConnection.CreateTableIfNotExists<Address>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AddressLine: ");
        this.DbConnection.CreateTableIfNotExists<AddressLine>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AddressType: ");
        this.DbConnection.CreateTableIfNotExists<AddressType>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerAddress: ");
        this.DbConnection.CreateTableIfNotExists<PartnerAddress>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerContact: ");
        this.DbConnection.CreateTableIfNotExists<PartnerContact>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerFile: ");
        this.DbConnection.CreateTableIfNotExists<PartnerFile>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerPartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<PartnerPartnerFamily>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderFile: ");
        this.DbConnection.CreateTableIfNotExists<HeaderFile>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderFreeReference: ");
        this.DbConnection.CreateTableIfNotExists<HeaderFreeReference>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderLineType: ");
        this.DbConnection.CreateTableIfNotExists<HeaderLineType>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderLine: ");
        this.DbConnection.CreateTableIfNotExists<HeaderLine>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderOrigin: ");
        this.DbConnection.CreateTableIfNotExists<HeaderOrigin>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderPartnerAddress: ");
        this.DbConnection.CreateTableIfNotExists<HeaderPartnerAddress>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderStatusStep: ");
        this.DbConnection.CreateTableIfNotExists<HeaderStatusStep>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PaymentMode: ");
        this.DbConnection.CreateTableIfNotExists<PaymentMode>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Payment: ");
        this.DbConnection.CreateTableIfNotExists<Payment>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Reconciliation: ");
        this.DbConnection.CreateTableIfNotExists<Reconciliation>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Group: ");
        this.DbConnection.CreateTableIfNotExists<Group>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Module: ");
        this.DbConnection.CreateTableIfNotExists<Module>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation GroupModule: ");
        this.DbConnection.CreateTableIfNotExists<GroupModule>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UserActivity: ");
        this.DbConnection.CreateTableIfNotExists<UserActivity>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UserGroup: ");
        this.DbConnection.CreateTableIfNotExists<UserGroup>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UserModule: ");
        this.DbConnection.CreateTableIfNotExists<UserModule>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Translation: ");
        this.DbConnection.CreateTableIfNotExists<Translation>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Message: ");
        this.DbConnection.CreateTableIfNotExists<Message>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation MessageRecipient: ");
        this.DbConnection.CreateTableIfNotExists<MessageRecipient>();
        Console.WriteLine("[OK]");
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// Create datas for the first use
    /// </summary>
    public override void CheckFirstUseDatas()
    {
      base.CheckFirstUseDatas();

      Console.Write("Initial datas english language: ");

      // Languages: ISO CODE 639-3: https://en.wikipedia.org/wiki/ISO_639
      BLL.Parameter.Language english = this.DataStorage.Languages.FirstOrDefault(item => item.Code.ToLower() == "en-gb");
      if (english == null)
      {
        english = new Language() { Code = "en-gb", Name = "English (Great Britain)" };
        this.DataStorage.Languages.Add(english);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas administrators group: ");

      // Group: administrators
      BLL.User.Group administrators = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Administrators");
      if (administrators == null)
      {
        administrators = new Group() { Code = "Administrators", Name = "System Administrator", IsSystem = true };
        this.DataStorage.Groups.Add(administrators);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas administrator user: ");

      // User: administrator
      BLL.User.User administrator = this.DataStorage.Users.FirstOrDefault(item => item.Login == "Administrator");
      if (administrator == null)
      {
        SHA512 hash = SHA512.Create();
        byte[] passwordBytes = hash.ComputeHash(Encoding.UTF8.GetBytes("Administrator"));

        StringBuilder password = new StringBuilder();
        foreach (byte passwordByte in passwordBytes)
        {
          password.Append(passwordByte.ToString("X2"));
        }

        administrator = new User() { DefaultLanguageId = english.Id, FirstName = "Administrator", IsAdministrator = true, IsAnonymous = false, IsSystem = true, LastName = string.Empty, Login = "Administrator", Password = password.ToString(), StartingDate = new DateTime(2014, 11, 2) };
        this.DataStorage.Users.Add(administrator);
        BLL.User.UserGroup administratorGroups = new UserGroup() { GroupId = administrators.Id, UserId = administrator.Id };
        this.DataStorage.UserGroups.Add(administratorGroups);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas visitors group: ");

      // Group: visitors
      BLL.User.Group visitors = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Visitors");
      if (visitors == null)
      {
        visitors = new Group() { Code = "Visitors", Name = "Visitors", IsSystem = true };
        this.DataStorage.Groups.Add(visitors);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas visitor user: ");

      // User: visitor
      BLL.User.User visitor = this.DataStorage.Users.FirstOrDefault(item => item.Login == "Visitor");
      if (visitor == null)
      {
        visitor = new User() { DefaultLanguageId = english.Id, FirstName = "Visitor", IsAdministrator = false, IsAnonymous = true, IsSystem = true, LastName = string.Empty, Login = "Visitor", Password = string.Empty, StartingDate = new DateTime(2014, 11, 2) };
        this.DataStorage.Users.Add(visitor);

        BLL.User.UserGroup visitorGroups = new UserGroup() { GroupId = visitors.Id, UserId = visitor.Id };
        this.DataStorage.UserGroups.Add(visitorGroups);
      }

      Console.WriteLine("[OK]");
    }
  }
}
