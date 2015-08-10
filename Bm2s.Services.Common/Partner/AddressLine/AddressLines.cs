using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Partner.AddressLine
{
  [Route("/bm2s/addresslines", Verbs = "GET, POST")]
  [Route("/bm2s/addresslines/{Ids}", Verbs = "GET")]
  public class AddressLines : IReturn<AddressLinesResponse>
  {
    public AddressLines()
    {
      this.Ids = new List<int>();
    }

    public int AddressId { get; set; }

    public List<int> Ids { get; set; }

    public Bm2s.Data.Common.BLL.Partner.AddressLine AddressLine { get; set; }
  }
}
