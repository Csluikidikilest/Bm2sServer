using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.AddressLine
{
  [Route("/bm2s/addresslines", Verbs = "GET, POST")]
  [Route("/bm2s/addresslines/{Ids}", Verbs = "GET")]
  public class AddressLines
  {
    public AddressLines()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Partner.AddressLine AddressLine { get; set; }
  }
}
