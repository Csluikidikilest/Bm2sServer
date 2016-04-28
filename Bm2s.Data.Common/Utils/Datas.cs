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
        this.DbConnection.CreateTableIfNotExists<Arfa>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamily: ");
        this.DbConnection.CreateTableIfNotExists<Arsf>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Brand: ");
        this.DbConnection.CreateTableIfNotExists<Bran>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Unit: ");
        this.DbConnection.CreateTableIfNotExists<Unit>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Article: ");
        this.DbConnection.CreateTableIfNotExists<Arti>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Language: ");
        this.DbConnection.CreateTableIfNotExists<Lang>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation User: ");
        this.DbConnection.CreateTableIfNotExists<User>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Partner: ");
        this.DbConnection.CreateTableIfNotExists<Part>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPricePartner: ");
        this.DbConnection.CreateTableIfNotExists<Afpp>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<Pafa>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPricePartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<Afpf>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePricePartner: ");
        this.DbConnection.CreateTableIfNotExists<Arpp>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePricePartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<Appf>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPricePartner: ");
        this.DbConnection.CreateTableIfNotExists<Aspp>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPricePartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<Aspf>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Nomenclature: ");
        this.DbConnection.CreateTableIfNotExists<Nome>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Price: ");
        this.DbConnection.CreateTableIfNotExists<Pric>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Activity: ");
        this.DbConnection.CreateTableIfNotExists<Acti>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Affair: ");
        this.DbConnection.CreateTableIfNotExists<Affa>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AffairFile: ");
        this.DbConnection.CreateTableIfNotExists<Affi>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderStatus: ");
        this.DbConnection.CreateTableIfNotExists<Hest>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Header: ");
        this.DbConnection.CreateTableIfNotExists<Head>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AffairHeader: ");
        this.DbConnection.CreateTableIfNotExists<Afhe>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Vat: ");
        this.DbConnection.CreateTableIfNotExists<Vat>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPartnerFamilyVat: ");
        this.DbConnection.CreateTableIfNotExists<Affv>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleFamilyPartnerVat: ");
        this.DbConnection.CreateTableIfNotExists<Afpv>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePartnerFamilyVat: ");
        this.DbConnection.CreateTableIfNotExists<Apfv>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticlePartnerVat: ");
        this.DbConnection.CreateTableIfNotExists<Arpv>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPartnerFamilyVat: ");
        this.DbConnection.CreateTableIfNotExists<Asfv>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation ArticleSubFamilyPartnerVat: ");
        this.DbConnection.CreateTableIfNotExists<Aspv>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Country: ");
        this.DbConnection.CreateTableIfNotExists<Coun>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation CountryCurrency: ");
        this.DbConnection.CreateTableIfNotExists<Cocu>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation InventoryHeader: ");
        this.DbConnection.CreateTableIfNotExists<Inhe>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation InventoryLine: ");
        this.DbConnection.CreateTableIfNotExists<Inli>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Parameter: ");
        this.DbConnection.CreateTableIfNotExists<Para>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation User Parameter: ");
        this.DbConnection.CreateTableIfNotExists<Uspa>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Period: ");
        this.DbConnection.CreateTableIfNotExists<Peri>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Subscription: ");
        this.DbConnection.CreateTableIfNotExists<Subs>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation SubscriptionPartner: ");
        this.DbConnection.CreateTableIfNotExists<Supa>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Town: ");
        this.DbConnection.CreateTableIfNotExists<Town>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UnitConversion: ");
        this.DbConnection.CreateTableIfNotExists<Unco>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Address: ");
        this.DbConnection.CreateTableIfNotExists<Addr>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AddressLine: ");
        this.DbConnection.CreateTableIfNotExists<Adli>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation AddressType: ");
        this.DbConnection.CreateTableIfNotExists<Adty>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerAddress: ");
        this.DbConnection.CreateTableIfNotExists<Paad>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerContact: ");
        this.DbConnection.CreateTableIfNotExists<Paco>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerFile: ");
        this.DbConnection.CreateTableIfNotExists<Pafi>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PartnerPartnerFamily: ");
        this.DbConnection.CreateTableIfNotExists<Papf>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderFile: ");
        this.DbConnection.CreateTableIfNotExists<Hefi>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderFreeReference: ");
        this.DbConnection.CreateTableIfNotExists<Hefr>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderLineType: ");
        this.DbConnection.CreateTableIfNotExists<Helt>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderLine: ");
        this.DbConnection.CreateTableIfNotExists<Heli>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderOrigin: ");
        this.DbConnection.CreateTableIfNotExists<Heor>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderPartnerAddress: ");
        this.DbConnection.CreateTableIfNotExists<Hepa>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation HeaderStatusStep: ");
        this.DbConnection.CreateTableIfNotExists<Hess>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation PaymentMode: ");
        this.DbConnection.CreateTableIfNotExists<Pamo>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Payment: ");
        this.DbConnection.CreateTableIfNotExists<Paym>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Reconciliation: ");
        this.DbConnection.CreateTableIfNotExists<Reco>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Group: ");
        this.DbConnection.CreateTableIfNotExists<Grou>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Module: ");
        this.DbConnection.CreateTableIfNotExists<Modu>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation GroupModule: ");
        this.DbConnection.CreateTableIfNotExists<Grmo>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UserActivity: ");
        this.DbConnection.CreateTableIfNotExists<Usac>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UserGroup: ");
        this.DbConnection.CreateTableIfNotExists<Usgr>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation UserModule: ");
        this.DbConnection.CreateTableIfNotExists<Usmo>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Translation: ");
        this.DbConnection.CreateTableIfNotExists<Tran>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation Message: ");
        this.DbConnection.CreateTableIfNotExists<Mess>();
        Console.WriteLine("[OK]");
        Console.Write("Table creation MessageRecipient: ");
        this.DbConnection.CreateTableIfNotExists<Mere>();
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
      BLL.Parameter.Lang english = this.DataStorage.Languages.FirstOrDefault(item => item.Code.ToLower() == "en-gb");
      if (english == null)
      {
        english = new Lang() { Code = "en-gb", Name = "English (Great Britain)" };
        this.DataStorage.Languages.Add(english);
      }

      BLL.Parameter.Lang french = this.DataStorage.Languages.FirstOrDefault(item => item.Code.ToLower() == "fr-fr");
      if (french == null)
      {
        french = new Lang() { Code = "fr-fr", Name = "Français (France)" };
        this.DataStorage.Languages.Add(french);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas administrators group: ");

      // Group: administrators
      BLL.User.Grou administrators = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Administrators");
      if (administrators == null)
      {
        administrators = new Grou() { Code = "Administrators", Name = "System Administrators", IsSystem = true, StartingDate = new DateTime(2015, 1, 1) };
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

        administrator = new User() { DelaId = english.Id, LastName = "Administrator", IsAdministrator = true, IsAnonymous = false, IsSystem = true, FirstName = string.Empty, Login = "Administrator", Password = password.ToString(), StartingDate = new DateTime(2015, 1, 1) };
        this.DataStorage.Users.Add(administrator);
        BLL.User.Usgr administratorGroups = new Usgr() { GrouId = administrators.Id, UserId = administrator.Id };
        this.DataStorage.UserGroups.Add(administratorGroups);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas visitors group: ");

      // Group: visitors
      BLL.User.Grou visitors = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Visitors");
      if (visitors == null)
      {
        visitors = new Grou() { Code = "Visitors", Name = "Visitors", IsSystem = true, StartingDate = new DateTime(2015, 1, 1) };
        this.DataStorage.Groups.Add(visitors);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas visitor user: ");

      // User: visitor
      BLL.User.User visitor = this.DataStorage.Users.FirstOrDefault(item => item.Login == "Visitor");
      if (visitor == null)
      {
        SHA512 hash = SHA512.Create();
        byte[] passwordBytes = hash.ComputeHash(Encoding.UTF8.GetBytes("Visitor"));

        StringBuilder password = new StringBuilder();
        foreach (byte passwordByte in passwordBytes)
        {
          password.Append(passwordByte.ToString("X2"));
        }

        visitor = new User() { DelaId = english.Id, LastName = "Visitor", IsAdministrator = false, IsAnonymous = true, IsSystem = true, FirstName = string.Empty, Login = "Visitor", Password = password.ToString(), StartingDate = new DateTime(2015, 1, 1) };
        this.DataStorage.Users.Add(visitor);

        BLL.User.Usgr visitorGroups = new Usgr() { GrouId = visitors.Id, UserId = visitor.Id };
        this.DataStorage.UserGroups.Add(visitorGroups);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas classic group: ");

      // Group: classic users
      BLL.User.Grou users = this.DataStorage.Groups.FirstOrDefault(item => item.Code == "Users");
      if (users == null)
      {
        users = new Grou() { Code = "Users", Name = "Classic Users", IsSystem = false, StartingDate = new DateTime(2015, 1, 1) };
        this.DataStorage.Groups.Add(users);
      }

      Console.WriteLine("[OK]");
      Console.Write("Initial datas classic user: ");

      // User: classic user
      BLL.User.User user = this.DataStorage.Users.FirstOrDefault(item => item.Login == "User");
      if (user == null)
      {
        SHA512 hash = SHA512.Create();
        byte[] passwordBytes = hash.ComputeHash(Encoding.UTF8.GetBytes("User"));

        StringBuilder password = new StringBuilder();
        foreach (byte passwordByte in passwordBytes)
        {
          password.Append(passwordByte.ToString("X2"));
        }

        user = new User() { DelaId = english.Id, LastName = "User", IsAdministrator = false, IsAnonymous = false, IsSystem = false, FirstName = string.Empty, Login = "User", Password = password.ToString(), StartingDate = new DateTime(2015, 1, 1) };
        this.DataStorage.Users.Add(user);
        BLL.User.Usgr userGroups = new Usgr() { GrouId = users.Id, UserId = user.Id };
        this.DataStorage.UserGroups.Add(userGroups);
      }

      Console.WriteLine("[OK]");
    }
  }
}
