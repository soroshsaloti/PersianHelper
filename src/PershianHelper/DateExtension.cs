namespace PershianHelper;
using System.Globalization;
using UtilityHelper;

public static class DateExtension
{

    public static string GetSolarDateString(this DateTime datetime)
    {
        PersianCalendar pc = new PersianCalendar();
        int day = pc.GetDayOfMonth(datetime);
        int month = pc.GetMonth(datetime);
        int year = pc.GetYear(datetime);

        return year.ToString() + "/" + month.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0');
    }


    public static int GetSolarDateInteger(this DateTime datetime)
    {
        return GetSolarDateString(datetime).Replace("/", "").ToInt32();
    }


    public static int? GetSolarDateIntegerNull(this DateTime datetime)
    {
        if (string.IsNullOrEmpty(datetime.ToString()))
        {
            return null;
        }
        else
        {
            return GetSolarDateString(datetime).Replace("/", "").ToInt32Null();
        }

    }


    public static int GetSolarDateYaerAndMonthInteger(this string datetime, int addMonth = 0)
    {
        dynamic dt = datetime.FromSolarDate();
        dt = dt.AddMonths(addMonth);
        return dt.GetSolarDateString.Replace("/", "").Substring(0, 6);
    }
    public static int GetSolarDateSub(this string beginTime, string endTime)
    {
        dynamic bdt = beginTime.FromSolarDate();
        dynamic edt = endTime.FromSolarDate();
        TimeSpan def = edt.Subtract(bdt);
        return def.Days;
    }


