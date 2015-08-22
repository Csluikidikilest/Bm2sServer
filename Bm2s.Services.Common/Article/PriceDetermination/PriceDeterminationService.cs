using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Collections.Generic;
using System.Linq;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Partner.PartnerPartnerFamily;
using Bm2s.Services.Common.Article.Price;
using Bm2s.Services.Common.Article.ArticleFamilyPricePartnerFamily;
using Bm2s.Services.Common.Article.ArticleFamilyPricePartner;
using Bm2s.Services.Common.Article.ArticleSubFamilyPricePartnerFamily;
using Bm2s.Services.Common.Article.ArticleSubFamilyPricePartner;
using Bm2s.Services.Common.Article.ArticlePricePartnerFamily;
using Bm2s.Services.Common.Article.ArticlePriceParner;

namespace Bm2s.Services.Common.Article.PriceDetermination
{
  public class PriceDeterminationService : Service
  {
    public PriceDeterminationResponse Get(PriceDetermination request)
    {
      PriceDeterminationResponse response = new PriceDeterminationResponse();

      Bm2s.Poco.Common.Article.Article article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { request.ArticleId } }).Articles.FirstOrDefault();

      int articleFamilyId = 0;
      int articleSubFamilyId = 0;
      List<int> partnerFamilyIds = new List<int>();

      // Finding the families and the subfamilies of the current article
      if (article != null)
      {
        articleFamilyId = article.ArticleFamily.Id;
        articleSubFamilyId = article.ArticleSubFamily.Id;
      }

      // Finding the families of the current partner
      partnerFamilyIds.AddRange(new PartnerPartnerFamiliesService().Get(new PartnerPartnerFamilies() { PartnerId = request.PartnerId }).PartnerPartnerFamilies.Select(item => item.PartnerFamily.Id));

      // Finding the prices of the current article
      response.Price = new PricesService().Get(new Prices() { ArticleId = request.ArticleId, Date = request.Date }).Prices.FirstOrDefault();

      foreach (int partnerFamilyId in partnerFamilyIds)
      {
        // Finding the prices of the current article family for the partner families
        response.articleFamilyPricePartnerFamilies.AddRange(new ArticleFamilyPricePartnerFamiliesService().Get(new ArticleFamilyPricePartnerFamilies() { ArticleFamilyId = articleFamilyId, PartnerFamilyId = partnerFamilyId, Date = request.Date }).ArticleFamilyPricePartnerFamilies);

        // Finding the prices of the current article sub family for the partner families
        response.articleSubFamilyPricePartnerFamilies.AddRange(new ArticleSubFamilyPricePartnerFamiliesService().Get(new ArticleSubFamilyPricePartnerFamilies() { ArticleSubFamilyId = articleSubFamilyId, PartnerFamilyId = partnerFamilyId, Date = request.Date }).ArticleSubFamilyPricePartnerFamilies);

        // Finding the prices of the current article for the partner families
        response.articlePricePartnerFamilies.AddRange(new ArticlePricePartnerFamiliesService().Get(new ArticlePricePartnerFamilies() { ArticleId = request.ArticleId, PartnerFamilyId = partnerFamilyId, Date = request.Date }).ArticlePricePartnerFamilies);
      }

      // Finding the prices of the current article family for the partner
      response.articleFamilyPricePartners = new ArticleFamilyPricePartnersService().Get(new ArticleFamilyPricePartners() { ArticleFamilyId = articleFamilyId, Date = request.Date, PartnerId = request.PartnerId }).ArticleFamilyPricePartners.FirstOrDefault();

      // Finding the prices of the current article sub family for the partner
      response.articleSubFamilyPricePartners = new ArticleSubFamilyPricePartnersService().Get(new ArticleSubFamilyPricePartners() { ArticleSubFamilyId = articleSubFamilyId, PartnerId = request.PartnerId, Date = request.Date }).ArticleSubFamilyPricePartners.FirstOrDefault();

      // Finding the prices of the current article for the partner
      response.articlePricePartners = new ArticlePricePartnersService().Get(new ArticlePricePartners() { ArticleId = request.ArticleId, PartnerId = request.PartnerId, Date = request.Date }).ArticlePricePartners.FirstOrDefault();

      return response;
    }
  }
}
