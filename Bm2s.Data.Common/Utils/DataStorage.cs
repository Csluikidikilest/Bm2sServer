using Bm2s.Data.Common.BLL;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.BLL.Trade;
using Bm2s.Data.Common.BLL.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Utils
{
  public class DataStorage
  {
    private IDbConnection _dbConnection;
    private bool _ramStorage;

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
    public Tables<SelectorColumn> SelectorColumns { get; set; }
    public Tables<SelectorScreen> SelectorScreens { get; set; }
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
    public Tables<GroupSelectorColumn> GroupSelectorColumns { get; set; }
    public Tables<Module> Modules { get; set; }
    public Tables<User> Users { get; set; }
    public Tables<UserActivity> UserActivities { get; set; }
    public Tables<UserGroup> UserGroups { get; set; }
    public Tables<UserModule> UserModules { get; set; }
    public Tables<UserSelectorColumn> UserSelectorColumns { get; set; }

    public DataStorage(bool ramStorage, IDbConnection dbConnection)
    {
      this._dbConnection = dbConnection;
      this._ramStorage = ramStorage;

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
      this.SelectorColumns = new Tables<SelectorColumn>(this._ramStorage, this._dbConnection);
      this.SelectorScreens = new Tables<SelectorScreen>(this._ramStorage, this._dbConnection);
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
      //this.GroupSelectorColumns = new Tables<GroupSelectorColumn>(this._ramStorage, this._dbConnection);
      this.Modules = new Tables<Module>(this._ramStorage, this._dbConnection);
      this.Users = new Tables<User>(this._ramStorage, this._dbConnection);
      this.UserActivities = new Tables<UserActivity>(this._ramStorage, this._dbConnection);
      this.UserGroups = new Tables<UserGroup>(this._ramStorage, this._dbConnection);
      this.UserModules = new Tables<UserModule>(this._ramStorage, this._dbConnection);
      //this.UserSelectorColumns = new Tables<UserSelectorColumn>(this._ramStorage, this._dbConnection);
    }

    public void LazyLoad()
    {
      this.Articles.LazyLoad();
      this.ArticleFamilies.LazyLoad();
      this.ArticleFamilyPricePartners.LazyLoad();
      this.ArticleFamilyPricePartnerFamilies.LazyLoad();
      this.ArticlePricePartners.LazyLoad();
      this.ArticlePricePartnerFamilies.LazyLoad();
      this.ArticleSubFamilies.LazyLoad();
      this.ArticleSubFamilyPricePartners.LazyLoad();
      this.ArticleSubFamilyPricePartnerFamilies.LazyLoad();
      this.Brands.LazyLoad();
      this.Nomenclatures.LazyLoad();
      this.Prices.LazyLoad();
      this.Subscriptions.LazyLoad();
      this.SubscriptionPartners.LazyLoad();

      this.Activities.LazyLoad();
      this.Affairs.LazyLoad();
      this.AffairFiles.LazyLoad();
      this.AffairHeaders.LazyLoad();
      this.ArticleFamilyPartnerFamilyVats.LazyLoad();
      this.ArticleFamilyPartnerVats.LazyLoad();
      this.ArticlePartnerFamilyVats.LazyLoad();
      this.ArticlePartnerVats.LazyLoad();
      this.ArticleSubFamilyPartnerFamilyVats.LazyLoad();
      this.ArticleSubFamilyPartnerVats.LazyLoad();
      this.Countries.LazyLoad();
      this.CountryCurrencies.LazyLoad();
      this.InventoryHeaders.LazyLoad();
      this.InventoryLines.LazyLoad();
      this.Parameters.LazyLoad();
      this.Periods.LazyLoad();
      this.SelectorColumns.LazyLoad();
      this.SelectorScreens.LazyLoad();
      this.Towns.LazyLoad();
      this.Units.LazyLoad();
      this.UnitConversions.LazyLoad();
      this.Vats.LazyLoad();

      this.Addresses.LazyLoad();
      this.AddressLines.LazyLoad();
      this.AddressTypes.LazyLoad();
      this.Partners.LazyLoad();
      this.PartnerAddresses.LazyLoad();
      this.PartnerContacts.LazyLoad();
      this.PartnerFamilies.LazyLoad();
      this.PartnerFiles.LazyLoad();
      this.PartnerPartnerFamilies.LazyLoad();

      this.Headers.LazyLoad();
      this.HeaderFiles.LazyLoad();
      this.HeaderFreeReferences.LazyLoad();
      this.HeaderLines.LazyLoad();
      this.HeaderLineTypes.LazyLoad();
      this.HeaderOrigins.LazyLoad();
      this.HeaderPartnerAddresses.LazyLoad();
      this.HeaderStatuses.LazyLoad();
      this.HeaderStatusSteps.LazyLoad();
      this.Payments.LazyLoad();
      this.PaymentModes.LazyLoad();
      this.Reconciliations.LazyLoad();

      this.Groups.LazyLoad();
      this.GroupModules.LazyLoad();
      this.GroupSelectorColumns.LazyLoad();
      this.Modules.LazyLoad();
      this.Users.LazyLoad();
      this.UserActivities.LazyLoad();
      this.UserGroups.LazyLoad();
      this.UserModules.LazyLoad();
      this.UserSelectorColumns.LazyLoad();
    }
  }
}
