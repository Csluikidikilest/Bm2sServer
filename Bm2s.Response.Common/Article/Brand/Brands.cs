﻿using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Article.Brand
{
  [Route("/bm2s/brands", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/brands/{Ids}", Verbs = "GET")]
  public class Brands : Request, IReturn<BrandsResponse>
  {
    public Brands()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Article.Brand Brand { get; set; }
  }
}
