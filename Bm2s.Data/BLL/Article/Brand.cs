using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  [Table("Brand", Schema = "Article")]
  public class Brand
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(50)]
    public string Code { get; set; }

    [StringLength(400)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [InverseProperty("Brand")]
    public List<Article> Articles { get; set; }
  }
}
