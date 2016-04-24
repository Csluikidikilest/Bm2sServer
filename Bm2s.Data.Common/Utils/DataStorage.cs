using System.Data;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.BLL.Trade;
using Bm2s.Data.Common.BLL.User;
using Bm2s.Data.Utils.BLL;

namespace Bm2s.Data.Common.Utils
{
  public class DataStorage : Bm2s.Data.Utils.DataStorage
  {
    public Table<Arti> Articles { get; set; }
    public Table<Arfa> ArticleFamilies { get; set; }
    public Table<Afpp> ArticleFamilyPricePartners { get; set; }
    public Table<Afpf> ArticleFamilyPricePartnerFamilies { get; set; }
    public Table<Arpp> ArticlePricePartners { get; set; }
    public Table<Appf> ArticlePricePartnerFamilies { get; set; }
    public Table<Arsf> ArticleSubFamilies { get; set; }
    public Table<Aspp> ArticleSubFamilyPricePartners { get; set; }
    public Table<Aspf> ArticleSubFamilyPricePartnerFamilies { get; set; }
    public Table<Bran> Brands { get; set; }
    public Table<Nome> Nomenclatures { get; set; }
    public Table<Pric> Prices { get; set; }
    public Table<Subs> Subscriptions { get; set; }
    public Table<Supa> SubscriptionPartners { get; set; }

    public Table<Acti> Activities { get; set; }
    public Table<Affa> Affairs { get; set; }
    public Table<Affi> AffairFiles { get; set; }
    public Table<Afhe> AffairHeaders { get; set; }
    public Table<Affv> ArticleFamilyPartnerFamilyVats { get; set; }
    public Table<Afpv> ArticleFamilyPartnerVats { get; set; }
    public Table<Apfv> ArticlePartnerFamilyVats { get; set; }
    public Table<Arpv> ArticlePartnerVats { get; set; }
    public Table<Asfv> ArticleSubFamilyPartnerFamilyVats { get; set; }
    public Table<Aspv> ArticleSubFamilyPartnerVats { get; set; }
    public Table<Coun> Countries { get; set; }
    public Table<Cocu> CountryCurrencies { get; set; }
    public Table<Inhe> InventoryHeaders { get; set; }
    public Table<Inli> InventoryLines { get; set; }
    public Table<Lang> Languages { get; set; }
    public Table<Para> Parameters { get; set; }
    public Table<Uspa> UserParameters { get; set; }
    public Table<Peri> Periods { get; set; }
    public Table<Town> Towns { get; set; }
    public Table<Tran> Translations { get; set; }
    public Table<Unit> Units { get; set; }
    public Table<Unco> UnitConversions { get; set; }
    public Table<Vat> Vats { get; set; }

    public Table<Addr> Addresses { get; set; }
    public Table<Adli> AddressLines { get; set; }
    public Table<Adty> AddressTypes { get; set; }
    public Table<Part> Partners { get; set; }
    public Table<Paad> PartnerAddresses { get; set; }
    public Table<Paco> PartnerContacts { get; set; }
    public Table<Pafa> PartnerFamilies { get; set; }
    public Table<Pafi> PartnerFiles { get; set; }
    public Table<Papf> PartnerPartnerFamilies { get; set; }

    public Table<Head> Headers { get; set; }
    public Table<Hefi> HeaderFiles { get; set; }
    public Table<Hefr> HeaderFreeReferences { get; set; }
    public Table<Heli> HeaderLines { get; set; }
    public Table<Helt> HeaderLineTypes { get; set; }
    public Table<Heor> HeaderOrigins { get; set; }
    public Table<Hepa> HeaderPartnerAddresses { get; set; }
    public Table<Hest> HeaderStatuses { get; set; }
    public Table<Hess> HeaderStatusSteps { get; set; }
    public Table<Paym> Payments { get; set; }
    public Table<Pamo> PaymentModes { get; set; }
    public Table<Reco> Reconciliations { get; set; }

