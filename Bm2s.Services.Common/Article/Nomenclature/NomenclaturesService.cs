using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System.Linq;
using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.Nomenclature
{
  public class NomenclaturesService : Service
  {
    public NomenclaturesResponse Get(Nomenclatures request)
    {
      NomenclaturesResponse response = new NomenclaturesResponse();
      List<Bm2s.Data.Common.BLL.Article.Nomenclature> items = new List<Data.Common.BLL.Article.Nomenclature>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item =>
          request.ArticleId == 0 || item.ArticleChildId == request.ArticleId || item.ArticleParentId == request.ArticleId
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Nomenclatures.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Nomenclatures.AddRange(from item in items
                                      select new Bm2s.Poco.Common.Article.Nomenclature()
                                      {
                                        ArticleChild = null,
                                        ArticleParent = null,
                                        BuyPrice = item.BuyPrice,
                                        Id = item.Id,
                                        Multiplier = item.Multiplier,
                                        Quantity = item.Quantity
                                      });

      return response;
    }

    public Bm2s.Poco.Common.Article.Nomenclature Post(Nomenclatures request)
    {
      if (request.Nomenclature.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Nomenclature item = Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id];
        item.ArticleChildId = request.Nomenclature.ArticleChild.Id;
        item.ArticleParentId = request.Nomenclature.ArticleParent.Id;
        item.BuyPrice = request.Nomenclature.BuyPrice;
        item.Multiplier = request.Nomenclature.Multiplier;
        item.Quantity = request.Nomenclature.Quantity;
        Datas.Instance.DataStorage.Nomenclatures[request.Nomenclature.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Nomenclature item = new Data.Common.BLL.Article.Nomenclature()
        {
          ArticleChildId = request.Nomenclature.ArticleChild.Id,
          ArticleParentId = request.Nomenclature.ArticleParent.Id,
          BuyPrice = request.Nomenclature.BuyPrice,
          Multiplier = request.Nomenclature.Multiplier,
          Quantity = request.Nomenclature.Quantity
        };

        Datas.Instance.DataStorage.Nomenclatures.Add(item);
        request.Nomenclature.Id = item.Id;
      }

      return request.Nomenclature;
    }
  }
}
