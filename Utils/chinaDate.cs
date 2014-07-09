using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Utils
{
    class chinaDate
    {
        public string cDate()
        {
            ChineseLunisolarCalendar l = new ChineseLunisolarCalendar();
            DateTime dt = DateTime.Today; //转换当日的日期
            //dt = new DateTime(2006, 1,29);//农历2006年大年初一（测试用），也可指定日期转换
            string[] aMonth = { "", "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "腊月", "腊月" };
            //a10表示日期的十位!
            string[] a10 = { "初", "十", "廿", "卅" };
            string[] aDigi = { "Ｏ", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            string sYear = "", sYearArab = "", sMonth = "", sDay = "", sDay10 = "", sDay1 = "", sLuniSolarDate = "";
            int iYear, iMonth, iDay;
            iYear = l.GetYear(dt);
            iMonth = l.GetMonth(dt);
            iDay = l.GetDayOfMonth(dt);

            //Format Year
            sYearArab = iYear.ToString();
            for (int i = 0; i < sYearArab.Length; i++)
            {
                sYear += aDigi[Convert.ToInt16(sYearArab.Substring(i, 1))];
            }

            //Format Month
            int iLeapMonth = l.GetLeapMonth(iYear); //获取闰月

            /**/
            /*闰月可以出现在一年的任何月份之后。例如，GetMonth 方法返回一个介于 1 到 13 之间的数字来表示与指定日期关联的月份。如果在一年的八月和九月之间有一个闰月，则 GetMonth 方法为八月返回 8，为闰八月返回 9，为九月返回 10。*/

            if (iLeapMonth > 0 && iMonth <= iLeapMonth)
            {
                //for (int i = iLeapMonth + 1; i < 13; i++) aMonth[i] = aMonth[i - 1];
                aMonth[iLeapMonth] = "闰" + aMonth[iLeapMonth - 1];
                sMonth = aMonth[l.GetMonth(dt)];
            }
            else if (iLeapMonth > 0 && iMonth > iLeapMonth)
            {
                sMonth = aMonth[l.GetMonth(dt) - 1];
            }
            else
            {
                sMonth = aMonth[l.GetMonth(dt)];
            }


            //Format Day
            sDay10 = a10[iDay / 10];
            sDay1 = aDigi[(iDay % 10)];
            sDay = sDay10 + sDay1;

            if (iDay == 10) sDay = "初十";
            if (iDay == 20) sDay = "二十";
            if (iDay == 30) sDay = "三十";

            //Format Lunar Date
            //sLuniSolarDate = dt.Year+"年"+dt.Month+"月"+dt.Day+"日 "+Weeks(dt.DayOfWeek.ToString())+" 农历" + sYear + "年" + sMonth + sDay;
            sLuniSolarDate = dt.Year + "年" + dt.Month + "月" + dt.Day + "日 " + Weeks(dt.DayOfWeek.ToString()) + " 农历" + sMonth + sDay;
            return sLuniSolarDate;

        }
        private string Weeks(string Weeken)
        {
            switch (Weeken)
            {
                case "Monday":
                    return "星期一";
                    break;
                case "Tuesday":
                    return "星期二";
                    break;
                case "Wednesday":
                    return "星期三";
                    break;
                case "Thursday":
                    return "星期四";
                    break;
                case "Friday":
                    return "星期五";
                    break;
                case "Saturday":
                    return "星期六";
                    break;
                case "Sunday":
                    return "星期日";
                    break;
                default:
                    return " ";
            }

        }
    }
}
