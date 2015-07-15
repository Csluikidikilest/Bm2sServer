using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Brand
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
