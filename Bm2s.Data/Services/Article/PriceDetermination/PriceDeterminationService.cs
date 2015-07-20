using Bm2s.Data.Utils;
using ServiceStack.ServiceInterface;
using System.Collections.Generic;
using System.Linq;

namespace Bm2s.Data.Services.Article.PriceDetermination
{
  public class PriceDeterminationService : Service
  {
    public object Get(PriceDetermination request)
    {
      PriceDeterminationResponse response = new PriceDeterminationResponse();

      BLL.Article.Article article = Datas.Instance.DataStorage.Articles.FirstOrDefault(item => item.Id == request.ArtiId);

      int articleFamilyId = 0;
      int articleSubFamilyId = 0;
      List<int> partnerFamilyId = new List<int>();

      List<BLL.Article.ArticleFamilyPricePartnerFamily> articleFamilyPricePartnerFamilies = new List<BLL.Article.ArticleFamilyPricePartnerFamily>();
      List<BLL.Article.ArticleFamilyPricePartner> articleFamilyPricePartners = new List<BLL.Article.ArticleFamilyPricePartner>();
      List<BLL.Article.ArticleSubFamilyPricePartnerFamily> articleSubFamilyPricePartnerFamilies = new List<BLL.Article.ArticleSubFamilyPricePartnerFamily>();
      List<BLL.Article.ArticleSubFamilyPricePartner> articleSubFamilyPricePartners = new List<BLL.Article.ArticleSubFamilyPricePartner>();
      List<BLL.Article.ArticlePriceParnerFamily> articlePriceParnerFamilies = new List<BLL.Article.ArticlePriceParnerFamily>();
      List<BLL.Article.ArticlePriceParner> articlePriceParners = new List<BLL.Article.ArticlePriceParner>();

      if (article != null)
      {
        articleFamilyId = article.ArticleFamilyId;
        articleSubFamilyId = article.ArticleSubFamilyId;
      }

      partnerFamilyId.AddRange(Datas.Instance.DataStorage.PartnerPartnerFamilies.Where(item => item.PartnerId == request.PartId).Select(item => item.PartnerFamilyId));

      response.Prices.AddRange(Datas.Instance.DataStorage.Prices.Where(item => item.ArticleId == request.ArtiId));


      return response;
    }
  }
}
