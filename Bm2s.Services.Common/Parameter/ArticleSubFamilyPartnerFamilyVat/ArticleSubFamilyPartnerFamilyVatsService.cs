using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Services.Common.Article.ArticleSubFamily;
using Bm2s.Services.Common.Parameter.Vat;
using Bm2s.Services.Common.Partner.PartnerFamily;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  public class ArticleSubFamilyPartnerFamilyVatsService : Service
  {
    public ArticleSubFamilyPartnerFamilyVatsResponse Get(ArticleSubFamilyPartnerFamilyVats request)
    {
      ArticleSubFamilyPartnerFamilyVatsResponse response = new ArticleSubFamilyPartnerFamilyVatsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat> items = new List<Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats.Where(item =>
          (request.ArticleSubFamilyId == 0 || item.ArticleSubFamilyId == request.ArticleSubFamilyId) &&
          (request.PartnerFamilyId == 0 || item.PartnerFamilyId == request.PartnerFamilyId) &&
          (request.VatId == 0 || item.VatId == request.VatId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats.Where(item => request.Ids.Contains(item.Id)));
      }

      response.ArticleSubFamilyPartnerFamilyVats.AddRange(from item in items
                                                          select new Bm2s.Poco.Common.Parameter.ArticleSubFamilyPartnerFamilyVat()
                                                          {
                                                            AccountingEntry = item.AccountingEntry,
                                                            ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArticleSubFamilyId } }).ArticleSubFamilies.FirstOrDefault(),
                                                            Id = item.Id,
                                                            Multiplier = item.Multiplier,
                                                            PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PartnerFamilyId } }).PartnerFamilies.FirstOrDefault(),
                                                            Rate = item.Rate,
                                                            Vat = new VatsService().Get(new Vats() { Ids = new List<int>() { item.VatId } }).Vats.FirstOrDefault()
                                                          });

      return response;
    }

    public ArticleSubFamilyPartnerFamilyVatsResponse Post(ArticleSubFamilyPartnerFamilyVats request)
    {
      if (request.ArticleSubFamilyPartnerFamilyVat.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat item = Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats[request.ArticleSubFamilyPartnerFamilyVat.Id];
        item.AccountingEntry = request.ArticleSubFamilyPartnerFamilyVat.AccountingEntry;
        item.ArticleSubFamilyId = request.ArticleSubFamilyPartnerFamilyVat.ArticleSubFamily.Id;
        item.Multiplier = request.ArticleSubFamilyPartnerFamilyVat.Multiplier;
        item.PartnerFamilyId = request.ArticleSubFamilyPartnerFamilyVat.PartnerFamily.Id;
        item.Rate = request.ArticleSubFamilyPartnerFamilyVat.Rate;
        item.VatId = request.ArticleSubFamilyPartnerFamilyVat.Vat.Id;
        Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats[request.ArticleSubFamilyPartnerFamilyVat.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat item = new Data.Common.BLL.Parameter.ArticleSubFamilyPartnerFamilyVat() {
        AccountingEntry = request.ArticleSubFamilyPartnerFamilyVat.AccountingEntry,
        ArticleSubFamilyId = request.ArticleSubFamilyPartnerFamilyVat.ArticleSubFamily.Id,
        Multiplier = request.ArticleSubFamilyPartnerFamilyVat.Multiplier,
        PartnerFamilyId = request.ArticleSubFamilyPartnerFamilyVat.PartnerFamily.Id,
        Rate = request.ArticleSubFamilyPartnerFamilyVat.Rate,
        VatId = request.ArticleSubFamilyPartnerFamilyVat.Vat.Id};

        Datas.Instance.DataStorage.ArticleSubFamilyPartnerFamilyVats.Add(item);
        request.ArticleSubFamilyPartnerFamilyVat.Id = item.Id;
      }

      ArticleSubFamilyPartnerFamilyVatsResponse response = new ArticleSubFamilyPartnerFamilyVatsResponse();
      response.ArticleSubFamilyPartnerFamilyVats.Add(request.ArticleSubFamilyPartnerFamilyVat);
      return response;
    }
  }
}
