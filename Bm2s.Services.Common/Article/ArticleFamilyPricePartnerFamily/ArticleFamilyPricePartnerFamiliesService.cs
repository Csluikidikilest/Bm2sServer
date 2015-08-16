using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleFamilyPricePartnerFamily
{
  public class ArticleFamilyPricePartnerFamiliesService : Service
  {
    public ArticleFamilyPricePartnerFamiliesResponse Get(ArticleFamilyPricePartnerFamilies request)
    {
      ArticleFamilyPricePartnerFamiliesResponse response = new ArticleFamilyPricePartnerFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily> items = new List<Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Where(item =>
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleFamilyPricePartnerFamilies.AddRange(from item in items
                                                          select new Bm2s.Poco.Common.Article.ArticleFamilyPricePartnerFamily()
                                                          {
                                                            ArticleFamily = null,
                                                            EndingDate = item.EndingDate,
                                                            Id = item.Id,
                                                            Multiplier = item.Multiplier,
                                                            PartnerFamily = null,
                                                            Price = item.Price,
                                                            StartingDate = item.StartingDate
                                                          });

      return response;
    }

    public Bm2s.Poco.Common.Article.ArticleFamilyPricePartnerFamily Post(ArticleFamilyPricePartnerFamilies request)
    {
      if (request.ArticleFamilyPricePartnerFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily item = Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id];
        item.ArticleFamilyId = request.ArticleFamilyPricePartnerFamily.ArticleFamily.Id;
        item.EndingDate = request.ArticleFamilyPricePartnerFamily.EndingDate;
        item.Multiplier = request.ArticleFamilyPricePartnerFamily.Multiplier;
        item.PartnerFamilyId = request.ArticleFamilyPricePartnerFamily.PartnerFamily.Id;
        item.Price = request.ArticleFamilyPricePartnerFamily.Price;
        item.StartingDate = request.ArticleFamilyPricePartnerFamily.StartingDate;
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily item = new Bm2s.Data.Common.BLL.Article.ArticleFamilyPricePartnerFamily()
        {
          ArticleFamilyId = request.ArticleFamilyPricePartnerFamily.ArticleFamily.Id,
          EndingDate = request.ArticleFamilyPricePartnerFamily.EndingDate,
          Multiplier = request.ArticleFamilyPricePartnerFamily.Multiplier,
          PartnerFamilyId = request.ArticleFamilyPricePartnerFamily.PartnerFamily.Id,
          Price = request.ArticleFamilyPricePartnerFamily.Price,
          StartingDate = request.ArticleFamilyPricePartnerFamily.StartingDate,
        };

        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies.Add(item);
        request.ArticleFamilyPricePartnerFamily.Id = item.Id;
      }

      return request.ArticleFamilyPricePartnerFamily;
    }
  }
}
