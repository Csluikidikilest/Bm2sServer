using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.ArticlePartnerFamilyVat
{
  class ArticlePartnerFamilyVatsService : Service
  {
    public ArticlePartnerFamilyVatsResponse Get(ArticlePartnerFamilyVats request)
    {
      ArticlePartnerFamilyVatsResponse response = new ArticlePartnerFamilyVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat> items = new List<Data.Common.BLL.Parameter.ArticlePartnerFamilyVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Where(item =>
          (request.ArticleId == 0 || item.ArticleId == request.ArticleId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticlePartnerFamilyVats.AddRange(from item in items
                                                 select new Bm2s.Poco.Common.Parameter.ArticlePartnerFamilyVat()
                                                 {
                                                   AccountingEntry = item.AccountingEntry,
                                                   Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArticleId } }).Articles.FirstOrDefault(),
                                                   Id = item.Id,
                                                   Multiplier = item.Multiplier,
                                                   PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                                                   Rate = item.Rate,
                                                   Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                                                 });

      return response;
    }

    public ArticlePartnerFamilyVatsResponse Post(ArticlePartnerFamilyVats request)
    {
      if (request.ArticlePartnerFamilyVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat item = Datas.Instance.DataStorage.ArticlePartnerFamilyVats[request.ArticlePartnerFamilyVat.Id];
        item.AccountingEntry = request.ArticlePartnerFamilyVat.AccountingEntry;
        item.ArticleId = request.ArticlePartnerFamilyVat.Article.Id;
        item.Multiplier = request.ArticlePartnerFamilyVat.Multiplier;
        item.PartnerFamilyId = request.ArticlePartnerFamilyVat.PartnerFamily.Id;
        item.Rate = request.ArticlePartnerFamilyVat.Rate;
        item.VatId = request.ArticlePartnerFamilyVat.Vat.Id;
        Datas.Instance.DataStorage.ArticlePartnerFamilyVats[request.ArticlePartnerFamilyVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticlePartnerFamilyVat item = new Data.Common.BLL.Parameter.ArticlePartnerFamilyVat()
        {
          AccountingEntry = request.ArticlePartnerFamilyVat.AccountingEntry,
          ArticleId = request.ArticlePartnerFamilyVat.Article.Id,
          Multiplier = request.ArticlePartnerFamilyVat.Multiplier,
          PartnerFamilyId = request.ArticlePartnerFamilyVat.PartnerFamily.Id,
          Rate = request.ArticlePartnerFamilyVat.Rate,
          VatId = request.ArticlePartnerFamilyVat.Vat.Id
        };

        Datas.Instance.DataStorage.ArticlePartnerFamilyVats.Add(item);
        request.ArticlePartnerFamilyVat.Id = item.Id;
      }

      ArticlePartnerFamilyVatsResponse response = new ArticlePartnerFamilyVatsResponse();
      response.ArticlePartnerFamilyVats.Add(request.ArticlePartnerFamilyVat);
      return response;
    }
  }
}
