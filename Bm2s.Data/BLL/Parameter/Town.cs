using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Town
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public string ZipCode { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public Country Country { get; set; }
  }
}
