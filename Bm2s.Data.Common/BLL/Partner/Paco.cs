﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class Paco : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string LastName { get; set; }

    [StringLength(200)]
    public string FirstName { get; set; }

    [StringLength(200)]
    public string Function { get; set; }

    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [StringLength(20)]
    public string MobilePhoneNumber { get; set; }

    [StringLength(20)]
    public string FaxNumber { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Part))]
    public int PartId { get; set; }
  }
}