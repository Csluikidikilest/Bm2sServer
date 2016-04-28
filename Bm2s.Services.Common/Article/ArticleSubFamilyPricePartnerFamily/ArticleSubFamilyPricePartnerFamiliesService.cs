using Bm2s.Data.Common.Utils;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Services.Common.Article.ArticleSubFamily;
using Bm2s.Services.Common.Partner.PartnerFamily;
using Bm2s.Response.Common.Article.ArticleSubFamilyPricePartnerFamily;
using Bm2s.Response.Common.Article.ArticleSubFamily;
using Bm2s.Response.Common.Partner.PartnerFamily;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartnerFamily
{
  public class ArticleSubFamilyPricePartnerFamiliesService : Service
  {
    public ArticleSubFamilyPricePartnerFamiliesResponse Get(ArticleSubFamilyPricePartnerFamilies request)
    {
      ArticleSubFamilyPricePartnerFamiliesResponse response = new ArticleSubFamilyPricePartnerFamiliesResponse();
      List<Bm2s.Data.Common.BLL.Article.Aspf> items = new List<Data.Common.BLL.Article.Aspf>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item =>
         (request.PartnerFamilyId == 0 || item.PafaId == request.PartnerFamilyId) &&
         (request.ArticleSubFamilyId == 0 || item.ArsfId == request.ArticleSubFamilyId) &&
         (!request.Date.HasValue || (request.Date >= item.StartingDate && (!item.EndingDate.HasValue || request.Date < item.EndingDate.Value)))
         ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartnerFamily()
                        {
                          ArticleSubFamily = new ArticleSubFamiliesService().Get(new ArticleSubFamilies() { Ids = new List<int>() { item.ArsfId } }).ArticleSubFamilies.FirstOrDefault(),
                          EndingDate = item.EndingDate,
                          Id = item.Id,
                          Multiplier = Convert.ToDecimal(item.Multiplier),
                          PartnerFamily = new PartnerFamiliesService().Get(new PartnerFamilies() { Ids = new List<int>() { item.PafaId } }).PartnerFamilies.FirstOrDefault(),
                          Price = Convert.ToDecimal(item.Price),
                          StartingDate = item.StartingDate
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.ArticleSubFamilyPricePartnerFamilies.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.ArticleSubFamilyPricePartnerFamilies.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.ArticleSubFamilyPricePartnerFamilies.Count + (collection.Count() % response.ArticleSubFamilyPricePartnerFamilies.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ArticleSubFamilyPricePartnerFamiliesResponse Post(ArticleSubFamilyPricePartnerFamilies request)
    {
      if (request.ArticleSubFamilyPricePartnerFamily.Id > 0)
      {
        Bm2s.Data.Common.BLL.Article.Aspf item = Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[request.ArticleSubFamilyPricePartnerFamily.Id];
        item.ArsfId = request.ArticleSubFamilyPricePartnerFamily.ArticleSubFamily.Id;
        item.EndingDate = request.ArticleSubFamilyPricePartnerFamily.EndingDate;
        item.Multiplier = Convert.ToDouble(request.ArticleSubFamilyPricePartnerFamily.Multiplier);
        item.PafaId = request.ArticleSubFamilyPricePartnerFamily.PartnerFamily.Id;
        item.Price = Convert.ToDouble(request.ArticleSubFamilyPricePartnerFamily.Price);
        item.StartingDate = request.ArticleSubFamilyPricePartnerFamily.StartingDate;
        Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[request.ArticleSubFamilyPricePartnerFamily.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Article.Aspf item = new Data.Common.BLL.Article.Aspf()
        {
          ArsfId = request.ArticleSubFamilyPricePartnerFamily.ArticleSubFamily.Id,
          EndingDate = request.ArticleSubFamilyPricePartnerFamily.EndingDate,
          Multiplier = Convert.ToDouble(request.ArticleSubFamilyPricePartnerFamily.Multiplier),
          PafaId = request.ArticleSubFamilyPricePartnerFamily.PartnerFamily.Id,
          Price = Convert.ToDouble(request.ArticleSubFamilyPricePartnerFamily.Price),
          StartingDate = request.ArticleSubFamilyPricePartnerFamily.StartingDate
        };

        Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies.Add(item);
        request.ArticleSubFamilyPricePartnerFamily.Id = item.Id;
      }

      ArticleSubFamilyPricePartnerFamiliesResponse response = new ArticleSubFamilyPricePartnerFamiliesResponse();
      response.ArticleSubFamilyPricePartnerFamilies.Add(request.ArticleSubFamilyPricePartnerFamily);
      return response;
    }

    public ArticleSubFamilyPricePartnerFamiliesResponse Delete(ArticleSubFamilyPricePartnerFamilies request)
    {
      Bm2s.Data.Common.BLL.Article.Aspf item = Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[request.ArticleSubFamilyPricePartnerFamily.Id];
      item.EndingDate = DateTime.Now;
      Datas.Instance.DataStorage.ArticleSubFamilyPricePartnerFamilies[item.Id] = item;

      ArticleSubFamilyPricePartnerFamiliesResponse response = new ArticleSubFamilyPricePartnerFamiliesResponse();
      response.ArticleSubFamilyPricePartnerFamilies.Add(request.ArticleSubFamilyPricePartnerFamily);
      return response;
    }
  }
}
