using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.ArticleSubFamilyPartnerVat;
using Bm2s.Services.Common.Article.ArticleSubFamily;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.Partner;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.ArticleSubFamilyPartnerVat
{
  public class ArticleSubFamilyPartnerVatsService : Service
  {
    public ArticleSubFamilyPartnerVatsResponse Get(ArticleSubFamilyPartnerVats request)
    {
      ArticleSubFamilyPartnerVatsResponse response = new ArticleSubFamilyPartnerVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerVat> items = new List<Data.Common.BLL.Parameter.ArticleSubFamilyPartnerVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats.Where(item =>
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.PartnerId == 0 || item.PartnerId == request.PartnerId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleSubFamilyPartnerVats.AddRange(from item in items
                                                    select new Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerVat()
                                                          {
                                                            AccountingEntry = item.AccountingEntry,
                                                            ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArticleSubFamilyId } }).ArticleSubFamilies.FirstOrDefault(),
                                                            Id = item.Id,
                                                            Multiplier = item.Multiplier,
                                                            Partner = new PartnersService().Get(new Partners() { Ids = new List<int>() { item.PartnerId } }).Partners.FirstOrDefault(),
                                                            Rate = item.Rate,
                                                            Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                                                          });

      return response;
    }

    public ArticleSubFamilyPartnerVatsResponse Post(ArticleSubFamilyPartnerVats request)
    {
      if (request.ArticleSubFamilyPartnerVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerVat item = Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats[request.ArticleSubFamilyPartnerVat.Id];
        item.AccountingEntry = request.ArticleSubFamilyPartnerVat.AccountingEntry;
        item.ArticleSubFamilyId = request.ArticleSubFamilyPartnerVat.ArticleSubFamily.Id;
        item.Multiplier = request.ArticleSubFamilyPartnerVat.Multiplier;
        item.PartnerId = request.ArticleSubFamilyPartnerVat.Partner.Id;
        item.Rate = request.ArticleSubFamilyPartnerVat.Rate;
        item.VatId = request.ArticleSubFamilyPartnerVat.Vat.Id;
        Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats[request.ArticleSubFamilyPartnerVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerVat item = new Data.Common.BLL.Parameter.ArticleSubFamilyPartnerVat()
        {
          AccountingEntry = request.ArticleSubFamilyPartnerVat.AccountingEntry,
          ArticleSubFamilyId = request.ArticleSubFamilyPartnerVat.ArticleSubFamily.Id,
          Multiplier = request.ArticleSubFamilyPartnerVat.Multiplier,
          PartnerId = request.ArticleSubFamilyPartnerVat.Partner.Id,
          Rate = request.ArticleSubFamilyPartnerVat.Rate,
          VatId = request.ArticleSubFamilyPartnerVat.Vat.Id
        };

        Datas.Instance.DataStorage.ArticleSubFamilyPartnerVats.Add(item);
        request.ArticleSubFamilyPartnerVat.Id = item.Id;
      }

      ArticleSubFamilyPartnerVatsResponse response = new ArticleSubFamilyPartnerVatsResponse();
      response.ArticleSubFamilyPartnerVats.Add(request.ArticleSubFamilyPartnerVat);
      return response;
    }
  }
}
