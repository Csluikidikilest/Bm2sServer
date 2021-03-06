﻿using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.Article
{
  public class ArticlesResponse : Response
  {
    public ArticlesResponse()
    {
      this.Articles = new List<Bm2s.Poco.Common.Article.Article>();
    }

    public List<Bm2s.Poco.Common.Article.Article> Articles { get; set; }
  }
}
