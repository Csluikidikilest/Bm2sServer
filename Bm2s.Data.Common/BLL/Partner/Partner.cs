using ServiceStack.DataAnnotations;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Partner
{
  public class Partner : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [StringLength(250)]
    public string CompanyName { get; set; }

    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [StringLength(20)]
    public string FaxNumber { get; set; }

    public string WebSite { get; set; }

    public string CompanyIdentifier { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    public string Observation { get; set; }

    [Default(1)]
    public double? PriceMultiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public bool IsCustomer { get; set; }

    public bool IsSupplier { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [Ignore]
    public User.User User { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User.User>(item => item.Id == this.UserId);
    }
  }
}
