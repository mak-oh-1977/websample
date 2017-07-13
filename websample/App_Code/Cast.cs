using System;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Util
{
	public class Cast
	{
		public Cast()
		{
		}
		public static SByte ToSByte(Object inValue,SByte inDefaultValue)
		{
			SByte ReturnValue = inDefaultValue;
			SByte x = 0;

			if (SByte.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Int16 ToInt16(Object inValue,Int16 inDefaultValue)
		{
			Int16 ReturnValue = inDefaultValue;
			Int16 x = 0;

			if (Int16.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Int32 ToInt32(Object inValue,Int32 inDefaultValue)
		{
			Int32 ReturnValue = inDefaultValue;
			Int32 x = 0;

			if (Int32.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Int64 ToInt64(Object inValue,Int64 inDefaultValue)
		{
			Int64 ReturnValue = inDefaultValue;
			Int64 x = 0;

			if (Int64.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Byte ToByte(Object inValue,Byte inDefaultValue)
		{
			Byte ReturnValue = inDefaultValue;
			Byte x = 0;

			if (Byte.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static UInt16 ToUInt16(Object inValue,UInt16 inDefaultValue)
		{
			UInt16 ReturnValue = inDefaultValue;
			UInt16 x = 0;

			if (UInt16.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static UInt32 ToUInt32(Object inValue,UInt32 inDefaultValue)
		{
			UInt32 ReturnValue = inDefaultValue;
			UInt32 x = 0;

			if (UInt32.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static UInt64 ToUInt64(Object inValue,UInt64 inDefaultValue)
		{
			UInt64 ReturnValue = inDefaultValue;
			UInt64 x = 0;

			if (UInt64.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Single ToSingle(Object inValue, Single inDefaultValue)
		{
			Single ReturnValue = inDefaultValue;
			Single x = 0;

			if (Single.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Double ToDouble(Object inValue, Double inDefaultValue)
		{
			Double ReturnValue = inDefaultValue;
			Double x = 0;

			if (Double.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
        public static Decimal ToDecimal(Object inValue, Decimal inDefaultValue)
        {
            Decimal ReturnValue = inDefaultValue;
            Decimal x = inDefaultValue;

            if (Decimal.TryParse(Cast.ToString(inValue), out x) == true)
            {
                ReturnValue = x;
            }
            return ReturnValue;
        }
        public static Boolean ToBoolean(Object inValue, Boolean inDefaultValue)
		{
			Boolean ReturnValue = inDefaultValue;
			Boolean x = inDefaultValue;

			if (Boolean.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static SByte? ToSByte(Object inValue)
		{
			SByte? ReturnValue = null;
			SByte x = 0;

			if (SByte.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Int16? ToInt16(Object inValue)
		{
			Int16? ReturnValue = null;
			Int16 x = 0;

			if (Int16.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Int32? ToInt32(Object inValue)
		{
			Int32? ReturnValue = null;
			Int32 x = 0;

			if (Int32.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Int64? ToInt64(Object inValue)
		{
			Int64? ReturnValue = null;
			Int64 x = 0;

			if (Int64.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Byte? ToByte(Object inValue)
		{
			Byte? ReturnValue = null;
			Byte x = 0;

			if (Byte.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static UInt16? ToUInt16(Object inValue)
		{
			UInt16? ReturnValue = null;
			UInt16 x = 0;

			if (UInt16.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static UInt32? ToUInt32(Object inValue)
		{
			UInt32? ReturnValue = null;
			UInt32 x = 0;

			if (UInt32.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static UInt64? ToUInt64(Object inValue)
		{
			UInt64? ReturnValue = null;
			UInt64 x = 0;

			if (UInt64.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Single? ToSingle(Object inValue)
		{
			Single? ReturnValue = null;
			Single x = 0;

			if (Single.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Double? ToDouble(Object inValue)
		{
			Double? ReturnValue = null;
			Double x = 0;

			if (Double.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
        public static Decimal? ToDecimal(Object inValue)
        {
            Decimal? ReturnValue = null;
            Decimal x = 0;

            if (inValue == null)
            { return ReturnValue; }

            if (Decimal.TryParse(Cast.ToString(inValue), out x) == true)
            {
                ReturnValue = x;
            }
            return ReturnValue;
        }
        public static Boolean? ToBoolean(Object inValue)
		{
			Boolean? ReturnValue = null;
			Boolean x = false;

			if (inValue == null)
			{ return ReturnValue; }

			if (Boolean.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static String ToStringOrNull(Object inValue)
		{
			if (inValue == null)
			{
				return null;
			}
			else
			{
				return inValue.ToString();
			}
		}
		public static String ToStringOrNull(String inValue)
		{
			if (inValue == "")
			{
				return null;
			}
			else
			{
				return inValue;
			}
		}
		public static String ToString(Object inValue)
		{
			if (inValue == null)
			{
				return "";
			}
			else
			{
				return inValue.ToString();
			}
		}
		public static Object ToDBValue(Object inValue)
		{
			if (inValue == null)
			{
				return DBNull.Value;
			}
			else
			{
				return inValue;
			}
		}
		public static DateTime? ToDateTime(Object inValue)
		{
			DateTime? ReturnValue = null;
			DateTime x;

			if (inValue == null)
			{ return ReturnValue; }

			if (DateTime.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static DateTime ToDateTime(Object inValue,DateTime inDefaultValue)
		{
			DateTime ReturnValue = inDefaultValue;
			DateTime x;

			if (DateTime.TryParse(Cast.ToString(inValue), out x) == true)
			{
				ReturnValue = x;
			}
			return ReturnValue;
		}
		public static Guid ToGuid(Object inValue, Guid inDefaultValue)
		{
			Guid ReturnValue = inDefaultValue;

            if (inValue == null)
            { return ReturnValue; }
            if (String.IsNullOrEmpty(inValue.ToString()) == true)
            { return ReturnValue; }

			try
			{
				ReturnValue = new Guid(Cast.ToString(inValue));
			}
			catch (FormatException inException)
			{
			}
			return ReturnValue;
		}
		public static Guid? ToGuid(Object inValue)
		{
			Guid? ReturnValue = null;

			if (inValue == null)
			{ return ReturnValue; }
            if (String.IsNullOrEmpty(inValue.ToString()) == true)
            { return ReturnValue; }

			try
			{
				ReturnValue = new Guid(Cast.ToString(inValue));
			}
			catch (FormatException inException)
			{
			}
			return ReturnValue;
		}
		public static Unit ToUnit(Object inValue, Unit inDefaultValue)
		{
			Unit ReturnValue = inDefaultValue;
				
			if(inValue==null)
			{return ReturnValue;}

			try
			{
				ReturnValue = Unit.Parse(Cast.ToString(inValue));
			}
			catch(SystemException inException)
			{
			}
			return ReturnValue;
		}
		public static String ToHyperLink(String inUrl, String inTarget)
		{
			String ReturnValue = inUrl;
			ReturnValue = Regex.Replace(inUrl, @"([^=""]|^)(http\:[\w\.\~\-\/\?\&\=\@\;\#\:\%]+)"
				, "$1<a href=\"$2\" target=\"" + inTarget + "\">$2</a>");
			return ReturnValue;
		}
		public static Boolean IsFontUnit(Object inValue)
		{
			Boolean ReturnValue = false;
			try
			{
				Object Result = FontUnit.Parse(Cast.ToString(inValue));
				ReturnValue = true;
			}
			catch
			{
				ReturnValue = false;
			}
			return ReturnValue;
		}
	}
}

















