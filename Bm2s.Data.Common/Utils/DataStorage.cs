using System.Data;
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
    public Tables<Article> Articles { get; set; }
    public Tables<ArticleFamily> ArticleFamilies { get; set; }
    public Tables<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
    public Tables<ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
    public Tables<ArticlePricePartner> ArticlePricePartners { get; set; }
    public Tables<ArticlePricePartnerFamily> ArticlePricePartnerFamilies { get; set; }
    public Tables<ArticleSubFamily> ArticleSubFamilies { get; set; }
    public Tables<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
    public Tables<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
    public Tables<Brand> Brands { get; set; }
    public Tables<Nomenclature> Nomenclatures { get; set; }
    public Tables<Price> Prices { get; set; }
    public Tables<Subscription> Subscriptions { get; set; }
    public Tables<SubscriptionPartner> SubscriptionPartners { get; set; }

    public Tables<Activity> Activities { get; set; }
    public Tables<Affair> Affairs { get; set; }
    public Tables<AffairFile> AffairFiles { get; set; }
    public Tables<AffairHeader> AffairHeaders { get; set; }
    public Tables<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
    public Tables<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
    public Tables<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
    public Tables<ArticlePartnerVat> ArticlePartnerVats { get; set; }
    public Tables<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
    public Tables<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
    public Tables<Country> Countries { get; set; }
    public Tables<CountryCurrency> CountryCurrencies { get; set; }
    public Tables<InventoryHeader> InventoryHeaders { get; set; }
    public Tables<InventoryLine> InventoryLines { get; set; }
    public Tables<Parameter> Parameters { get; set; }
    public Tables<Period> Periods { get; set; }
    public Tables<Town> Towns { get; set; }
    public Tables<Unit> Units { get; set; }
    public Tables<UnitConversion> UnitConversions { get; set; }
    public Tables<Vat> Vats { get; set; }

    public Tables<Address> Addresses { get; set; }
    public Tables<AddressLine> AddressLines { get; set; }
    public Tables<AddressType> AddressTypes { get; set; }
    public Tables<Partner> Partners { get; set; }
    public Tables<PartnerAddress> PartnerAddresses { get; set; }
    public Tables<PartnerContact> PartnerContacts { get; set; }
    public Tables<PartnerFamily> PartnerFamilies { get; set; }
    public Tables<PartnerFile> PartnerFiles { get; set; }
    public Tables<PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }

    public Tables<Header> Headers { get; set; }
    public Tables<HeaderFile> HeaderFiles { get; set; }
    public Tables<HeaderFreeReference> HeaderFreeReferences { get; set; }
    public Tables<HeaderLine> HeaderLines { get; set; }
    public Tables<HeaderLineType> HeaderLineTypes { get; set; }
    public Tables<HeaderOrigin> HeaderOrigins { get; set; }
    public Tables<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
    public Tables<HeaderStatus> HeaderStatuses { get; set; }
    public Tables<HeaderStatusStep> HeaderStatusSteps { get; set; }
    public Tables<Payment> Payments { get; set; }
    public Tables<PaymentMode> PaymentModes { get; set; }
    public Tables<Reconciliation> Reconciliations { get; set; }

    public Tables<Group> Groups { get; set; }
    public Tables<GroupModule> GroupModules { get; set; }
    public Tables<Module> Modules { get; set; }
    public Tables<User> Users { get; set; }
    public Tables<UserActivity> UserActivities { get; set; }
    public Tables<UserGroup> UserGroups { get; set; }
    public Tables<UserModule> UserModules { get; set; }

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
      : base(ramStorage, dbConnection)
    {
      this.Articles = new Tables<Article>(this._ramStorage, this._dbConnection);
      this.ArticleFamilies = new Tables<ArticleFamily>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPricePartners = new Tables<ArticleFamilyPricePartner>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPricePartnerFamilies = new Tables<ArticleFamilyPricePartnerFamily>(this._ramStorage, this._dbConnection);
      this.ArticlePricePartners = new Tables<ArticlePricePartner>(this._ramStorage, this._dbConnection);
      this.ArticlePricePartnerFamilies = new Tables<ArticlePricePartnerFamily>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilies = new Tables<ArticleSubFamily>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPricePartners = new Tables<ArticleSubFamilyPricePartner>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPricePartnerFamilies = new Tables<ArticleSubFamilyPricePartnerFamily>(this._ramStorage, this._dbConnection);
      this.Brands = new Tables<Brand>(this._ramStorage, this._dbConnection);
      this.Nomenclatures = new Tables<Nomenclature>(this._ramStorage, this._dbConnection);
      this.Prices = new Tables<Price>(this._ramStorage, this._dbConnection);
      this.Subscriptions = new Tables<Subscription>(this._ramStorage, this._dbConnection);
      this.SubscriptionPartners = new Tables<SubscriptionPartner>(this._ramStorage, this._dbConnection);

      this.Activities = new Tables<Activity>(this._ramStorage, this._dbConnection);
      this.Affairs = new Tables<Affair>(this._ramStorage, this._dbConnection);
      this.AffairFiles = new Tables<AffairFile>(this._ramStorage, this._dbConnection);
      this.AffairHeaders = new Tables<AffairHeader>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPartnerFamilyVats = new Tables<ArticleFamilyPartnerFamilyVat>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPartnerVats = new Tables<ArticleFamilyPartnerVat>(this._ramStorage, this._dbConnection);
      this.ArticlePartnerFamilyVats = new Tables<ArticlePartnerFamilyVat>(this._ramStorage, this._dbConnection);
      this.ArticlePartnerVats = new Tables<ArticlePartnerVat>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPartnerFamilyVats = new Tables<ArticleSubFamilyPartnerFamilyVat>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPartnerVats = new Tables<ArticleSubFamilyPartnerVat>(this._ramStorage, this._dbConnection);
      this.Countries = new Tables<Country>(this._ramStorage, this._dbConnection);
      this.CountryCurrencies = new Tables<CountryCurrency>(this._ramStorage, this._dbConnection);
      this.InventoryHeaders = new Tables<InventoryHeader>(this._ramStorage, this._dbConnection);
      this.InventoryLines = new Tables<InventoryLine>(this._ramStorage, this._dbConnection);
      this.Parameters = new Tables<Parameter>(this._ramStorage, this._dbConnection);
      this.Periods = new Tables<Period>(this._ramStorage, this._dbConnection);
      this.Towns = new Tables<Town>(this._ramStorage, this._dbConnection);
      this.Units = new Tables<Unit>(this._ramStorage, this._dbConnection);
      this.UnitConversions = new Tables<UnitConversion>(this._ramStorage, this._dbConnection);
      this.Vats = new Tables<Vat>(this._ramStorage, this._dbConnection);

      this.Addresses = new Tables<Address>(this._ramStorage, this._dbConnection);
      this.AddressLines = new Tables<AddressLine>(this._ramStorage, this._dbConnection);
      this.AddressTypes = new Tables<AddressType>(this._ramStorage, this._dbConnection);
      this.Partners = new Tables<Partner>(this._ramStorage, this._dbConnection);
      this.PartnerAddresses = new Tables<PartnerAddress>(this._ramStorage, this._dbConnection);
      this.PartnerContacts = new Tables<PartnerContact>(this._ramStorage, this._dbConnection);
      this.PartnerFamilies = new Tables<PartnerFamily>(this._ramStorage, this._dbConnection);
      this.PartnerFiles = new Tables<PartnerFile>(this._ramStorage, this._dbConnection);
      this.PartnerPartnerFamilies = new Tables<PartnerPartnerFamily>(this._ramStorage, this._dbConnection);

      this.Headers = new Tables<Header>(this._ramStorage, this._dbConnection);
      this.HeaderFiles = new Tables<HeaderFile>(this._ramStorage, this._dbConnection);
      this.HeaderFreeReferences = new Tables<HeaderFreeReference>(this._ramStorage, this._dbConnection);
      this.HeaderLines = new Tables<HeaderLine>(this._ramStorage, this._dbConnection);
      this.HeaderLineTypes = new Tables<HeaderLineType>(this._ramStorage, this._dbConnection);
      this.HeaderOrigins = new Tables<HeaderOrigin>(this._ramStorage, this._dbConnection);
      this.HeaderPartnerAddresses = new Tables<HeaderPartnerAddress>(this._ramStorage, this._dbConnection);
      this.HeaderStatuses = new Tables<HeaderStatus>(this._ramStorage, this._dbConnection);
      this.HeaderStatusSteps = new Tables<HeaderStatusStep>(this._ramStorage, this._dbConnection);
      this.Payments = new Tables<Payment>(this._ramStorage, this._dbConnection);
      this.PaymentModes = new Tables<PaymentMode>(this._ramStorage, this._dbConnection);
      this.Reconciliations = new Tables<Reconciliation>(this._ramStorage, this._dbConnection);

      this.Groups = new Tables<Group>(this._ramStorage, this._dbConnection);
      this.GroupModules = new Tables<GroupModule>(this._ramStorage, this._dbConnection);
      this.Modules = new Tables<Module>(this._ramStorage, this._dbConnection);
      this.Users = new Tables<User>(this._ramStorage, this._dbConnection);
      this.UserActivities = new Tables<UserActivity>(this._ramStorage, this._dbConnection);
      this.UserGroups = new Tables<UserGroup>(this._ramStorage, this._dbConnection);
      this.UserModules = new Tables<UserModule>(this._ramStorage, this._dbConnection);
    }

    public void CreateDatasForTest()
    {
      ArticleFamily family1 = new ArticleFamily() { AccountingEntry = "FAMILY1", Code = "FAMILY1", Description = "Family 1", Designation = "Family 1", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleFamilies.Add(family1);
      ArticleFamily family2 = new ArticleFamily() { AccountingEntry = "FAMILY2", Code = "FAMILY2", Description = "Family 2", Designation = "Family 2", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleFamilies.Add(family2);

      ArticleSubFamily subFamily1 = new ArticleSubFamily() { AccountingEntry = "SUBFAMILY1", ArticleFamilyId = family1.Id, Code = "SUBFAMILY1", Description = "Sub family 1", Designation = "Sub family 1", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleSubFamilies.Add(subFamily1);
      ArticleSubFamily subFamily2 = new ArticleSubFamily() { AccountingEntry = "SUBFAMILY2", ArticleFamilyId = family1.Id, Code = "SUBFAMILY2", Description = "Sub family 2", Designation = "Sub family 2", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleSubFamilies.Add(subFamily2);
      ArticleSubFamily subFamily3 = new ArticleSubFamily() { AccountingEntry = "SUBFAMILY3", ArticleFamilyId = family2.Id, Code = "SUBFAMILY3", Description = "Sub family 3", Designation = "Sub family 3", EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.ArticleSubFamilies.Add(subFamily3);

      Brand brand = new Brand() { Code = "BRAND", EndingDate = null, Name = "Brand", StartingDate = new System.DateTime(2015, 1,1)};
      this.Brands.Add(brand);

      Unit unit = new Unit(){ Code = "UNITY", Description = "Unity", EndingDate = null, IsCurrency = false, IsPeriod = false, Name = "Unity", StartingDate = new System.DateTime(2015,1,1)};
      this.Units.Add(unit);

      Article article1 = new Article() { ArticleFamilyId = subFamily1.ArticleFamilyId, ArticleSubFamilyId = subFamily1.Id, BrandId = brand.Id, Code = "ARTICLE1", Description = "Article 1", Designation = "Article 1", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article1);
      Article article2 = new Article() { ArticleFamilyId = subFamily2.ArticleFamilyId, ArticleSubFamilyId = subFamily2.Id, BrandId = brand.Id, Code = "ARTICLE2", Description = "Article 2", Designation = "Article 2", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article2);
      Article article3 = new Article() { ArticleFamilyId = subFamily3.ArticleFamilyId, ArticleSubFamilyId = subFamily3.Id, BrandId = brand.Id, Code = "ARTICLE3", Description = "Article 3", Designation = "Article 3", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article3);

      User user = new User(){ EndingDate = null, FirstName = "ADMINISTRATOR", IsAdministrator = true, IsAnonymous = false, LastName = string.Empty, Login = "Admin", Password = "Admin", StartingDate= new System.DateTime(2015,1,1)};
      this.Users.Add(user);

      Partner partner = new Partner() { Code = "UNKOWN PARTNER", CompanyIdentifier = string.Empty, CompanyName = string.Empty, Email = string.Empty, EndingDate = null, FaxNumber = string.Empty, IsCustomer = true, IsSupplier = true, Observation = string.Empty, PhoneNumber = string.Empty, PriceMultiplier = 1, StartingDate = new System.DateTime(2015, 1, 1), UserId = user.Id };
      this.Partners.Add(partner);

      Activity activity = new Activity(){ CompanyName = "Bm2s", CountryName = "FRANCE", TownName="Toulon", TownZipCode = "83000", Address1 = "301 Litorral F MISTRAL", Address2 = string.Empty, Address3 = string.Empty};
      this.Activities.Add(activity);

      HeaderStatus headerStatus = new HeaderStatus() { EndingDate = null, InterveneOnStock = true, Name = "HEADERSTATUS", StartingDate = new System.DateTime(2015, 1, 1) };
      this.HeaderStatuses.Add(headerStatus);

      Header header = new Header() { ActivityId = activity.Id, Date = System.DateTime.Now, DeliveryObservation = string.Empty, Description = string.Empty, FooterDiscount = 0, HeaderStatusId = headerStatus.Id, IsSell = true, Reference = "HEADER1", UserId = user.Id };
      this.Headers.Add(header);

      HeaderLineType headerLineType = new HeaderLineType(){ EndingDate = null, Name= "HEADERLINETYPE1", StartingDate = new System.DateTime(2015,1,1)};
      this.HeaderLineTypes.Add(headerLineType);

      HeaderLine headerLine1 = new HeaderLine() { ArticleId = article1.Id, ArticleFamilyId = article1.ArticleFamilyId, ArticleSubFamilyId = article1.ArticleSubFamilyId, BrandId = article1.BrandId, Code = article1.Code, Description = string.Empty, Designation = string.Empty, HeaderId = header.Id, BuyPrice = 0, HeaderLineTypeId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 2, SellPrice = 20.10, UnitId = article1.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine1);
      HeaderLine headerLine2 = new HeaderLine() { ArticleId = article2.Id, ArticleFamilyId = article2.ArticleFamilyId, ArticleSubFamilyId = article2.ArticleSubFamilyId, BrandId = article2.BrandId, Code = article2.Code, Description = string.Empty, Designation = string.Empty, HeaderId = header.Id, BuyPrice = 0, HeaderLineTypeId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 3, SellPrice = 20.20, UnitId = article2.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine2);
      HeaderLine headerLine3 = new HeaderLine() { ArticleId = article3.Id, ArticleFamilyId = article3.ArticleFamilyId, ArticleSubFamilyId = article3.ArticleSubFamilyId, BrandId = article3.BrandId, Code = article3.Code, Description = string.Empty, Designation = string.Empty, HeaderId = header.Id, BuyPrice = 0, HeaderLineTypeId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 4, SellPrice = 20.30, UnitId = article3.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine3);
    }
  }
}
