using System;
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

    static string PluginsPath { get; set; }

    static string Url { get; set; }

    static FileSystemWatcher Watcher { get; set; }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    static int Main(string[] args)
    {
      PluginsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "plugins" + Path.DirectorySeparatorChar;
      Url = string.Format("http://{0}:{1}/", ConfigurationManager.AppSettings["ListeningIp"], ConfigurationManager.AppSettings["ListeningPort"]);
      try
      {
        Console.Write("Loading file watcher : ");
        Watcher = new FileSystemWatcher();
        Watcher.Path = PluginsPath;
        Watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.Security;
        Watcher.Filter = "*.dll";
        Watcher.Changed += new FileSystemEventHandler(OnChanged);
        Watcher.Created += new FileSystemEventHandler(OnChanged);
        Watcher.Deleted += new FileSystemEventHandler(OnChanged);
        Watcher.Renamed += new RenamedEventHandler(OnRenamed);
        Watcher.EnableRaisingEvents = true;
        Console.WriteLine("[OK]");

        LoadPlugins(false);

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

    private static void LoadPlugins(bool restart)
    {
      Assemblies = new List<Assembly>();
      foreach (string path in Directory.GetFiles(PluginsPath).Where(name => name.ToLower().EndsWith(".dll")))
      {
        Assemblies.Add(LoadPlugin(path));
      }

      if (restart)
      {
        Console.Write("Restarting Web Services : ");
      }
      else
      {
        Console.Write("Starting Web Services : ");
      }

      if (restart)
      {
        Host.Stop();
        Host.Dispose();
      }

      Host = new AppHost(Assemblies.ToArray());
      Host.Init();
      Host.Start(Url);
      Console.WriteLine("[OK]");
    }

    private static Assembly LoadPlugin(string path)
    {
      Console.Write("Loading " + Path.GetFileNameWithoutExtension(path) + " plugin : ");
      string assemblyName = Path.GetFileName(path);
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

      Console.WriteLine("[OK]");
      return assembly;
    }

    private static void OnChanged(object source, FileSystemEventArgs e)
    {
      LoadPlugins(true);
    }

    private static void OnRenamed(object source, RenamedEventArgs e)
    {
      LoadPlugins(true);
    }
  }
}
