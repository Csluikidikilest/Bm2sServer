using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response
{
  public static class RequestExtensions
  {
    public static void LoadFromNameValueCollection<T>(this T request, NameValueCollection parameters) where T : Request
    {
      foreach (string key in parameters)
      {
        var property = typeof(T).GetProperty(key);
        if (property != null)
        {
          property.SetValue(request, parameters[key]);
        }
      }
    }
  }
}
