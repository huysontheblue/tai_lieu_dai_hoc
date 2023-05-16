using System;
using System.Globalization;
namespace UIHandler
{
	public class DateTimeHelper
	{
		public static string GetToday()
		{
			return DateTime.Now.ToString("yyyy-MM-dd");
		}
		public static string GetToday(string format)
		{
			return DateTime.Now.ToString(format);
		}
		public static string GetDate(int i)
		{
			return DateTime.Now.AddDays((double)i).ToString("yyyy-MM-dd");
		}
		public static string GetNumberWeekDay(DateTime dt)
		{
			int num = dt.Year;
			int num2 = dt.Month;
			int num3 = dt.Day;
			if (num2 < 3)
			{
				num2 += 12;
				num--;
			}
			if (num % 400 == 0 || (num % 100 != 0 && num % 4 == 0))
			{
				num3--;
			}
			else
			{
				num3++;
			}
			return ((num3 + 2 * num2 + 3 * (num2 + 1) / 5 + num + num / 4 - num / 100 + num / 400) % 7).ToString();
		}
		public string GetChineseWeekDay(int y, int m, int d)
		{
			string[] array = new string[]
			{
				"日",
				"一",
				"二",
				"三",
				"四",
				"五",
				"六"
			};
			if (m < 3)
			{
				m += 12;
				y--;
			}
			if (y % 400 == 0 || (y % 100 != 0 && y % 4 == 0))
			{
				d--;
			}
			else
			{
				d++;
			}
			return "星期" + array[(d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7];
		}
		public static int GetDaysOfYear(int iYear)
		{
			if (!DateTimeHelper.IsRuYear(iYear))
			{
				return 365;
			}
			return 366;
		}
		public static int GetDaysOfYear(DateTime dt)
		{
			if (!DateTimeHelper.IsRuYear(dt.Year))
			{
				return 365;
			}
			return 366;
		}
		public static int GetDaysOfMonth(int iYear, int Month)
		{
			int result = 0;
			switch (Month)
			{
			case 1:
				result = 31;
				break;
			case 2:
				result = (DateTimeHelper.IsRuYear(iYear) ? 29 : 28);
				break;
			case 3:
				result = 31;
				break;
			case 4:
				result = 30;
				break;
			case 5:
				result = 31;
				break;
			case 6:
				result = 30;
				break;
			case 7:
				result = 31;
				break;
			case 8:
				result = 31;
				break;
			case 9:
				result = 30;
				break;
			case 10:
				result = 31;
				break;
			case 11:
				result = 30;
				break;
			case 12:
				result = 31;
				break;
			}
			return result;
		}
		public static int GetDaysOfMonth(DateTime dt)
		{
			int result = 0;
			int year = dt.Year;
			switch (dt.Month)
			{
			case 1:
				result = 31;
				break;
			case 2:
				result = (DateTimeHelper.IsRuYear(year) ? 29 : 28);
				break;
			case 3:
				result = 31;
				break;
			case 4:
				result = 30;
				break;
			case 5:
				result = 31;
				break;
			case 6:
				result = 30;
				break;
			case 7:
				result = 31;
				break;
			case 8:
				result = 31;
				break;
			case 9:
				result = 30;
				break;
			case 10:
				result = 31;
				break;
			case 11:
				result = 30;
				break;
			case 12:
				result = 31;
				break;
			}
			return result;
		}
		public static string GetWeekNameOfDay(DateTime dt)
		{
			string result = string.Empty;
			switch (dt.DayOfWeek)
			{
			case DayOfWeek.Sunday:
				result = "星期日";
				break;
			case DayOfWeek.Monday:
				result = "星期一";
				break;
			case DayOfWeek.Tuesday:
				result = "星期二";
				break;
			case DayOfWeek.Wednesday:
				result = "星期三";
				break;
			case DayOfWeek.Thursday:
				result = "星期四";
				break;
			case DayOfWeek.Friday:
				result = "星期五";
				break;
			case DayOfWeek.Saturday:
				result = "星期六";
				break;
			}
			return result;
		}
		public static int GetWeekNumberOfDay(DateTime dt)
		{
			int result = 0;
			switch (dt.DayOfWeek)
			{
			case DayOfWeek.Sunday:
				result = 7;
				break;
			case DayOfWeek.Monday:
				result = 1;
				break;
			case DayOfWeek.Tuesday:
				result = 2;
				break;
			case DayOfWeek.Wednesday:
				result = 3;
				break;
			case DayOfWeek.Thursday:
				result = 4;
				break;
			case DayOfWeek.Friday:
				result = 5;
				break;
			case DayOfWeek.Saturday:
				result = 6;
				break;
			}
			return result;
		}
		public static int GetWeekAmount(int year)
		{
			DateTime time = new DateTime(year, 12, 31);
			GregorianCalendar gregorianCalendar = new GregorianCalendar();
			return gregorianCalendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
		}
		public static int GetWeekOfYear(DateTime dt)
		{
			GregorianCalendar gregorianCalendar = new GregorianCalendar();
			return gregorianCalendar.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
		}
		public static void WeekRange(int year, int weekOrder, ref DateTime firstDate, ref DateTime lastDate)
		{
			DateTime dateTime = new DateTime(year, 1, 1);
			int num = Convert.ToInt32(dateTime.DayOfWeek);
			int num2 = -1 * num + 1;
			int num3 = 7 - num;
			firstDate = dateTime.AddDays((double)num2).Date;
			lastDate = dateTime.AddDays((double)num3).Date;
			if (weekOrder != 1)
			{
				int num4 = (weekOrder - 1) * 7;
				firstDate = firstDate.AddDays((double)num4);
				lastDate = lastDate.AddDays((double)num4);
			}
		}
		public static int DiffDays(DateTime dtfrm, DateTime dtto)
		{
			return (dtto.Date - dtfrm.Date).Days;
		}
		private static bool IsRuYear(int iYear)
		{
			return iYear % 400 == 0 || (iYear % 4 == 0 && iYear % 100 != 0);
		}
		public static DateTime ToDate(string strInput)
		{
			DateTime result;
			try
			{
				result = DateTime.Parse(strInput);
			}
			catch (Exception)
			{
				result = DateTime.Today;
			}
			return result;
		}
		public static string ToString(DateTime oDateTime, string strFormat)
		{
			string result;
			try
			{
				string text = strFormat.ToUpper();
				if (text != null)
				{
					if (text == "SHORTDATE")
					{
						result = oDateTime.ToShortDateString();
						goto IL_41;
					}
					if (text == "LONGDATE")
					{
						result = oDateTime.ToLongDateString();
						goto IL_41;
					}
				}
				result = oDateTime.ToString(strFormat);
				IL_41:;
			}
			catch (Exception)
			{
				result = oDateTime.ToShortDateString();
			}
			return result;
		}
	}
}
