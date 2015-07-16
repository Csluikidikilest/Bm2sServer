﻿using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Partner;
using Bm2s.Data.BLL.Trade;
using Bm2s.Data.BLL.User;
using Bm2s.Data.Utils;
using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;
using Bm2s.Data;

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
        string url = string.Format("http://{0}:{1}/", ConfigurationManager.AppSettings["ListeningIp"], ConfigurationManager.AppSettings["ListeningPort"]);
        Console.WriteLine("[OK]");

        AppHost host = new AppHost();
        host.Init();
        host.Start(url);

        Console.WriteLine("Listening on " + url);

        while (!Command(Console.ReadLine()))
        {
          Console.WriteLine(".");
        }

      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return -1;
      }

      return 0;
    }

    public static bool Command(string command)
    {
      bool result = false;
      switch (command.Trim())
      {
        case "c":
        case "clear":
          Console.Clear();
          Command("h");
          break;
        case "h":
        case "help":
          Console.WriteLine();
          Console.WriteLine("---------------------------------------------------");
          Console.WriteLine("h or help       : this help");
          Console.WriteLine("q or quit       : quit server");
          Console.WriteLine("c or clear      : clear console");
          Console.WriteLine("---------------------------------------------------");
          Console.WriteLine();
          break;
        case "q":
        case "quit":
          result = true;
          break;
      }

      return result;
    }

  }
}
