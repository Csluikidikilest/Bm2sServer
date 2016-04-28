using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Service
{
  static class Program
  {
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    static void Main()
    {
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[] 
            { 
                new Bm2sServer() 
            };
      ServiceBase.Run(ServicesToRun);
    }
  }
}
