using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response
{
  public static class RequestExtensions
  {
    public static void LoadFromNameValueCollection<T>(this T request, NameValueCollection parameters) where T : Request
    {
      foreach (string key in parameters)
      {
        var property = typeof(T).GetProperty(key);
        if (property != null)
        {
          string stringValue = parameters[key];
          TypeCode typeCode = Type.GetTypeCode(property.PropertyType);
          switch (typeCode)
          {
            case TypeCode.Boolean:
              bool boolValue = false;
              bool.TryParse(stringValue, out boolValue);
              property.SetValue(request, boolValue);
              break;
            case TypeCode.Byte:
              byte byteValue = 0;
              byte.TryParse(stringValue, out byteValue);
              property.SetValue(request, byteValue);
              break;
            case TypeCode.Char:
              char charValue = stringValue.ToCharArray()[0];
              property.SetValue(request, charValue);
              break;
            case TypeCode.DateTime:
              DateTime dateValue = DateTime.MinValue;
              DateTime.TryParse(stringValue, out dateValue);
              property.SetValue(request, dateValue);
              break;
            case TypeCode.Decimal:
              decimal decimalValue = 0;
              decimal.TryParse(stringValue, out decimalValue);
              property.SetValue(request, decimalValue);
              break;
              case TypeCode.Double:
              double doubleValue = 0;
              double.TryParse(stringValue, out doubleValue);
              property.SetValue(request, doubleValue);
              break;
            case TypeCode.Int16:
              Int16 int16Value = 0;
              Int16.TryParse(stringValue, out int16Value);
              property.SetValue(request, int16Value);
              break;
            case TypeCode.Int32:
              Int32 int32Value = 0;
              Int32.TryParse(stringValue, out int32Value);
              property.SetValue(request, int32Value);
              break;
            case TypeCode.Int64:
              Int64 int64Value = 0;
              Int64.TryParse(stringValue, out int64Value);
              property.SetValue(request, int64Value);
              break;
            case TypeCode.SByte:
              sbyte sbyteValue = 0;
              sbyte.TryParse(stringValue, out sbyteValue);
              property.SetValue(request, sbyteValue);
              break;
            case TypeCode.Single:
              Single singleValue = 0;
              Single.TryParse(stringValue, out singleValue);
              property.SetValue(request, singleValue);
              break;
            case TypeCode.String:
              property.SetValue(request, stringValue);
              break;
            case TypeCode.UInt16:
              UInt16 uint16Value = 0;
              UInt16.TryParse(stringValue, out uint16Value);
              property.SetValue(request, uint16Value);
              break;
            case TypeCode.UInt32:
              UInt32 uint32Value = 0;
              UInt32.TryParse(stringValue, out uint32Value);
              property.SetValue(request, uint32Value);
              break;
            case TypeCode.UInt64:
              UInt64 uint64Value = 0;
              UInt64.TryParse(stringValue, out uint64Value);
              property.SetValue(request, uint64Value);
              break;
          }
        }
      }
    }
  }
}
