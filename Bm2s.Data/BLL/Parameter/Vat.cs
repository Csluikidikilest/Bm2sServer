﻿using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Vat : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    public DateTime StaringDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public double Rate { get; set; }

    [Required]
    [StringLength(50)]
    public string AccountingEntry { get; set; }
  }
}
