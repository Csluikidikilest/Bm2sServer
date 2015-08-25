using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Client.Test
{
  class Program
  {
    static void Main(string[] args)
    {
      Bm2s.Connectivity.Common.Article.Article articleConnector = new Connectivity.Common.Article.Article();
      articleConnector.Get();
      foreach (Bm2s.Poco.Common.Article.Article article in articleConnector.Response.Articles)
      {
        Console.WriteLine(article.Designation);
      }

      Console.ReadLine();
    }
  }
}
