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

      return response;
    }

    public object Post(ArticleFamilyPricePartnerFamilies request)
    {
      if (request.ArticleFamilyPricePartnerFamily.Id > 0)
      {
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id].ArticleFamilyId = request.ArticleFamilyPricePartnerFamily.ArticleFamily.Id;
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id].EndingDate = request.ArticleFamilyPricePartnerFamily.EndingDate;
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id].Id = request.ArticleFamilyPricePartnerFamily.ArticleFamily.Id;
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id].Multiplier = request.ArticleFamilyPricePartnerFamily.Multiplier;
        Datas.Instance.DataStorage.ArticleFamilyPricePartnerFamilies[request.ArticleFamilyPricePartnerFamily.Id].PartnerFamilyId = request.ArticleFamilyPricePartnerFamily.PartnerFamily.Id;
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
