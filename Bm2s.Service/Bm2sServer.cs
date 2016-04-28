using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.ServiceProcess;
using System.Timers;

namespace Bm2s.Service
{
  public partial class Bm2sServer : ServiceBase
  {
    static List<Assembly> Assemblies { get; set; }

    static AppHost Host { get; set; }

    static string Url { get; set; }

    private System.Timers.Timer Timer { get; set; }

    public Bm2sServer()
    {
      InitializeComponent();

      this.Timer = new System.Timers.Timer();
      this.Timer.Interval = 60000;
      this.Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerElapsed);
    }

    protected void TimerElapsed(object sender, ElapsedEventArgs args)
    {
      Logger.Write("Everithing Ok !");
    }

    protected override void OnStart(string[] args)
    {
      Logger.Write("Starting Bm2s.");
      Url = string.Format("http://{0}:{1}/", ConfigurationManager.AppSettings["ListeningIp"], ConfigurationManager.AppSettings["ListeningPort"]);
      try
      {
        LoadPlugins(false);

        System.Diagnostics.Process.Start(Url);

        Logger.Write("Listening on " + Url);
        this.Timer.Enabled = true;
      }
      catch (Exception e)
      {
        Logger.Write(e);
      }
    }

    protected override void OnStop()
    {
      this.Timer.Enabled = false;
      Logger.Write("Stopping Bm2s.");
    }

    private static bool Command(string command)
    {
      bool result = false;
      switch (command.Trim())
      {
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
      Bm2s.Data.Common.Utils.Datas.Instance.CheckDatabaseSchema();
      Bm2s.Data.Common.Utils.Datas.Instance.CheckFirstUseDatas();
      Assemblies.Add(typeof(Bm2s.Services.Common.Article.Article.ArticlesService).Assembly);
      Host = new AppHost(Assemblies.ToArray());
      Host.Init();
      Host.Start(Url);
    }
  }
}
