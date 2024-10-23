using System.Globalization;

namespace MyWalletUI.Helper
{
    public static class TimeHelper
    {
        public static List<DateTime> GetMonthYearList()
        {
            var monthYearList = new List<DateTime>();

            for (int year = 2024; year <= 2026; year++)
            {

                for (int month = 1; month < 13; month++)
                {
                    monthYearList.Add(new DateTime(year, month, 1));
                }
            }

            return monthYearList;
        }
    }
}
