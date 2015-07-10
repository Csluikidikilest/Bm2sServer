﻿using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Trade
{
  public class Payment
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [ForeignKey("PartnerId")]
    public Partner.Partner Partner { get; set; }

    [References(typeof(PaymentMode))]
    public int PaymentModeId { get; set; }

    [ForeignKey("PaymentModeId")]
    public PaymentMode PaymentMode { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [ForeignKey("UnitId")]
    public Unit Unit { get; set; }

    [InverseProperty("Payment")]
    public List<Reconciliation> Reconciliations { get; set; }
  }
}
