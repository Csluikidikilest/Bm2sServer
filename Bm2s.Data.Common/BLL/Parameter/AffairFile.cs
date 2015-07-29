using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class AffairFile : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public Byte[] File { get; set; }

    public DateTime AddingDate { get; set; }

    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [Ignore]
    public Affair Affair { get; set; }

    [References(typeof(User.User))]
    public int UserId { get; set; }

    [Ignore]
    public User.User User { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Affair = Datas.Instance.DataStorage.Affairs.FirstOrDefault<Affair>(item => item.Id == this.AffairId);
      this.User = Datas.Instance.DataStorage.Users.FirstOrDefault<User.User>(item => item.Id == this.UserId);
    }
  }
}
