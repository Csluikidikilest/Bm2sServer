﻿using System.Reflection;
using Funq;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Bm2s.Service
{
  public class AppHost : AppHostHttpListenerBase
  {
    public AppHost(params Assembly[] assembliesWithServices)
      : base("Bm2s HttpListener", assembliesWithServices)
    {
    }

    public override void Configure(Container container)
    {
      using (JsConfig.BeginScope())
      {
        JsConfig.EmitCamelCaseNames = true;
        JsConfig.DateHandler = JsonDateHandler.ISO8601;
      }
    }
  }
}
