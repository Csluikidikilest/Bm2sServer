﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceHost;

namespace Bm2s.Web.Utils
{
  public class Bm2sClient : IDisposable
  {
    private string _url;

    private JsonServiceClient _client;

    public Bm2sClient()
      : this(ConfigurationManager.ConnectionStrings["Bm2sServer"].ConnectionString)
    {
    }

    public Bm2sClient(string url)
    {
      this._url = url;
    }

    public JsonServiceClient Client
    {
      get
      {
        if (this._client == null)
        {
          this._client = new JsonServiceClient(this._url);
        }

        return this._client;
      }
    }

    public T Get<T>(IReturn<T> request)
    {
      return this.Client.Get(request);
    }

    public T Post<T>(IReturn<T> request)
    {
      return this.Client.Post(request);
    }

    public T Put<T>(IReturn<T> request)
    {
      return this.Client.Put(request);
    }

    public T Delete<T>(IReturn<T> request)
    {
      return this.Client.Delete(request);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected void Dispose(bool dispose)
    {
      if (dispose)
      {
        this._client.Dispose();
        this._client = null;
      }
    }
  }
}
