using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderStatus
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public List<HeaderStatusStep> HeaderStatusStepParents { get; set; }

    public List<HeaderStatusStep> HeaderStatusStepChildren { get; set; }
  }
}
