using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleFamilyPricePartner
{
  public class ArticleFamilyPricePartnersService : Service
  {
    public ArticleFamilyPricePartnersResponse Get(ArticleFamilyPricePartners request)
    {
      ArticleFamilyPricePartnersResponse response = new ArticleFamilyPricePartnersResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner> items = new List<Data.Common.BLL.Article.ArticleFamilyPricePartner>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartners.Where(item =>
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleFamilyPricePartners.AddRange(from item in items
                                                   select new Bm2s.Poco.Common.Article.ArticleFamilyPricePartner()
                                                   {
                                                     AddPrice = item.AddPrice,
                                                     ArticleFamily = null,
                                                     EndingDate = item.EndingDate,
                                                     Id = item.Id,
                                                     Multiplier = item.Multiplier,
                                                     Partner = null,
                                                     Price = item.Price,
                                                     StartingDate = item.StartingDate
                                                   });
      return response;
    }

    public object Post(ArticleFamilyPricePartners request)
    {
      if (request.ArticleFamilyPricePartner.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].AddPrice = request.ArticleFamilyPricePartner.AddPrice;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].ArticleFamilyId = request.ArticleFamilyPricePartner.ArticleFamily.Id;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].EndingDate = request.ArticleFamilyPricePartner.EndingDate;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].Multiplier = request.ArticleFamilyPricePartner.Multiplier;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].PartnerId = request.ArticleFamilyPricePartner.Partner.Id;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].Price = request.ArticleFamilyPricePartner.Price;
        Datas.Instance.DataStorage.ArticleFamilyPricePartners[request.ArticleFamilyPricePartner.Id].StartingDate = request.ArticleFamilyPricePartner.StartingDate;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartner item = new Data.Common.BLL.Article.ArticleFamilyPricePartner()
          {
            AddPrice = request.ArticleFamilyPricePartner.AddPrice,
            ArticleFamilyId = request.ArticleFamilyPricePartner.ArticleFamily.Id,
            EndingDate = request.ArticleFamilyPricePartner.EndingDate,
            Multiplier = request.ArticleFamilyPricePartner.Multiplier,
            PartnerId = request.ArticleFamilyPricePartner.Partner.Id,
            Price = request.ArticleFamilyPricePartner.Price,
            StartingDate = request.ArticleFamilyPricePartner.StartingDate
          };

        Datas.Instance.DataStorage.ArticleFamilyPricePartners.Add(item);
        request.ArticleFamilyPricePartner.Id = item.Id;
      }
      return request.ArticleFamilyPricePartner;
    }
  }
}
