﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class Brand
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
  }
}
