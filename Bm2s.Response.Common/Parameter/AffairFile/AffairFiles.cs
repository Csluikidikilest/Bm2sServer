using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.AffairFile
{
  [Route("/bm2s/affairfiles", Verbs = "GET, POST")]
  [Route("/bm2s/affairfiles/{Ids}", Verbs = "GET")]
  public class AffairFiles : IReturn<AffairFilesResponse>
  {
    public AffairFiles()
    {
      this.Ids = new List<int>();
    }

    public DateTime? AddingDate { get; set; }

    public int AffairId { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public int UserId { get; set; }

    public Bm2s.Poco.Common.Parameter.AffairFile AffairFile { get; set; }
  }
}
