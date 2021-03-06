﻿using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Lang")]
  public class Language : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(5)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }
  }
}
