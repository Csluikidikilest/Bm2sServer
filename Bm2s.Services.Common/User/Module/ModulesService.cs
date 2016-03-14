using System.Collections.Generic;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.User.Module;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.User.Module
{
  public class ModulesService : Service
  {
    public ModulesResponse Get(Modules request)
    {
      ModulesResponse response = new ModulesResponse();
      List<Bm2s.Data.Common.BLL.User.Module> items = new List<Data.Common.BLL.User.Module>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Modules.Where(item =>
          (string.IsNullOrWhiteSpace(request.Code) || item.Code.ToLower().Contains(request.Code.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Name) || item.Name.ToLower().Contains(request.Name.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Modules.Where(item => request.Ids.Contains(item.Id)));
      }

      var collection = (from item in items
                        select new Bm2s.Poco.Common.User.Module()
                        {
                          Code = item.Code,
                          Description = item.Description,
                          Id = item.Id,
                          Name = item.Name
                        }).AsQueryable().OrderBy(request.Order, !request.DescendingOrder);

      response.ItemsCount = collection.Count();
      if (request.PageSize > 0)
      {
        response.Modules.AddRange(collection.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));
      }
      else
      {
        response.Modules.AddRange(collection);
      }

      try
      {
        response.PagesCount = collection.Count() / response.Modules.Count + (collection.Count() % response.Modules.Count > 0 ? 1 : 0);
      }
      catch
      {
        response.PagesCount = 1;
      }

      return response;
    }

    public ModulesResponse Post(Modules request)
    {
      if (request.Module.Id > 0)
      {
        Bm2s.Data.Common.BLL.User.Module item = Datas.Instance.DataStorage.Modules[request.Module.Id];
        item.Code = request.Module.Code;
        item.Description = request.Module.Description;
        item.Id = request.Module.Id;
        item.Name = request.Module.Name;
        Datas.Instance.DataStorage.Modules[request.Module.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.User.Module item = new Data.Common.BLL.User.Module()
        {
          Code = request.Module.Code,
          Description = request.Module.Description,
          Id = request.Module.Id,
          Name = request.Module.Name
        };

        Datas.Instance.DataStorage.Modules.Add(item);
        request.Module.Id = item.Id;
      }

      ModulesResponse response = new ModulesResponse();
      response.Modules.Add(request.Module);
      return response;
    }

    public bool Delete(Articles request)
    {
      bool result = true;
      Bm2s.Data.Common.BLL.Article.Article item = Datas.Instance.DataStorage.Articles.FirstOrDefault(nomenclature => nomenclature.Id == request.Article.Id);
      if (item != null)
      {
        result = Datas.Instance.DataStorage.Articles.Remove(item);
      }

      return result;
    }
  }
}
