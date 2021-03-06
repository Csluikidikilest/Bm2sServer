﻿using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.HeaderFile
{
  [Route("/bm2s/headerfiles", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/headerfiles/{Ids}", Verbs = "GET")]
  public class HeaderFiles : Request, IReturn<HeaderFilesResponse>
  {
    public HeaderFiles()
    {
      this.Ids = new List<int>();
    }

    public DateTime? AddingDate { get; set; }

    public int HeaderId { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderFile HeaderFile { get; set; }
  }
}
