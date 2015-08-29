using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response
{
  public class Request
  {
    private bool _ascendingOrder = true;

    private int _currentPage = 1;

    private string _order = "Id";

    private int _pageSize = 20;

    public bool AscendingOrder
    {
      get { return this._ascendingOrder; }
      set { this._ascendingOrder = value; }
    }

    public int CurrentPage
    {
      get { return this._currentPage; }
      set { this._currentPage = value; }
    }

    public List<int> Ids { get; set; }

    public string Order
    {
      get { return this._order; }
      set { this._order = value; }
    }

    public int PageSize
    {
      get { return this._pageSize; }
      set { this._pageSize = value; }
    }
  }
}
