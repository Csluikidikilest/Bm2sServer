﻿using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class AddressLine : Table
  {
    public int Order { get; set; }

    [Required]
    public string Line { get; set; }

    [References(typeof(Address))]
    public int AddressId { get; set; }

    [Ignore]
    public Address Address { get; set; }
  }
}
