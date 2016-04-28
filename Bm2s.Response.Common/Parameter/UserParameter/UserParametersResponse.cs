using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Parameter.UserParameter
{
  public class UserParametersResponse: Response
  {
    public UserParametersResponse()
    {
      this.UserParameters = new List<Bm2s.Poco.Common.Parameter.UserParameter>();
    }

    public List<Bm2s.Poco.Common.Parameter.UserParameter> UserParameters { get; set; }
  }
}
