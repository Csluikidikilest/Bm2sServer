using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.AddressLine
{
  [Route("/bm2s/addresslines", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/addresslines/{Ids}", Verbs = "GET")]
  public class AddressLines : Request, IReturn<AddressLinesResponse>
  {
    public AddressLines()
    {
      this.Ids = new List<int>();
    }

    public int AddressId { get; set; }

    public Bm2s.Poco.Common.Partner.AddressLine AddressLine { get; set; }
  }
}
