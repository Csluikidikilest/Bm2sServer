using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.AddressType
{
  [Route("/bm2s/addresstypes", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/addresstypes/{Ids}", Verbs = "GET")]
  public class AddressTypes : Request, IReturn<AddressTypesResponse>
  {
    public AddressTypes()
    {
      this.Ids = new List<int>();
    }
    public string Code { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Partner.AddressType AddressType { get; set; }
  }
}
