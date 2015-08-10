using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.Town
{
  [Route("/bm2s/towns", Verbs = "GET, POST")]
  [Route("/bm2s/towns/{Ids}", Verbs = "GET")]
  public class Towns : IReturn<TownsResponse>
  {
    public Towns()
    {
      this.Ids = new List<int>();
    }

    public int CountryId { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public string ZipCode { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.Town Town { get; set; }
  }
}
