using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.Partner
{
  [Route("/bm2s/partners", Verbs = "GET, POST")]
  [Route("/bm2s/partners/{Ids}", Verbs = "GET")]
  public class Partners : Request, IReturn<PartnersResponse>
  {
    public Partners()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public string CompanyName { get; set; }

    public DateTime? Date { get; set; }

    public bool IsCustomer { get; set; }

    public bool IsSupplier { get; set; }

    public int UserId { get; set; }

    public string WebSite { get; set; }

    public Bm2s.Poco.Common.Partner.Partner Partner { get; set; }
  }
}
