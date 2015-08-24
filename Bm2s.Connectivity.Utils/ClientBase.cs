using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bm2s.Connectivity.Utils
{
  public class ClientBase
  {
    public ClientBase()
    {
      this.ConnectorHelper = new ConnectorHelper();
    }

    public ConnectorHelper ConnectorHelper { get; protected set; }

    public bool IsFilled { get; protected set; }

    public void LoadParamFromString(string parameters)
    {
      parameters = HttpUtility.UrlDecode(parameters);
      NameValueCollection param = new NameValueCollection();
      char[] split = { '=' };
      foreach (string parameter in parameters.Split('&'))
      {
        string[] keyValue = parameter.Split(split, 2);
        if (keyValue.Length == 2)
        {
          param.Add(keyValue[0], keyValue[1]);
        }
      }

      this.LoadFromNameValueCollection(param);
    }

    public void LoadParamFromUrl()
    {
      this.LoadFromNameValueCollection(HttpContext.Current.Request.QueryString);
    }

    protected virtual void LoadFromNameValueCollection(NameValueCollection param)
    {
    }
  }
}
