﻿using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Price : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double BasePrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article Article { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Article = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article>(item => item.Id == this.ArticleId);
    }
  }
}
