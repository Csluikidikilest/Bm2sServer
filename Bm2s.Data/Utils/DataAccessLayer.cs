using Bm2s.Data.BLL.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Utils
{
  public class DataAccessLayer
  {
    private static DataAccessLayer __instance;

    public static DataAccessLayer Instance
    {
      get
      {
        if (__instance == null)
        {
          __instance = new DataAccessLayer();
        }

        return __instance;
      }
    }

    public void LoadDatas()
    {
      this.LoadArticles();
    }

    public List<Article> Articles { get; private set; }

    public void LoadArticles()
    {
      string SQL = "SELECT * FROM article";
      List<Article> articles = new List<Article>();

      this.Articles = articles;
    }
  }
}
