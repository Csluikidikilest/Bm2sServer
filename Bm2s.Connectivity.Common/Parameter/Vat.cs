using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Parameter.Vat;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Vat : ClientBase
  {
    public Vat()
      : base()
    {
      this.Request = new Vats();
      this.Response = new VatsResponse();
    }

    public Vats Request { get; set; }

    public VatsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
