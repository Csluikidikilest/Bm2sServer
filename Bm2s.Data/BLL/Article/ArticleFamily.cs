using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleFamily
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }

    [Required] [StringLength(50)] public string Code { get; set; }

    [Required] [StringLength(250)] public string Designation { get; set; }

    public string Description { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }
  }
}
