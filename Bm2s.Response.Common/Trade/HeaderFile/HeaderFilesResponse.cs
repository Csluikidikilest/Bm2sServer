﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Trade.HeaderFile
{
  public class HeaderFilesResponse : Response
  {
    public HeaderFilesResponse()
    {
      this.HeaderFiles = new List<Bm2s.Poco.Common.Trade.HeaderFile>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderFile> HeaderFiles { get; set; }
  }
}