    public static DateTime FromSolarDate(this string solarDate)
    {

        if (solarDate.Length != 10)
        {
            throw new NotSupportedException("رشته ورودی نشان دهنده یک تاریخ شمسی نمی باشد  تاریخ باید به شکل ");
        }
        string[] strs = solarDate.Split('/');
        if (strs.Length != 3)
        {
            throw new NotSupportedException("رشته ورودی نشان دهنده یک تاریخ شمسی نمی باشد  تاریخ باید به شکل ");
        }
        int day = 0;
        int month = 0;
        int year = 0;
        try
        {
            day = int.Parse(strs[2]);
        }
        catch
        {
        }
        try
        {
            month = int.Parse(strs[1]);
        }
        catch
        {
        }
        try
        {
            year = int.Parse(strs[0]);
        }
        catch
        {
        }

        if (year == 0 || day == 0 || month == 0)
        {
            throw new NotSupportedException("رشته ورودی نشان دهنده یک تاریخ شمسی نمی باشد  تاریخ باید به شکل ");
        }
        PersianCalendar pc = new PersianCalendar();
        try
        {
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
        catch
        {
            if (month == 12 && day > 29)
            {
                day = 29;
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            else return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


    }

    public static int GetSolarDateTrueFormatInteger(this string solarDate)
    {
        try
        {
            return solarDate.GetSolarDateTrueFormat().GetSolarDateInteger();
        }
        catch
        {
            return 0;
        }
    }



    public static string GetSolarDateTrueFormatString(this string solarDate)
    {
        try
        {
            return solarDate.GetSolarDateTrueFormat().GetSolarDateString();
        }
        catch
        {
            return string.Empty;
        }
    }

    public static DateTime GetSolarDateTrueFormat(this string solarDate)
    {

        return FromSolarDate(solarDate);
    }



    public static int GetSolarDateStrTointeger(this string solarDate)
    {
        try
        {
            return solarDate.Replace("/", "").ToInt32();
        }
        catch
        {
            return 0;
        }

    }


    public static int? GetSolarDateStrTointegerNull(this string solarDate)
    {
        try
        {
            if (string.IsNullOrEmpty(solarDate))
            {
                return null;
            }
            else
            {
                return solarDate.Replace("/", "").ToInt32Null();
            }

        }
        catch
        {
            return null;
        }

    }

    public static string GetSolarDateintegerToStr(this int solarDate)
    {
        if (solarDate == 0)
        {
            return string.Empty;
        }
        if (solarDate.ToString().Length == 6)
        {
            return solarDate.ToString().Insert(2, "/").Insert(5, "/");
        }

        return solarDate.ToString().Insert(4, "/").Insert(7, "/");
    }

    ///TO do:Set Corect
    //[System.Runtime.CompilerServices.Extension()]
    //public static string GetSolarDateintegerToStrWithout13(int? solarDate)
    //{
    //    string strResult = solarDate.ToString().Insert(4, "/").Insert(7, "/");
    //    return Strings.Mid(strResult, 3);
    //}

    //[System.Runtime.CompilerServices.Extension()]
    //public static string GetSolarDateintegerToStrWithout13(int solarDate)
    //{
    //    string strResult = solarDate.ToString().Insert(4, "/").Insert(7, "/");
    //    return Strings.Mid(strResult, 3);
    //}

    public static string GetSolarDateintegerToStr(this int? solarDate)
    {

        if (solarDate.HasValue)
        {
            if (solarDate == 0)
            {
                return string.Empty;
            }
            return solarDate.Value.ToString().Insert(4, "/").Insert(7, "/");
        }
        return null;
    }

    public static string DayOfWeekInPersianFromSolarDate(this string date)
    {
        return DayOfWeekInPersian(date.FromSolarDate());
    }


    public static string DayOfWeekInPersian(this DateTime datetime)
    {
        switch (datetime.DayOfWeek)
        {
            case DayOfWeek.Friday:
                return "جمعه";
            case DayOfWeek.Monday:
                return "دوشنبه";
            case DayOfWeek.Saturday:
                return "شنبه";
            case DayOfWeek.Sunday:
                return "یکشنبه";
            case DayOfWeek.Thursday:
                return "پنجشنبه";
            case DayOfWeek.Tuesday:
                return "سه شنبه";
            case DayOfWeek.Wednesday:
                return "چهارشنبه";
            default:
                return "نامشخص";
        }
    }

    public static string MonthOfYearInPersianFromMiladiDate(DateTime datee)
    {
        return MonthOfYearInPersianFromSolarDate(datee.GetSolarDateString());
    }
    
    public static string MonthOfYearInPersianFromSolarDate(this string date)
    {
        try
        {
            string[] split = date.Split('/');
            string result = "";

            switch (split[1].ToInt16())
            {
                case 1:
                    result = "فروردین";
                    break;
                case 2:
                    result = "اردیبهشت";
                    break;
                case 3:
                    result = "خرداد";
                    break;
                case 4:
                    result = "تیر";
                    break;
                case 5:
                    result = "مرداد";
                    break;
                case 6:
                    result = "شهریور";
                    break;
                case 7:
                    result = "مهر";
                    break;
                case 8:
                    result = "آبان";
                    break;
                case 9:
                    result = "آذر";
                    break;

                case 10:
                    result = "دی";
                    break;
                case 11:
                    result = "بهمن";
                    break;
                case 12:
                    result = "اسفند";
                    break;
                default:
                    result = " ";
                    break;
            }

            return result;
        }
        catch
        {
            throw new Exception("تاریخ شمسی وارد شده صحیح نمی باشد");
        }

    }

    // public static string funAddToDateString(string dateInput, int intYear, int intMonth, int intDay)
    //{
    //    string y = null;
    //    string m = null;
    //    string d = null;
    //    string r = null;
    //    System.Globalization.PersianCalendar g = new System.Globalization.PersianCalendar();
    //    System.DateTime dateTemp = default(System.DateTime);

    //    try
    //    {
    //        y = Strings.Left(dateInput, 4);
    //        //جدا سازی 4 رقم عدد سال 
    //        m = Strings.Mid(dateInput, 6, 2);
    //        //جدا سازی دو رقم عدد ماه 
    //        d = Strings.Right(dateInput, 2);
    //        //جدا سازی 2 رقم عدد روز 
    //        //------------------------------------------------- 
    //        dateTemp = g.ToDateTime(Conversion.Val(y), Conversion.Val(m), Conversion.Val(d), 0, 0, 0, 0);
    //        dateTemp = g.AddYears(dateTemp, intYear);
    //        dateTemp = g.AddMonths(dateTemp, intMonth);
    //        dateTemp = g.AddDays(dateTemp, intDay);
    //        r = GetSolarDateString(dateTemp);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("بروز خطا هنگام محاسبه تاریخ _ " + ex.ToString());
    //        r = "نامشخص";
    //    }
    //    return r;
    //}

    public static int funAddToDateInteger(int dateInput, int intYear, int intMonth, int intDay)
    {
        dynamic str = dateInput.GetSolarDateintegerToStr();
        str = str.funAddToDateString(intYear, intMonth, intDay);
        return str.GetSolarDateStrTointeger();
    }

    //public static Dictionary<string, string> fnReturnMonth(string intStartDate, string intEndDate)
    //{
    //    Dictionary<string, string> dic = new Dictionary<string, string>();
    //    bool b = true;

    //    while (b)
    //    {
    //        dic.Add(ReturnFirstDayMonth(intStartDate), ReturnLastDayMonth(intStartDate));

    //        intStartDate = AddMonth(intStartDate, 1);

    //        if (intStartDate.ToInt32() > intEndDate.ToInt32())
    //        {
    //            dic.Add(ReturnFirstDayMonth(intStartDate), ReturnLastDayMonth(intStartDate));
    //            b = false;
    //        }

    //    }

    //    return dic;

    //}

    //public static string AddMonth(string Str, int Count)
    //{
    //    string Result = "";

    //    int Year = Strings.Mid(Str, 1, 4);
    //    int Month = Strings.Mid(Str, 5, 2);
    //    Month += Count;
    //    if (Month > 12)
    //    {
    //        Month = Month - 12;
    //        Year += 1;
    //    }

    //    if (Month < 10)
    //    {
    //        Result = Year.ToString() + "0" + Month.ToString() + Strings.Mid(Str, 7, 2);
    //    }
    //    else
    //    {
    //        Result = Year.ToString() + Month.ToString() + Strings.Mid(Str, 7, 2);
    //    }

    //    return Result;
    //}

    //public static string ReturnFirstDayMonth(string Str)
    //{
    //    string Result = "";

    //    string Year = Strings.Mid(Str, 1, 4);
    //    string Month = Strings.Mid(Str, 5, 2);

    //    Result = Year.ToString() + Month.ToString() + "01";

    //    return Result;
    //}

    //public static string ReturnLastDayMonth(string Str)
    //{
    //    string Result = "";

    //    string Year = Strings.Mid(Str, 1, 4);
    //    string Month = Strings.Mid(Str, 5, 2);

    //    Result = Year.ToString() + Month.ToString() + "31";

    //    return Result;
    //}

}
