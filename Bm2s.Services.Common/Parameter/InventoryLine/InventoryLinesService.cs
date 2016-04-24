using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Article.Article;
using Bm2s.Response.Common.Parameter.InventoryHeader;
using Bm2s.Response.Common.Parameter.InventoryLine;
using Bm2s.Services.Common.Article.Article;
using Bm2s.Services.Common.Parameter.InventoryHeader;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.InventoryLine
{
  public class InventoryLinesService : Service
  {
    public InventoryLinesResponse Get(InventoryLines request)
    {
      InventoryLinesResponse response = new InventoryLinesResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Inli> items = new List<Data.Common.BLL.Parameter.Inli>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.InventoryLines.Where(item =>
          (request.ArticleId == 0 || item.ArtiId == request.ArticleId) &&
          (request.InventoryHeaderId == 0 || item.InheId == request.InventoryHeaderId)
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.InventoryLines.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.InventoryLine()
                        {
                          Article = new ArticlesService().Get(new Articles() { Ids = new List<int>() { item.ArtiId } }).Articles.FirstOrDefault(),
                          Id = item.Id,
                          InventoryHeader = new InventoryHeadersService().Get(new InventoryHeaders() { Ids = new List<int>() { item.InheId } }).InventoryHeaders.FirstOrDefault(),
                          Quantity = item.Quantity
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.InventoryLines.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.InventoryLines.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.InventoryLines.Count + (collection.Count() % response.InventoryLines.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public InventoryLinesResponse Post(InventoryLines request)
    {
      if (request.InventoryLine.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Inli item = Datas.Instance.DataStorage.InventoryLines[request.InventoryLine.Id];
        item.ArtiId = request.InventoryLine.Article.Id;
        item.InheId = request.InventoryLine.InventoryHeader.Id;
        item.Quantity = request.InventoryLine.Quantity;
        Datas.Instance.DataStorage.InventoryLines[request.InventoryLine.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Inli item = new Data.Common.BLL.Parameter.Inli()
        {
          ArtiId = request.InventoryLine.Article.Id,
          InheId = request.InventoryLine.InventoryHeader.Id,
          Quantity = request.InventoryLine.Quantity
        };

        Datas.Instance.DataStorage.InventoryLines.Add(item);
        request.InventoryLine.Id = item.Id;
      }

      InventoryLinesResponse response = new InventoryLinesResponse();
      response.InventoryLines.Add(request.InventoryLine);
      return response;
    }

    public InventoryLinesResponse Delete(InventoryLines request)
    {
      Bm2s.Data.Common.BLL.Parameter.Inli item = Datas.Instance.DataStorage.InventoryLines[request.InventoryLine.Id];
      Datas.Instance.DataStorage.InventoryLines.Remove(item);

      InventoryLinesResponse response = new InventoryLinesResponse();
      response.InventoryLines.Add(request.InventoryLine);
      return response;
    }
  }
}
