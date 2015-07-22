﻿using System.Linq;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class SelectorColumn : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    public string HeaderText { get; set; }

    [References(typeof(SelectorScreen))]
    public int SelectorScreenId { get; set; }

    [Ignore]
    public SelectorScreen SelectorScreen { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.SelectorScreen = Datas.Instance.DataStorage.SelectorScreens.FirstOrDefault<SelectorScreen>(item => item.Id == this.SelectorScreenId);
    }
  }
}
