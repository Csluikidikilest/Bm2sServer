﻿using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.User
{
  public class Group : Table
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
  }
}
