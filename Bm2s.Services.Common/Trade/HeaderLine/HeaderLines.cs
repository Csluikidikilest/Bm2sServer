using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.HeaderLine
{
  [Route("/bm2s/headerlines", Verbs = "GET, POST")]
  [Route("/bm2s/headerlines/{Ids}", Verbs = "GET")]
  public class HeaderLines : IReturn<HeaderLinesResponse>
  {
    public HeaderLines()
    {
      this.Ids = new List<int>();
    }

    public int ArticleFamilyId { get; set; }

    public int ArticleId { get; set; }

    public int ArticleSubFamilyId { get; set; }

    public int BrandId { get; set; }

    public string Code { get; set; }

    public string Designation { get; set; }

    public int HeaderId { get; set; }

    public int HeaderLineTypeId { get; set; }

    public List<int> Ids { get; set; }

    public int LineNumber { get; set; }

    public int UnitId { get; set; }

    public Bm2s.Data.Common.BLL.Trade.HeaderLine HeaderLine { get; set; }
  }
}
