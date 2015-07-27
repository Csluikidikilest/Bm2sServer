using Bm2s.Data.Common.Utils;
using System;
using System.Configuration;

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

        Console.Write("Starting Web Services : ");
        string url = string.Format("http://{0}:{1}/", ConfigurationManager.AppSettings["ListeningIp"], ConfigurationManager.AppSettings["ListeningPort"]);
        AppHost host = new AppHost();
        host.Init();
        host.Start(url);
        Console.WriteLine("[OK]");

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
        case "test" :
          Datas.Instance.CreateDatasForTest();
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
