﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerAddress
  {
    public Address Address { get; set; }
    public AddressType AddressType { get; set; }
    public Partner Partner { get; set; }
  }
}
