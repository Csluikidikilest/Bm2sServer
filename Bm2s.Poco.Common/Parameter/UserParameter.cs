using System;

namespace Bm2s.Poco.Common.Parameter
{
  public class UserParameter
  {
    public int Id { get; set; }

    public string sValue { get; set; }

    public int iValue { get; set; }

    public double fValue { get; set; }

    public bool bValue { get; set; }

    public DateTime dValue { get; set; }

    public Parameter Parameter { get; set; }

    public User.User User { get; set; }
  }
}
