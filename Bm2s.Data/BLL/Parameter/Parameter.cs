﻿using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Parameter : Table
  {
    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(1)]
    public string ValueType { get; set; }

    public string sValue { get; set; }

    public int iValue { get; set; }

    public double fValue { get; set; }

    public bool bValue { get; set; }

    public DateTime dValue { get; set; }
  }
}
