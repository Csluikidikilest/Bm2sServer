using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Affi : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] Content { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Affa))]
    public int AffaId { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
