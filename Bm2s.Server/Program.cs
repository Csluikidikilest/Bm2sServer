using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using Bm2s.Data.BLL.Trade;
using Bm2s.Data.BLL.User;
using Bm2s.Data.Utils;
using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;

namespace Bm2s.Server
{
  class Program
  {
    static int Main(string[] args)
    {
      Console.Write("Check database schema : ");
      try
      {
        Datas.Instance.CheckDatabaseSchema();
        Console.WriteLine("[OK]");
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return -1;
      }

      return 0;
    }
  }
}
