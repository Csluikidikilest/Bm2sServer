using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Brand
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    [Required] [StringLength(50)] public string Code { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
  }
}
