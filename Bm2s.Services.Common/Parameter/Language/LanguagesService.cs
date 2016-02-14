using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Language;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Language
{
  public class LanguagesService : Service
  {
    public LanguagesResponse Get(Languages request)
    {
      LanguagesResponse response = new LanguagesResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Language> items = new List<Data.Common.BLL.Parameter.Language>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Languages.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Languages.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.Parameter.Language()
                        {
                          Code = item.Code,
                          Id = item.Id,
                          Name = item.Name
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Languages.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Languages.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Languages.Count + (collection.Count() % response.Languages.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public LanguagesResponse Post(Languages request)
    {
      if (request.Language.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Language item = Datas.Instance.DataStorage.Languages[request.Language.Id];
        item.Code = request.Language.Code;
        item.Name = request.Language.Name;
        Datas.Instance.DataStorage.Languages[request.Language.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Language item = new Data.Common.BLL.Parameter.Language()
        {
          Code = request.Language.Code,
          Name = request.Language.Name,
        };

        Datas.Instance.DataStorage.Languages.Add(item);
        request.Language.Id = item.Id;
      }

      LanguagesResponse response = new LanguagesResponse();
      response.Languages.Add(request.Language);
      return response;
    }
  }
}
