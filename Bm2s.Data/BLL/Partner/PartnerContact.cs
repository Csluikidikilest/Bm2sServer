using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerContact
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Function { get; set; }
    public string PhoneNumber { get; set; }
    public string MobilePhoneNumber { get; set; }
    public string FaxNumber { get; set; }
    public string Email { get; set; }
    public string Observation { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public Partner Partner { get; set; }
  }
}
