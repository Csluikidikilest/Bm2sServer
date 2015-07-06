﻿using System.Collections.Generic;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using System;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerFamily
  {
    public int Id { get; private set; }
    public string Code { get; set; }
    public string Designation { get; set; }
    public string Description { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public List<ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }
    public List<ArticlePriceParnerFamily> ArticlePriceParnerFamilys { get; set; }
    public List<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }
    public List<PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }
  }
}
