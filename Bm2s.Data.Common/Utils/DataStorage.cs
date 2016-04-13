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
    public Table<Article> Articles { get; set; }
    public Table<ArticleFamily> ArticleFamilies { get; set; }
    public Table<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }
    public Table<ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
    public Table<ArticlePricePartner> ArticlePricePartners { get; set; }
    public Table<ArticlePricePartnerFamily> ArticlePricePartnerFamilies { get; set; }
    public Table<ArticleSubFamily> ArticleSubFamilies { get; set; }
    public Table<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }
    public Table<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
    public Table<Brand> Brands { get; set; }
    public Table<Nomenclature> Nomenclatures { get; set; }
    public Table<Price> Prices { get; set; }
    public Table<Subscription> Subscriptions { get; set; }
    public Table<SubscriptionPartner> SubscriptionPartners { get; set; }

    public Table<Activity> Activities { get; set; }
    public Table<Affair> Affairs { get; set; }
    public Table<AffairFile> AffairFiles { get; set; }
    public Table<AffairHeader> AffairHeaders { get; set; }
    public Table<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
    public Table<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }
    public Table<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
    public Table<ArticlePartnerVat> ArticlePartnerVats { get; set; }
    public Table<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
    public Table<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }
    public Table<Country> Countries { get; set; }
    public Table<CountryCurrency> CountryCurrencies { get; set; }
    public Table<InventoryHeader> InventoryHeaders { get; set; }
    public Table<InventoryLine> InventoryLines { get; set; }
    public Table<Language> Languages { get; set; }
    public Table<Parameter> Parameters { get; set; }
    public Table<UserParameter> UserParameters { get; set; }
    public Table<Period> Periods { get; set; }
    public Table<Town> Towns { get; set; }
    public Table<Translation> Translations { get; set; }
    public Table<Unit> Units { get; set; }
    public Table<UnitConversion> UnitConversions { get; set; }
    public Table<Vat> Vats { get; set; }

    public Table<Address> Addresses { get; set; }
    public Table<AddressLine> AddressLines { get; set; }
    public Table<AddressType> AddressTypes { get; set; }
    public Table<Partner> Partners { get; set; }
    public Table<PartnerAddress> PartnerAddresses { get; set; }
    public Table<PartnerContact> PartnerContacts { get; set; }
    public Table<PartnerFamily> PartnerFamilies { get; set; }
    public Table<PartnerFile> PartnerFiles { get; set; }
    public Table<PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }

    public Table<Header> Headers { get; set; }
    public Table<HeaderFile> HeaderFiles { get; set; }
    public Table<HeaderFreeReference> HeaderFreeReferences { get; set; }
    public Table<HeaderLine> HeaderLines { get; set; }
    public Table<HeaderLineType> HeaderLineTypes { get; set; }
    public Table<HeaderOrigin> HeaderOrigins { get; set; }
    public Table<HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
    public Table<HeaderStatus> HeaderStatuses { get; set; }
    public Table<HeaderStatusStep> HeaderStatusSteps { get; set; }
    public Table<Payment> Payments { get; set; }
    public Table<PaymentMode> PaymentModes { get; set; }
    public Table<Reconciliation> Reconciliations { get; set; }

    public Table<Group> Groups { get; set; }
    public Table<GroupModule> GroupModules { get; set; }
    public Table<Message> Messages { get; set; }
    public Table<MessageRecipient> MessageRecipients { get; set; }
    public Table<Module> Modules { get; set; }
    public Table<User> Users { get; set; }
    public Table<UserActivity> UserActivities { get; set; }
    public Table<UserGroup> UserGroups { get; set; }
    public Table<UserModule> UserModules { get; set; }

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
      : base(ramStorage, dbConnection)
    {
      this.Articles = new Table<Article>(this._ramStorage, this._dbConnection);
      this.ArticleFamilies = new Table<ArticleFamily>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPricePartners = new Table<ArticleFamilyPricePartner>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPricePartnerFamilies = new Table<ArticleFamilyPricePartnerFamily>(this._ramStorage, this._dbConnection);
      this.ArticlePricePartners = new Table<ArticlePricePartner>(this._ramStorage, this._dbConnection);
      this.ArticlePricePartnerFamilies = new Table<ArticlePricePartnerFamily>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilies = new Table<ArticleSubFamily>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPricePartners = new Table<ArticleSubFamilyPricePartner>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPricePartnerFamilies = new Table<ArticleSubFamilyPricePartnerFamily>(this._ramStorage, this._dbConnection);
      this.Brands = new Table<Brand>(this._ramStorage, this._dbConnection);
      this.Nomenclatures = new Table<Nomenclature>(this._ramStorage, this._dbConnection);
      this.Prices = new Table<Price>(this._ramStorage, this._dbConnection);
      this.Subscriptions = new Table<Subscription>(this._ramStorage, this._dbConnection);
      this.SubscriptionPartners = new Table<SubscriptionPartner>(this._ramStorage, this._dbConnection);

      this.Activities = new Table<Activity>(this._ramStorage, this._dbConnection);
      this.Affairs = new Table<Affair>(this._ramStorage, this._dbConnection);
      this.AffairFiles = new Table<AffairFile>(this._ramStorage, this._dbConnection);
      this.AffairHeaders = new Table<AffairHeader>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPartnerFamilyVats = new Table<ArticleFamilyPartnerFamilyVat>(this._ramStorage, this._dbConnection);
      this.ArticleFamilyPartnerVats = new Table<ArticleFamilyPartnerVat>(this._ramStorage, this._dbConnection);
      this.ArticlePartnerFamilyVats = new Table<ArticlePartnerFamilyVat>(this._ramStorage, this._dbConnection);
      this.ArticlePartnerVats = new Table<ArticlePartnerVat>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPartnerFamilyVats = new Table<ArticleSubFamilyPartnerFamilyVat>(this._ramStorage, this._dbConnection);
      this.ArticleSubFamilyPartnerVats = new Table<ArticleSubFamilyPartnerVat>(this._ramStorage, this._dbConnection);
      this.Countries = new Table<Country>(this._ramStorage, this._dbConnection);
      this.CountryCurrencies = new Table<CountryCurrency>(this._ramStorage, this._dbConnection);
      this.InventoryHeaders = new Table<InventoryHeader>(this._ramStorage, this._dbConnection);
      this.InventoryLines = new Table<InventoryLine>(this._ramStorage, this._dbConnection);
      this.Languages = new Table<Language>(this._ramStorage, this._dbConnection);
      this.Parameters = new Table<Parameter>(this._ramStorage, this._dbConnection);
      this.UserParameters = new Table<UserParameter>(this._ramStorage, this._dbConnection);
      this.Periods = new Table<Period>(this._ramStorage, this._dbConnection);
      this.Towns = new Table<Town>(this._ramStorage, this._dbConnection);
      this.Translations = new Table<Translation>(this._ramStorage, this._dbConnection);
      this.Units = new Table<Unit>(this._ramStorage, this._dbConnection);
      this.UnitConversions = new Table<UnitConversion>(this._ramStorage, this._dbConnection);
      this.Vats = new Table<Vat>(this._ramStorage, this._dbConnection);

      this.Addresses = new Table<Address>(this._ramStorage, this._dbConnection);
      this.AddressLines = new Table<AddressLine>(this._ramStorage, this._dbConnection);
      this.AddressTypes = new Table<AddressType>(this._ramStorage, this._dbConnection);
      this.Partners = new Table<Partner>(this._ramStorage, this._dbConnection);
      this.PartnerAddresses = new Table<PartnerAddress>(this._ramStorage, this._dbConnection);
      this.PartnerContacts = new Table<PartnerContact>(this._ramStorage, this._dbConnection);
      this.PartnerFamilies = new Table<PartnerFamily>(this._ramStorage, this._dbConnection);
      this.PartnerFiles = new Table<PartnerFile>(this._ramStorage, this._dbConnection);
      this.PartnerPartnerFamilies = new Table<PartnerPartnerFamily>(this._ramStorage, this._dbConnection);

      this.Headers = new Table<Header>(this._ramStorage, this._dbConnection);
      this.HeaderFiles = new Table<HeaderFile>(this._ramStorage, this._dbConnection);
      this.HeaderFreeReferences = new Table<HeaderFreeReference>(this._ramStorage, this._dbConnection);
      this.HeaderLines = new Table<HeaderLine>(this._ramStorage, this._dbConnection);
      this.HeaderLineTypes = new Table<HeaderLineType>(this._ramStorage, this._dbConnection);
      this.HeaderOrigins = new Table<HeaderOrigin>(this._ramStorage, this._dbConnection);
      this.HeaderPartnerAddresses = new Table<HeaderPartnerAddress>(this._ramStorage, this._dbConnection);
      this.HeaderStatuses = new Table<HeaderStatus>(this._ramStorage, this._dbConnection);
      this.HeaderStatusSteps = new Table<HeaderStatusStep>(this._ramStorage, this._dbConnection);
      this.Payments = new Table<Payment>(this._ramStorage, this._dbConnection);
      this.PaymentModes = new Table<PaymentMode>(this._ramStorage, this._dbConnection);
      this.Reconciliations = new Table<Reconciliation>(this._ramStorage, this._dbConnection);

      this.Groups = new Table<Group>(this._ramStorage, this._dbConnection);
      this.GroupModules = new Table<GroupModule>(this._ramStorage, this._dbConnection);
      this.Messages = new Table<Message>(this._ramStorage, this._dbConnection);
      this.MessageRecipients = new Table<MessageRecipient>(this._ramStorage, this._dbConnection);
      this.Modules = new Table<Module>(this._ramStorage, this._dbConnection);
      this.Users = new Table<User>(this._ramStorage, this._dbConnection);
      this.UserActivities = new Table<UserActivity>(this._ramStorage, this._dbConnection);
      this.UserGroups = new Table<UserGroup>(this._ramStorage, this._dbConnection);
      this.UserModules = new Table<UserModule>(this._ramStorage, this._dbConnection);
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

      Brand brand = new Brand() { Code = "BRAND", EndingDate = null, Name = "Brand", StartingDate = new System.DateTime(2015, 1, 1) };
      this.Brands.Add(brand);

      Unit unit = new Unit() { Code = "UNITY", Description = "Unity", EndingDate = null, IsCurrency = false, IsPeriod = false, Name = "Unity", StartingDate = new System.DateTime(2015, 1, 1) };
      this.Units.Add(unit);

      Article article1 = new Article() { ArticleFamilyId = subFamily1.ArticleFamilyId, ArticleSubFamilyId = subFamily1.Id, BrandId = brand.Id, Code = "ARTICLE1", Description = "Article 1", Designation = "Article 1", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article1);
      Article article2 = new Article() { ArticleFamilyId = subFamily2.ArticleFamilyId, ArticleSubFamilyId = subFamily2.Id, BrandId = brand.Id, Code = "ARTICLE2", Description = "Article 2", Designation = "Article 2", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article2);
      Article article3 = new Article() { ArticleFamilyId = subFamily3.ArticleFamilyId, ArticleSubFamilyId = subFamily3.Id, BrandId = brand.Id, Code = "ARTICLE3", Description = "Article 3", Designation = "Article 3", EndingDate = null, Observation = string.Empty, StartingDate = new System.DateTime(2015, 1, 1), UnitId = unit.Id };
      this.Articles.Add(article3);

      User user = this.Users.FirstOrDefault(item => item.IsAdministrator);

      Partner partner = new Partner() { Code = "UNKOWN PARTNER", CompanyIdentifier = string.Empty, CompanyName = string.Empty, Email = string.Empty, EndingDate = null, FaxNumber = string.Empty, IsCustomer = true, IsSupplier = true, Observation = string.Empty, PhoneNumber = string.Empty, PriceMultiplier = 1, StartingDate = new System.DateTime(2015, 1, 1), UserId = user.Id };
      this.Partners.Add(partner);

      Activity activity = new Activity() { CompanyName = "Bm2s", CountryName = "FRANCE", TownName = "Toulon", TownZipCode = "83000", Address1 = "301 Litorral F MISTRAL", Address2 = string.Empty, Address3 = string.Empty };
      this.Activities.Add(activity);

      Nomenclature nomenclature = new Nomenclature() { ArticleChildId = article2.Id, ArticleParentId = article1.Id, BuyPrice = 100, QuantityChild = 3, EndingDate = null, StartingDate = new System.DateTime(2015, 1, 1) };
      this.Nomenclatures.Add(nomenclature);

      HeaderStatus headerStatus = new HeaderStatus() { EndingDate = null, InterveneOnStock = true, Name = "HEADERSTATUS", StartingDate = new System.DateTime(2015, 1, 1) };
      this.HeaderStatuses.Add(headerStatus);

      Header header = new Header() { ActivityId = activity.Id, Date = System.DateTime.Now, DeliveryObservation = string.Empty, Description = string.Empty, FooterDiscount = 0, HeaderStatusId = headerStatus.Id, IsPurchase = false, IsSell = true, Reference = "HEADER1", UserId = user.Id };
      this.Headers.Add(header);

      HeaderLineType headerLineType = new HeaderLineType() { EndingDate = null, Name = "HEADERLINETYPE1", StartingDate = new System.DateTime(2015, 1, 1) };
      this.HeaderLineTypes.Add(headerLineType);

      HeaderLine headerLine1 = new HeaderLine() { ArticleId = article1.Id, ArticleFamilyId = article1.ArticleFamilyId, ArticleSubFamilyId = article1.ArticleSubFamilyId, BrandId = article1.BrandId, Code = article1.Code, Description = string.Empty, Designation = string.Empty, HeaderId = header.Id, BuyPrice = 0, HeaderLineTypeId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 2, SellPrice = 20.10, UnitId = article1.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine1);
      HeaderLine headerLine2 = new HeaderLine() { ArticleId = article2.Id, ArticleFamilyId = article2.ArticleFamilyId, ArticleSubFamilyId = article2.ArticleSubFamilyId, BrandId = article2.BrandId, Code = article2.Code, Description = string.Empty, Designation = string.Empty, HeaderId = header.Id, BuyPrice = 0, HeaderLineTypeId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 3, SellPrice = 20.20, UnitId = article2.UnitId, VatRate = 19.6 };
      this.HeaderLines.Add(headerLine2);
      HeaderLine headerLine3 = new HeaderLine() { ArticleId = article3.Id, ArticleFamilyId = article3.ArticleFamilyId, ArticleSubFamilyId = article3.ArticleSubFamilyId, BrandId = article3.BrandId, Code = article3.Code, Description = string.Empty, Designation = string.Empty, HeaderId = header.Id, BuyPrice = 0, HeaderLineTypeId = headerLineType.Id, IsPrintable = true, LineNumber = 1, Quantity = 4, SellPrice = 20.30, UnitId = article3.UnitId, VatRate = 19.6 };
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
