using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Utils
{
  public static class KeyValidator
  {
    /// <summary>
    /// Key for encode/decode
    /// </summary>
    protected static string Key
    {
      get
      {
        return "Bm2sLicenceValidator" + "" + ClientName;
      }
    }

    /// <summary>
    /// Client name
    /// </summary>
    protected static string ClientName
    {
      get
      {
        return ConfigurationManager.AppSettings["ClientName"];
      }
    }

    /// <summary>
    /// Decode a string
    /// </summary>
    /// <param name="s">The string to decode</param>
    /// <returns>The string decoded</returns>
    protected static string Decode(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return null;
      }

      byte[] bytes = Convert.FromBase64String(s);
      MemoryStream mem = new MemoryStream();
      DESCryptoServiceProvider des = new DESCryptoServiceProvider();
      des.IV = Encoding.ASCII.GetBytes(Key);
      des.Key = des.IV;
      CryptoStream crypto = new CryptoStream(mem, des.CreateDecryptor(), CryptoStreamMode.Write);
      crypto.Write(bytes, 0, bytes.Length);
      crypto.Close();
      string decode = Encoding.ASCII.GetString(mem.ToArray());
      mem.Close();
      return decode;
    }

    /// <summary>
    /// Encode a string
    /// </summary>
    /// <param name="s">The string to encode</param>
    /// <returns>The string encoded</returns>
    protected static string Encode(string s)
    {
      byte[] bytes = Encoding.ASCII.GetBytes(s);
      MemoryStream mem = new MemoryStream();
      DESCryptoServiceProvider des = new DESCryptoServiceProvider();
      des.IV = Encoding.ASCII.GetBytes(Key);
      des.Key = des.IV;
      CryptoStream crypto = new CryptoStream(mem, des.CreateEncryptor(), CryptoStreamMode.Write);
      crypto.Write(bytes, 0, bytes.Length);
      crypto.Close();
      string encode = Convert.ToBase64String(mem.ToArray());
      mem.Close();
      return encode;
    }

  }
}
