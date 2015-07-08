using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Affair
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    [Required] [StringLength(50)] public string Code { get; set; }
    public string Description { get; set; }
    public Activity Activity { get; set; }
    public List<AffairFile> AffairFiles { get; set; }
    public List<AffairHeader> AffairHeaders { get; set; }
    public User.User User { get; set; }
  }
}
