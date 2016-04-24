using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Tran : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Application { get; set; }

    [Required]
    [StringLength(250)]
    public string Screen{ get; set; }

    [Required]
    [StringLength(250)]
    public string Key { get; set; }

    [Required]
    public string Value { get; set; }

    [References(typeof(Lang))]
    public int LangId { get; set; }
  }
}
