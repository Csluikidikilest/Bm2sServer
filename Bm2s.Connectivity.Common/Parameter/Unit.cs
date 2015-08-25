﻿using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Parameter.Unit;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Unit : ClientBase
  {
    public Unit()
      : base()
    {
      this.Request = new Units();
      this.Response = new UnitsResponse();
    }

    public Units Request { get; set; }

    public UnitsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
