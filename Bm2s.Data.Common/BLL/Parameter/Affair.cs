using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Affa")]
  public class Affair : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Alias("ActiId")]
    [References(typeof(Activity))]
    public int ActivityId { get; set; }

    [Alias("UserId")]
    [References(typeof(User.User))]
    public int UserId { get; set; }
  }
}
