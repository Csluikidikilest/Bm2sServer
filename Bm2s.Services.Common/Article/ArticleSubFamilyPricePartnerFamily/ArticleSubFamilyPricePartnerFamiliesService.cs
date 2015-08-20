using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Services.Common.Article.ArticleSubFamily;
using Bm2s.Services.Common.Partner.PartnerFamily;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartnerFamily
{
  public class ArticleSubFamilyPricePartnerFamiliesService : Service
  {
    public ArticleSubFamilyPricePartnerFamiliesResponse Get(ArticleSubFamilyPricePartnerFamilies request)
    {
      ArticleSubFamilyPricePartnerFamiliesResponse response = new ArticleSubFamilyPricePartnerFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartnerFamily> items = new List<Data.Common.BLL.Article.ArticleSubFamilyPricePartnerFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item =>
         (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
         (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
         (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
         ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleSubFamilyPricePartnerFamilies.AddRange(from item in items
                                                             select new Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartnerFamily()
                                                             {
                                                               ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArticleSubFamilyId } }).ArticleSubFamilies.FirstOrDefault(),
                                                               EndingDate = item.EndingDate,
                                                               Id = item.Id,
                                                               Multiplier = item.Multiplier,
                                                               PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                                                               Price = item.Price,
                                                               StartingDate = item.StartingDate
                                                             });

      return response;
    }

    public Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartnerFamily Post(ArticleSubFamilyPricePartnerFamilies request)
    {
      if (request.ArticleSubFamilyPricePartnerFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartnerFamily item = Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[request.ArticleSubFamilyPricePartnerFamily.Id];
        item.ArticleSubFamilyId = request.ArticleSubFamilyPricePartnerFamily.ArticleSubFamily.Id;
        item.EndingDate = request.ArticleSubFamilyPricePartnerFamily.EndingDate;
        item.Multiplier = request.ArticleSubFamilyPricePartnerFamily.Multiplier;
        item.PartnerFamilyId = request.ArticleSubFamilyPricePartnerFamily.PartnerFamily.Id;
        item.Price = request.ArticleSubFamilyPricePartnerFamily.Price;
        item.StartingDate = request.ArticleSubFamilyPricePartnerFamily.StartingDate;
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[request.ArticleSubFamilyPricePartnerFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleSubFamilyPricePartnerFamily item = new Data.Common.BLL.Article.ArticleSubFamilyPricePartnerFamily()
        {
          ArticleSubFamilyId = request.ArticleSubFamilyPricePartnerFamily.ArticleSubFamily.Id,
          EndingDate = request.ArticleSubFamilyPricePartnerFamily.EndingDate,
          Multiplier = request.ArticleSubFamilyPricePartnerFamily.Multiplier,
          PartnerFamilyId = request.ArticleSubFamilyPricePartnerFamily.PartnerFamily.Id,
          Price = request.ArticleSubFamilyPricePartnerFamily.Price,
          StartingDate = request.ArticleSubFamilyPricePartnerFamily.StartingDate
        };

        Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Add(item);
        request.ArticleSubFamilyPricePartnerFamily.Id = item.Id;
      }

      return request.ArticleSubFamilyPricePartnerFamily;
    }
  }
}
