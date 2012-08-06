using System;
using System.Globalization;
using System.Text;
using Microsoft.Win32;

namespace ETTrans
{
	public static class Config
	{
		private const string KEYNAME = "HKEY_CURRENT_USER\\Software\\ETTrans";

		private const string DEFAULT_GRID_FONT_NAME = "Microsoft Sans Serif";
		private const float DEFAULT_GRID_FONT_SIZE = 8.25f;

		private static NumberFormatInfo _nfi = null;
		private static NumberFormatInfo Nfi
		{
			get
			{
				if (Config._nfi == null)
				{
					Config._nfi = NumberFormatInfo.InvariantInfo;
				}
				return Config._nfi;
			}
		}
		private static string LoadSetting(string name, string defaultValue)
		{
			string result = Registry.GetValue(Config.KEYNAME, name, defaultValue) as string;
			return (result == null) ? defaultValue : result;
		}
		private static void SaveSetting(string name, string value)
		{
			Registry.SetValue(Config.KEYNAME, name, value, RegistryValueKind.String);
		}
		private static float LoadSetting(string name, float defaultValue)
		{
			string s = Config.LoadSetting(name, "");
			float f;
			if (string.IsNullOrEmpty(s) || (!float.TryParse(s, NumberStyles.Float, Config.Nfi, out f)))
			{
				return defaultValue;
			}
			else
			{
				return f;
			}
		}
		private static void SaveSetting(string name, float value)
		{
			Config.SaveSetting(name, value.ToString(Config.Nfi));
		}
		public static string GridFontName
		{
			get
			{
				string value;
				value = Config.LoadSetting("GridFontName", Config.DEFAULT_GRID_FONT_NAME);
				value = (value == null) ? null : value.Trim();
				return string.IsNullOrEmpty(value) ? Config.DEFAULT_GRID_FONT_NAME : value;
			}
			set
			{
				value = (value == null) ? null : value.Trim();
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("GridFontName");
				}
				Config.SaveSetting("GridFontName", value);
			}
		}
		public static float GridFontSize
		{
			get
			{
				float value;
				value = Config.LoadSetting("GridFontSize", Config.DEFAULT_GRID_FONT_SIZE);
				return (value <= 0f) ? Config.DEFAULT_GRID_FONT_SIZE : value;
			}
			set
			{
				if (value <= 0f)
				{
					throw new ArgumentOutOfRangeException("GridFontSize");
				}
				Config.SaveSetting("GridFontSize", value);
			}
		}
	}
}
