﻿using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class AffairFile : Table
  {
    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [Ignore]
    public Affair Affair { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [Ignore]
    public User.User User { get; set; }
  }
}
