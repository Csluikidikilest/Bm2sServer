﻿using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Unit : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsCurrency { get; set; }

    public bool IsPeriod { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
