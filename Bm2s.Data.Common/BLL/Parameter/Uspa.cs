using System;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Uspa : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public string sValue { get; set; }

    public int iValue { get; set; }

    public double fValue { get; set; }

    public bool bValue { get; set; }

    public DateTime dValue { get; set; }

    [References(typeof(Para))]
    public int ParaId { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
