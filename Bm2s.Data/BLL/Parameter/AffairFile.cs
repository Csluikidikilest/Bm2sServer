using System;

namespace Bm2s.Data.BLL.Parameter
{
  public class AffairFile
  {
    public int Id { get; private set; }
    public string Name { get; set; }
    public Byte[] File { get; set; }
    public DateTime AddingDate { get; set; }
    public Affair Affair { get; set; }
    public User.User User { get; set; }
  }
}
