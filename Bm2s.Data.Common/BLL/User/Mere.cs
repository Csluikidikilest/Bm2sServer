using System;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.User
{
  public class Mere : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime ReadingDate { get; set; }

    [References(typeof(Mess))]
    public int MessId { get; set; }

    [References(typeof(User))]
    public int UserId { get; set; }
  }
}
