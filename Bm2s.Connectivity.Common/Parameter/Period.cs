﻿using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Parameter.Period;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class Period : ClientBase
  {
    public Period()
      : base()
    {
      this.Request = new Periods();
      this.Response = new PeriodsResponse();
    }

    public Periods Request { get; set; }

    public PeriodsResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}
