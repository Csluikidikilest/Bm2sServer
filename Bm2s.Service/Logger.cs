using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bm2s.Service
{
  public static class Logger
  {
    public static void Write(Exception e)
    {
      StreamWriter sw = null;
      try
      {
        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\logFile.txt", true);
        sw.WriteLine(DateTime.Now.ToString() + ": " + e.Source.ToString().Trim() + ": " + e.Message.ToString().Trim());
        sw.Flush();
        sw.Close();
      }
      catch
      {
      }
    }

    public static void Write(string message)
    {
      StreamWriter sw = null;
      try
      {
        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\logFile.txt", true);
        sw.WriteLine(DateTime.Now.ToString() + ": " + message.Trim());
        sw.Flush();
        sw.Close();
      }
      catch
      {
      }
    }
  }
}
