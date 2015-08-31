﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.Common.Utils;
using Bm2s.Response.Common.Parameter.Language;
using Bm2s.Response.Common.Parameter.Translation;
using Bm2s.Services.Common.Parameter.Language;
using ServiceStack.ServiceInterface;

namespace Bm2s.Services.Common.Parameter.Translation
{
  public class TranslationsService : Service
  {
    public TranslationsResponse Get(Translations request)
    {
      TranslationsResponse response = new TranslationsResponse();
      List<Bm2s.Data.Common.BLL.Parameter.Translation> items = new List<Data.Common.BLL.Parameter.Translation>();
      if (!request.Ids.Any())
      {
        items.AddRange(Datas.Instance.DataStorage.Translations.Where(item =>
          (string.IsNullOrWhiteSpace(request.Application) || item.Application.ToLower().Contains(request.Application.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Key) || item.Key.ToLower().Contains(request.Key.ToLower())) &&
          (string.IsNullOrWhiteSpace(request.Screen) || item.Screen.ToLower().Contains(request.Screen.ToLower()))
          ));
      }
      else
      {
        items.AddRange(Datas.Instance.DataStorage.Translations.Where(item => request.Ids.Contains(item.Id)));
      }

      response.Translations.AddRange((from item in items
                                      select new Bm2s.Poco.Common.Parameter.Translation()
                                   {
                                     Application = item.Application,
                                     Id = item.Id,
                                     Key = item.Key,
                                     Language = new LanguagesService().Get(new Languages() { Ids = new List<int>() { item.LanguageId } }).Languages.FirstOrDefault(),
                                     Screen = item.Screen,
                                     Value = item.Value
                                   }).AsQueryable().OrderBy(request.Order, request.AscendingOrder).Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize));

      return response;
    }

    public TranslationsResponse Post(Translations request)
    {
      if (request.Translation.Id > 0)
      {
        Bm2s.Data.Common.BLL.Parameter.Translation item = Datas.Instance.DataStorage.Translations[request.Translation.Id];
        item.Application = request.Translation.Application;
        item.Key = request.Translation.Key;
        item.LanguageId = request.Translation.Language.Id;
        item.Screen = request.Translation.Screen;
        item.Value = request.Translation.Value;
        Datas.Instance.DataStorage.Translations[request.Translation.Id] = item;
      }
      else
      {
        Bm2s.Data.Common.BLL.Parameter.Translation item = new Data.Common.BLL.Parameter.Translation()
        {
          Application = request.Translation.Application,
          Key = request.Translation.Key,
          LanguageId = request.Translation.Language.Id,
          Screen = request.Translation.Screen,
          Value = request.Translation.Value
        };

        Datas.Instance.DataStorage.Translations.Add(item);
        request.Translation.Id = item.Id;
      }

      TranslationsResponse response = new TranslationsResponse();
      response.Translations.Add(request.Translation);
      return response;
    }
  }
}
