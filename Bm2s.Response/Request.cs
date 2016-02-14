using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response
{
  public class Request
  {
    public bool DescendingOrder { get; set; }

    public int CurrentPage { get; set; }

    public List<int> Ids { get; set; }

    public string Order { get; set; }

    public int PageSize { get; set; }
  }
}