    public Table<Grou> Groups { get; set; }
    public Table<Grmo> GroupModules { get; set; }
    public Table<Mess> Messages { get; set; }
    public Table<Mere> MessageRecipients { get; set; }
    public Table<Modu> Modules { get; set; }
    public Table<User> Users { get; set; }
    public Table<Usac> UserActivities { get; set; }
    public Table<Usgr> UserGroups { get; set; }
    public Table<Usmo> UserModules { get; set; }

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
      : base(ramStorage, dbConnection)
    {
      this.Articles = new Table<Arti>(this._ramStorage, this._dbConnection);
      this.ArticleFamilies = new Table<Arfa>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPricePartners = new Table<Afpp>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPricePartnerFamilies = new Table<Afpf>(this._ramStorage, this._dbConnection);
      this.ArticlePricePartners = new Table<Arpp>(this._ramStorage, this._dbConnection);
      this.ArticlePricePartnerFamilies = new Table<Appf>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilies = new Table<Arsf>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPricePartners = new Table<Aspp>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPricePartnerFamilies = new Table<Aspf>(this._ramStorage, this._dbConnection);
      this.Brands = new Table<Bran>(this._ramStorage, this._dbConnection);
      this.Nomenclatures = new Table<Nome>(this._ramStorage, this._dbConnection);
      this.Prices = new Table<Pric>(this._ramStorage, this._dbConnection);
      this.Subscriptions = new Table<Subs>(this._ramStorage, this._dbConnection);
      this.SubscriptionPartners = new Table<Supa>(this._ramStorage, this._dbConnection);

      this.Activities = new Table<Acti>(this._ramStorage, this._dbConnection);
      this.Affairs = new Table<Affa>(this._ramStorage, this._dbConnection);
      this.AffairFiles = new Table<Affi>(this._ramStorage, this._dbConnection);
      this.AffairHeaders = new Table<Afhe>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPartnerFamilyVats = new Table<Affv>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPartnerVats = new Table<Afpv>(this._ramStorage, this._dbConnection);
      this.ArticlePartnerFamilyVats = new Table<Apfv>(this._ramStorage, this._dbConnection);
      this.ArticlePartnerVats = new Table<Arpv>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPartnerFamilyVats = new Table<Asfv>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPartnerVats = new Table<Aspv>(this._ramStorage, this._dbConnection);
      this.Countries = new Table<Coun>(this._ramStorage, this._dbConnection);
      this.CountryCurrencies = new Table<Cocu>(this._ramStorage, this._dbConnection);
      this.InventoryHeaders = new Table<Inhe>(this._ramStorage, this._dbConnection);
      this.InventoryLines = new Table<Inli>(this._ramStorage, this._dbConnection);
      this.Languages = new Table<Lang>(this._ramStorage, this._dbConnection);
      this.Parameters = new Table<Para>(this._ramStorage, this._dbConnection);
      this.UserParameters = new Table<Uspa>(this._ramStorage, this._dbConnection);
      this.Periods = new Table<Peri>(this._ramStorage, this._dbConnection);
      this.Towns = new Table<Town>(this._ramStorage, this._dbConnection);
      this.Translations = new Table<Tran>(this._ramStorage, this._dbConnection);
      this.Units = new Table<Unit>(this._ramStorage, this._dbConnection);
      this.UnitConversions = new Table<Unco>(this._ramStorage, this._dbConnection);
      this.Vats = new Table<Vat>(this._ramStorage, this._dbConnection);

      this.Addresses = new Table<Addr>(this._ramStorage, this._dbConnection);
      this.AddressLines = new Table<Adli>(this._ramStorage, this._dbConnection);
      this.AddressTypes = new Table<Adty>(this._ramStorage, this._dbConnection);
      this.Partners = new Table<Part>(this._ramStorage, this._dbConnection);
      this.PartnerAddresses = new Table<Paad>(this._ramStorage, this._dbConnection);
      this.PartnerContacts = new Table<Paco>(this._ramStorage, this._dbConnection);
      this.PartnerFamilies = new Table<Pafa>(this._ramStorage, this._dbConnection);
      this.PartnerFiles = new Table<Pafi>(this._ramStorage, this._dbConnection);
      this.PartnerPartnerFamilies = new Table<Papf>(this._ramStorage, this._dbConnection);

      this.Headers = new Table<Head>(this._ramStorage, this._dbConnection);
      this.HeaderFiles = new Table<Hefi>(this._ramStorage, this._dbConnection);
      this.HeaderFreeReferences = new Table<Hefr>(this._ramStorage, this._dbConnection);
      this.HeaderLines = new Table<Heli>(this._ramStorage, this._dbConnection);
      this.HeaderLineTypes = new Table<Helt>(this._ramStorage, this._dbConnection);
      this.HeaderOrigins = new Table<Heor>(this._ramStorage, this._dbConnection);
      this.HeaderPartnerAddresses = new Table<Hepa>(this._ramStorage, this._dbConnection);
      this.HeaderStatuses = new Table<Hest>(this._ramStorage, this._dbConnection);
      this.HeaderStatusSteps = new Table<Hess>(this._ramStorage, this._dbConnection);
      this.Payments = new Table<Paym>(this._ramStorage, this._dbConnection);
      this.PaymentModes = new Table<Pamo>(this._ramStorage, this._dbConnection);
      this.Reconciliations = new Table<Reco>(this._ramStorage, this._dbConnection);

      this.Groups = new Table<Grou>(this._ramStorage, this._dbConnection);
      this.GroupModules = new Table<Grmo>(this._ramStorage, this._dbConnection);
      this.Messages = new Table<Mess>(this._ramStorage, this._dbConnection);
      this.MessageRecipients = new Table<Mere>(this._ramStorage, this._dbConnection);
      this.Modules = new Table<Modu>(this._ramStorage, this._dbConnection);
      this.Users = new Table<User>(this._ramStorage, this._dbConnection);
      this.UserActivities = new Table<Usac>(this._ramStorage, this._dbConnection);
      this.UserGroups = new Table<Usgr>(this._ramStorage, this._dbConnection);
      this.UserModules = new Table<Usmo>(this._ramStorage, this._dbConnection);
    }

