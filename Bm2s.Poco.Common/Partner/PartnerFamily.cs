﻿using System;

namespace Bm2s.Poco.Common.Partner
{
  public class PartnerFamily
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Designation { get; set; }

    public string Description { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
