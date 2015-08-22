using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Article.ArticleFamily;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.ArticleFamilyPartnerFamilyVat
{
  class ArticleFamilyPartnerFamilyVatsService : Service
  {
    public object Get(ArticleFamilyPartnerFamilyVats request)
    {
      ArticleFamilyPartnerFamilyVatsResponse response = new ArticleFamilyPartnerFamilyVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat> items = new List<Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Where(item =>
          (request.ArticleFamilyId == 0 || item.ArticleFamilyId == request.ArticleFamilyId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleFamilyPartnerFamilyVats.AddRange(from item in items
                                                       select new Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerFamilyVat()
                                                       {
                                                         AccountingEntry = item.AccountingEntry,
                                                         ArticleFamily = new ArticleFamiliesService().Get(new ArticleFamilies() { Ids = new List<int>() { item.ArticleFamilyId } }).ArticleFamilies.FirstOrDefault(),
                                                         Id = item.Id,
                                                         Multiplier = item.Multiplier,
                                                         PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                                                         Rate = item.Rate,
                                                         Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                                                       });

      return response;
    }

    public ArticleFamilyPartnerFamilyVatsResponse Post(ArticleFamilyPartnerFamilyVats request)
    {
      if (request.ArticleFamilyPartnerFamilyVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat item = Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats[request.ArticleFamilyPartnerFamilyVat.Id];
        item.AccountingEntry = request.ArticleFamilyPartnerFamilyVat.AccountingEntry;
        item.ArticleFamilyId = request.ArticleFamilyPartnerFamilyVat.ArticleFamily.Id;
        item.Multiplier = request.ArticleFamilyPartnerFamilyVat.Multiplier;
        item.PartnerFamilyId = request.ArticleFamilyPartnerFamilyVat.PartnerFamily.Id;
        item.Rate = request.ArticleFamilyPartnerFamilyVat.Rate;
        item.VatId = request.ArticleFamilyPartnerFamilyVat.Vat.Id;
        Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats[request.ArticleFamilyPartnerFamilyVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat item = new Data.Common.BLL.Parameter.ArticleFamilyPartnerFamilyVat()
        {
          AccountingEntry = request.ArticleFamilyPartnerFamilyVat.AccountingEntry,
          ArticleFamilyId = request.ArticleFamilyPartnerFamilyVat.ArticleFamily.Id,
          Multiplier = request.ArticleFamilyPartnerFamilyVat.Multiplier,
          PartnerFamilyId = request.ArticleFamilyPartnerFamilyVat.PartnerFamily.Id,
          Rate = request.ArticleFamilyPartnerFamilyVat.Rate,
          VatId = request.ArticleFamilyPartnerFamilyVat.Vat.Id,
        };

        Datas.Instance.DataStorage.ArticleFamilyPartnerFamilyVats.Add(item);
        request.ArticleFamilyPartnerFamilyVat.Id = item.Id;
      }

      ArticleFamilyPartnerFamilyVatsResponse response = new ArticleFamilyPartnerFamilyVatsResponse();
      response.ArticleFamilyPartnerFamilyVats.Add(request.ArticleFamilyPartnerFamilyVat);
      return response;
    }
  }
}
