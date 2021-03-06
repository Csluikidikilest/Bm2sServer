﻿using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.Payment
{
  [Route("/bm2s/payments", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/payments/{Ids}", Verbs = "GET")]
  public class Payments : Request, IReturn<PaymentsResponse>
  {
    public Payments()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public string Reference { get; set; }

    public int PartnerId { get; set; }

    public int PaymentModeId { get; set; }

    public int UnitId { get; set; }

    public Bm2s.Poco.Common.Trade.Payment Payment { get; set; }
  }
}
