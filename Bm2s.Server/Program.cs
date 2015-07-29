using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using ServiceStack.ServiceInterface;

namespace Bm2s.Server
{
  class Program
  {
    static int Main(string[] args)
    {
      Console.Write("Check database schema : ");
      try
      {
        Console.WriteLine("[OK]");

        Console.WriteLine("Loading plugins :");

        List<Assembly> assemblies = new List<Assembly>();
        assemblies.Add(LoadPlugin("Bm2s.Data.Common.dll"));
        assemblies.Add(LoadPlugin("Bm2s.Data.POS.dll"));
        Console.WriteLine("Loading plugins : [OK]");

        Console.Write("Starting Web Services : ");
        string url = string.Format("http://{0}:{1}/", ConfigurationManager.AppSettings["ListeningIp"], ConfigurationManager.AppSettings["ListeningPort"]);
        AppHost host = new AppHost(assemblies.ToArray());
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

    public static Assembly LoadPlugin(string assemblyName)
    {
      string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/plugins/" + assemblyName;
      Assembly assembly = Assembly.LoadFile(path);
      Type type;

      type = assembly.GetTypes().FirstOrDefault(t => t.Name == "Datas");
      if (type != null)
      {
        var datas = type.GetProperty("Instance").GetValue(null);
        if (datas == null)
        {
          throw new Exception("bad plugins");
        }
        type.InvokeMember("CheckDatabaseSchema", BindingFlags.InvokeMethod, null, datas, new object[] { });
      }

      return assembly;
    }
  }
}
