using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Collections.Generic;
using System.Linq;

namespace Bm2s.Data.Common.Services.Article.PriceDetermination
{
  public class PriceDeterminationService : Service
  {
    public object Get(PriceDetermination request)
    {
      PriceDeterminationResponse response = new PriceDeterminationResponse();

      BLL.Article.Article article = Datas.Instance.DataStorage.Articles.FirstOrDefault(item => item.Id == request.ArticleId);

      int articleFamilyId = 0;
      int articleSubFamilyId = 0;
      List<int> partnerFamilyId = new List<int>();

      // Finding the families and the subfamilies of the current article
      if (article != null)
      {
        articleFamilyId = article.ArticleFamilyId;
        articleSubFamilyId = article.ArticleSubFamilyId;
      }

      // Finding the families of the current partner
      partnerFamilyId.AddRange(Datas.Instance.DataStorage.PartnerPartnerFamilies.Where(item => item.PartnerId == request.PartnerId).Select(item => item.PartnerFamilyId));

      // Finding the prices of the current article
      response.Price = Datas.Instance.DataStorage.Prices.FirstOrDefault(item => item.ArticleId == request.ArticleId && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value));

      // Finding the prices of the current article family for the parter families
      response.articleFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Where(item => item.ArticleFamilyId == articleFamilyId && partnerFamilyId.Contains(item.PartnerFamilyId) && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)));

      // Finding the prices of the current article family for the partner
      response.articleFamilyPricePartners = Datas.Instance.DataStorage.ArticleFamilyPricePartners.FirstOrDefault(item => item.ArticleFamilyId == articleFamilyId && item.PartnerId == request.PartnerId && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value));

      // Finding the prices of the current article sub family for the partner families
      response.articleSubFamilyPricePartnerFamilies.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item => item.ArticleSubFamilyId == articleSubFamilyId && partnerFamilyId.Contains(item.PartnerFamilyId) && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)));

      // Finding the prices of the current article sub family for the partner
      response.articleSubFamilyPricePartners = Datas.Instance.DataStorage.ArticleSubFamilyPricePartners.FirstOrDefault(item => item.ArticleSubFamilyId == articleSubFamilyId && item.PartnerId == request.PartnerId && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value));

      // Finding the prices of the current article for the partner  families
      response.articlePriceParnerFamilies.AddRange(Datas.Instance.DataStorage.ArticlePriceParnerFamilies.Where(item => item.ArticleId == request.ArticleId && partnerFamilyId.Contains(item.PartnerFamilyId) && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)));

      // Finding the prices of the current article for the partner
      response.articlePriceParners = Datas.Instance.DataStorage.ArticlePriceParners.FirstOrDefault(item => item.ArticleId == request.ArticleId && item.PartnerId == request.PartnerId && item.StartingDate >= request.Date && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value));

      return response;
    }
  }
}
