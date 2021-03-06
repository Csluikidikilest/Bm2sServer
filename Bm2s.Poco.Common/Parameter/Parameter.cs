﻿using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class Parameter
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public string ValueType { get; set; }

    public string sValue { get; set; }

    public int iValue { get; set; }

    public decimal fValue { get; set; }

    public bool bValue { get; set; }

    public DateTime? dValue { get; set; }

    public bool IsSystem { get; set; }

    public bool IsOverloadable { get; set; }
  }
}
