﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using ServiceStack.ServiceInterface;

namespace Bm2s.Server
{
  class Program
  {
    static List<Assembly> Assemblies { get; set; }

    static AppHost Host { get; set; }

    static string Url { get; set; }

    static int Main(string[] args)
    {
      Url = string.Format("http://{0}:{1}/", ConfigurationManager.AppSettings["ListeningIp"], ConfigurationManager.AppSettings["ListeningPort"]);
      try
      {
        LoadPlugins(false);

        System.Diagnostics.Process.Start(Url);

        Console.WriteLine("Listening on " + Url);

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

    private static bool Command(string command)
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
          Console.WriteLine("h or help        : this help");
          Console.WriteLine("q or quit        : quit server");
          Console.WriteLine("c or clear       : clear console");
          Console.WriteLine("test             : create some datas to test server");
          Console.WriteLine("---------------------------------------------------");
          Console.WriteLine();
          break;
        case "q":
        case "quit":
          result = true;
          break;
        case "test":
          Test();
          break;
        default:
          Console.WriteLine("Unknown command");
          Command("h");
          break;
      }

      return result;
    }

    private static void LoadPlugins(bool restart)
    {
      Assemblies = new List<Assembly>();
      Bm2s.Data.Common.Utils.Datas.Instance.CheckDatabaseSchema();
      Bm2s.Data.Common.Utils.Datas.Instance.CheckFirstUseDatas();
      Assemblies.Add(typeof(Bm2s.Services.Common.Article.Article.ArticlesService).Assembly);
      Host = new AppHost(Assemblies.ToArray());
      Host.Init();
      Host.Start(Url);
    }

    private static void Test()
    {
      Data.Common.Utils.Datas.Instance.DataStorage.CreateDatasForTest();
    }
  }
}