    public void CreateDatasForTest()
    {
      Arfa family1 = new Arfa() { AccountingEntry = "FAMILY1", Code = "FAMILY1", Description = "Family 1", Designation = "Family 1", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleFamilies.Add(family1);
      Arfa family2 = new Arfa() { AccountingEntry = "FAMILY2", Code = "FAMILY2", Description = "Family 2", Designation = "Family 2", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleFamilies.Add(family2);

      Arsf subFamily1 = new Arsf() { AccountingEntry = "SUBFAMILY1", ArfaId = family1.Id, Code = "SUBFAMILY1", Description = "Sub family 1", Designation = "Sub family 1", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleSubFamilies.Add(subFamily1);
      Arsf subFamily2 = new Arsf() { AccountingEntry = "SUBFAMILY2", ArfaId = family1.Id, Code = "SUBFAMILY2", Description = "Sub family 2", Designation = "Sub family 2", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleSubFamilies.Add(subFamily2);
      Arsf subFamily3 = new Arsf() { AccountingEntry = "SUBFAMILY3", ArfaId = family2.Id, Code = "SUBFAMILY3", Description = "Sub family 3", Designation = "Sub family 3", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleSubFamilies.Add(subFamily3);

      Bran brand = new Bran() { Code = "BRAND", EndingDate = null, Name = "Brand", StartingDate = new System.DateTime(2015, 1, 1) };
      this.Brands.Add(brand);

      Unit unit = new Unit() { Code = "UNITY", Description = "Unity", EndingDate = null, IsCurrency = false, IsPeriod = false, Name = "Unity", StartingDate = new System.DateTime(2015, 1, 1) };
      this.Units.Add(unit);

      Arti article1 = new Arti() { ArfaId = subFamily1.ArfaId, ArsfId = subFamily1.Id, BranId = brand.Id, Code = "ARTICLE1", Description = "Article 1", Designation = "Article 1", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article1);
      Arti article2 = new Arti() { ArfaId = subFamily2.ArfaId, ArsfId = subFamily2.Id, BranId = brand.Id, Code = "ARTICLE2", Description = "Article 2", Designation = "Article 2", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article2);
      Arti article3 = new Arti() { ArfaId = subFamily3.ArfaId, ArsfId = subFamily3.Id, BranId = brand.Id, Code = "ARTICLE3", Description = "Article 3", Designation = "Article 3", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article3);

      User user = this.Users.FirstOrDefault(item => item.IsAdministrator);

      Part partner = new Part() { Code = "UNKOWN PARTNER", CompanyIdentifier = string.Empty, CompanyName = string.Empty, Email = string.Empty, EndingDate = null, FaxNumber = string.Empty, IsCustomer = true, IsSupplier = true, Observation = string.Empty, PhoneNumber = string.Empty, PriceMultiplier = 1, StartingDate = new System.DateTime(2015, 1, 1), UserId = user.Id };
      this.Partners.Add(partner);

      Acti activity = new Acti() { CompanyName = "Bm2s", CountryName = "FRANCE", TownName = "Toulon", TownZipCode = "83000", Address1 = "301 Litorral F MISTRAL", Address2 = string.Empty, Address3 = string.Empty };
      this.Activities.Add(activity);

      Nome nomenclature = new Nome() { ArchId = article2.Id, ArpaId = article1.Id, BuyPrice = 100, QuantityChild = 3, EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.Nomenclatures.Add(nomenclature);

      Hest headerStatus = new Hest() { EndingDate = null, InterveneOnStock = true, Name = "HEADERSTATUS", StartingDate = new System.DateTime(2015, 1, 1) };
      this.HeaderStatuses.Add(headerStatus);

      Head header = new Head() { ActiId = activity.Id, Date = System.DateTime.Now, DeliveryObservation = string.Empty, Description = string.Empty, FooterDiscount = 0, HestId = headerStatus.Id, IsPurchase = false, IsSell = true, Reference = "HEADER1", UserId = user.Id };
      this.Headers.Add(header);

      Helt headerLineType = new Helt() { EndingDate = null, Name = "HEADERLINETYPE1", StartingDate = new System.DateTime(2015, 1, 1) };
      this.HeaderLineTypes.Add(headerLineType);

      Heli headerLine1 = new Heli() { ArtiId = article1.Id, ArfaId = article1.ArfaId, ArsfId = article1.ArsfId, BranId = article1.BranId, Code = article1.Code, Description = article1.Description, Designation = article1.Designation, HeadId = header.Id, BuyPrice = 0, HeltId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 2, SellPrice = 20.10, UnitId = article1.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine1);
      Heli headerLine2 = new Heli() { ArtiId = article2.Id, ArfaId = article2.ArfaId, ArsfId = article2.ArsfId, BranId = article2.BranId, Code = article2.Code, Description = article2.Description, Designation = article2.Designation, HeadId = header.Id, BuyPrice = 0, HeltId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 3, SellPrice = 20.20, UnitId = article2.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine2);
      Heli headerLine3 = new Heli() { ArtiId = article3.Id, ArfaId = article3.ArfaId, ArsfId = article3.ArsfId, BranId = article3.BranId, Code = article3.Code, Description = article3.Description, Designation = article3.Designation, HeadId = header.Id, BuyPrice = 0, HeltId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 4, SellPrice = 20.30, UnitId = article3.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine3);
    }

    public void ReloadDatas()
    {
      this.Articles.ReloadData();
      this.ArticleFamilies.ReloadData();
      this.ArticleFamilyPricePartners.ReloadData();
      this.ArticleFamilyPricePartnerFamilies.ReloadData();
      this.ArticlePricePartners.ReloadData();
      this.ArticlePricePartnerFamilies.ReloadData();
      this.ArticleSubFamilies.ReloadData();
      this.ArticleSubFamilyPricePartners.ReloadData();
      this.ArticleSubFamilyPricePartnerFamilies.ReloadData();
      this.Brands.ReloadData();
      this.Nomenclatures.ReloadData();
      this.Prices.ReloadData();
      this.Subscriptions.ReloadData();
      this.SubscriptionPartners.ReloadData();

      this.Activities.ReloadData();
      this.Affairs.ReloadData();
      this.AffairFiles.ReloadData();
      this.AffairHeaders.ReloadData();
      this.ArticleFamilyPartnerFamilyVats.ReloadData();
      this.ArticleFamilyPartnerVats.ReloadData();
      this.ArticlePartnerFamilyVats.ReloadData();
      this.ArticlePartnerVats.ReloadData();
      this.ArticleSubFamilyPartnerFamilyVats.ReloadData();
      this.ArticleSubFamilyPartnerVats.ReloadData();
      this.Countries.ReloadData();
      this.CountryCurrencies.ReloadData();
      this.InventoryHeaders.ReloadData();
      this.InventoryLines.ReloadData();
      this.Languages.ReloadData();
      this.Parameters.ReloadData();
      this.UserParameters.ReloadData();
      this.Periods.ReloadData();
      this.Towns.ReloadData();
      this.Translations.ReloadData();
      this.Units.ReloadData();
      this.UnitConversions.ReloadData();
      this.Vats.ReloadData();

      this.Addresses.ReloadData();
      this.AddressLines.ReloadData();
      this.AddressTypes.ReloadData();
      this.Partners.ReloadData();
      this.PartnerAddresses.ReloadData();
      this.PartnerContacts.ReloadData();
      this.PartnerFamilies.ReloadData();
      this.PartnerFiles.ReloadData();
      this.PartnerPartnerFamilies.ReloadData();

      this.Headers.ReloadData();
      this.HeaderFiles.ReloadData();
      this.HeaderFreeReferences.ReloadData();
      this.HeaderLines.ReloadData();
      this.HeaderLineTypes.ReloadData();
      this.HeaderOrigins.ReloadData();
      this.HeaderPartnerAddresses.ReloadData();
      this.HeaderStatuses.ReloadData();
      this.HeaderStatusSteps.ReloadData();
      this.Payments.ReloadData();
      this.PaymentModes.ReloadData();
      this.Reconciliations.ReloadData();

      this.Groups.ReloadData();
      this.GroupModules.ReloadData();
      this.Messages.ReloadData();
      this.MessageRecipients.ReloadData();
      this.Modules.ReloadData();
      this.Users.ReloadData();
      this.UserActivities.ReloadData();
      this.UserGroups.ReloadData();
      this.UserModules.ReloadData();
    }
  }
}
