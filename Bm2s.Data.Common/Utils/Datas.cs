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
        this.DbConnection.CreateTableIfNotExists<ArticleFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticleSubFamily>();
        this.DbConnection.CreateTableIfNotExists<Brand>();
        this.DbConnection.CreateTableIfNotExists<Unit>();
        this.DbConnection.CreateTableIfNotExists<Article>();
        this.DbConnection.CreateTableIfNotExists<Language>();
        this.DbConnection.CreateTableIfNotExists<User>();
        this.DbConnection.CreateTableIfNotExists<Partner>();
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPricePartner>();
        this.DbConnection.CreateTableIfNotExists<PartnerFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticleFamilyPricePartnerFamily>();
        this.DbConnection.CreateTableIfNotExists<ArticlePricePartner>();
        this.DbConnection.CreateTableIfNotExists<ArticlePricePartnerFamily>();
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
        this.DbConnection.CreateTableIfNotExists<Translation>();
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

      // Languages : ISO CODE 639-3 : https://en.wikipedia.org/wiki/ISO_639
      BLL.Parameter.Language english = this.DataStorage.Languages.FirstOrDefault(item => item.Code.ToLower() == "eng");
      if (english == null)
      {
        english = new Language() { Code = "eng", Name = "English" };
        this.DataStorage.Languages.Add(english);
      }

      // Group : administrators
      BLL.User.Group administrators = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Administrators");
      if (administrators == null)
      {
        administrators = new Group() { Code = "Administrators", Name = "System Administrator" };
        this.DataStorage.Groups.Add(administrators);
      }

      // User : administrator
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

        administrator = new User() { DefaultLanguageId = english.Id, FirstName = "Administrator", IsAdministrator = true, IsAnonymous = false, LastName = string.Empty, Login = "Administrator", Password = password.ToString(), StartingDate = new DateTime(2015, 11, 2) };
        this.DataStorage.Users.Add(administrator);
        BLL.User.UserGroup administratorGroups = new UserGroup() { GroupId = administrators.Id, UserId = administrator.Id };
        this.DataStorage.UserGroups.Add(administratorGroups);
      }

      // Group : visitors
      BLL.User.Group visitors = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Visitors");
      if (visitors == null)
      {
        visitors = new Group() { Code = "Visitors", Name = "Visitors" };
        this.DataStorage.Groups.Add(visitors);
      }

      // User : administrator
      BLL.User.User visitor = this.DataStorage.Users.FirstOrDefault(item => item.Login == "Visitor");
      if (visitor == null)
      {
        visitor = new User() { DefaultLanguageId = english.Id, FirstName = "Visitor", IsAdministrator = false, IsAnonymous = true, LastName = string.Empty, Login = "Visitor", Password = string.Empty, StartingDate = new DateTime(2015, 11, 2) };
        this.DataStorage.Users.Add(visitor);

        BLL.User.UserGroup visitorGroups = new UserGroup() { GroupId = visitors.Id, UserId = visitor.Id };
        this.DataStorage.UserGroups.Add(visitorGroups);
      }
    }
  }
}
