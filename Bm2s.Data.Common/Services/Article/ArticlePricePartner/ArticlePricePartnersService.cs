using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePriceParner
{
  public class ArticlePricePartnersService : Service
  {
    public object Get(ArticlePricePartners request)
    {
      ArticlePricePartnersResponse response = new ArticlePricePartnersResponse();

      if (!request.Ids.Any())
      {
        response.ArticlePricePartners.AddRange(Datas.Instance.DataStorage.ArticlePricePartners);
      }
      else
      {
        response.ArticlePricePartners.AddRange(Datas.Instance.DataStorage.ArticlePricePartners.Where(item => request.Ids.Contains(item.Id)));
      }

      return response;
    }

    public object Post(ArticlePricePartners request)
    {
      if (request.ArticlePriceParner.Id > 0)
      {
        Datas.Instance.DataStorage.ArticlePricePartners[request.ArticlePriceParner.Id] = request.ArticlePriceParner;
      }
      else
      {
        Datas.Instance.DataStorage.ArticlePricePartners.Add(request.ArticlePriceParner);
      }
      return request.ArticlePriceParner;
    }
  }
}
