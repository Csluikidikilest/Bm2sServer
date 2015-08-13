﻿using ServiceStack.OrmLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bm2s.Data.Utils.BLL
{
  public class Tables<T> : IList<T> where T : Table
  {
    private IDbConnection _dbConnection;

    private bool _ramStorage;

    private List<T> _innerList;

    public Tables(bool ramStorage, IDbConnection dbConnection)
    {
      this._dbConnection = dbConnection;
      this._ramStorage = ramStorage;

      if (this._ramStorage)
      {
        this._innerList = this._dbConnection.Select<T>();
      }
    }

    public int IndexOf(T item)
    {
      if (this._ramStorage)
      {
        return this._innerList.IndexOf(item);
      }
      else
      {
        return item.Id;
      }
    }

    public void Insert(int index, T item)
    {
      if (this._ramStorage)
      {
        this._innerList.Insert(index, item);
      }

      item.Save<T>(this._dbConnection);
    }

    public void RemoveAt(int index)
    {
      T item = null;
      if (this._ramStorage)
      {
        item = this._innerList[index];
        this._innerList.RemoveAt(index);
      }
      else
      {
        item = this._dbConnection.FirstOrDefault<T>(x => x.Id == index);
      }

      item.Delete<T>(this._dbConnection);
    }

    public T this[int index]
    {
      get
      {
        T result = null;

        if (this._ramStorage)
        {
          result = this._innerList[index];
        }
        else
        {
          result = this._dbConnection.FirstOrDefault<T>(x => x.Id == index);
        }

        return result;
      }
      set
      {
        if (this._ramStorage)
        {
          this._innerList[index] = value;
        }

        value.Save<T>(this._dbConnection);
      }
    }

    public void Add(T item)
    {
      if (this._ramStorage)
      {
        this._innerList.Add(item);
      }

      item.Save<T>(this._dbConnection);
    }

    public void Clear()
    {
      if (this._ramStorage)
      {
        this._innerList.Clear();
      }
    }

    public bool Contains(T item)
    {
      if (this._ramStorage)
      {
        return this._innerList.Contains(item);
      }
      else
      {
        return this._dbConnection.Where<T>(x => x.Id == item.Id).Any();
      }
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      int i = 0;
      List<T> items = this._innerList.Skip(arrayIndex).ToList();
      foreach (T item in items)
      {
        array[i] = item;
        i++;
      }
    }

    public int Count
    {
      get
      {
        if (this._ramStorage)
        {
          return this._innerList.Count;
        }
        else
        {
          return (int)this._dbConnection.Count<T>();
        }
      }
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

    public bool Remove(T item)
    {
      if (this._ramStorage)
      {
        this._innerList.Remove(item);
      }
      try
      {
        item.Delete<T>(this._dbConnection);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public IEnumerator<T> GetEnumerator()
    {
      if (this._ramStorage)
      {
        return this._innerList.GetEnumerator();
      }
      else
      {
        return this._dbConnection.Select<T>().GetEnumerator();
      }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
