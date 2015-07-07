﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class SelectorColumn
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    [Required] [StringLength(50)] public string Code { get; set; }
    public string HeaderText { get; set; }
    public SelectorScreen SelectorScreen { get; set; }
  }
}
