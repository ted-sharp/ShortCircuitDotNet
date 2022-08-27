using ShortCircuit.Extensions;

namespace ShortCircuit.JaJp
{
    public static class DateTimeExtensionsToAge
    {
        /// <summary>
        /// ある日付で満年齢を計算します。
        /// </summary>
        public static int ToAgeOn(this DateTime birthDate, DateTime today)
        {
            var age = today.Year - birthDate.Year;
            if (today.Date < birthDate.Date.AddYears(age))
            {
                age--;
            }
            return age;
        }

        /// <summary>
        /// 今日で満年齢を計算します。
        /// </summary>
        public static int ToAge(this DateTime birthDate)
        {
            return birthDate.ToAgeOn(DateTime.Today);
        }

        /// <summary>
        /// ある日付で数え年を計算します。
        /// </summary>
        /// <remarks>
        /// 数え年は東アジア(中国、韓国、日本)で使われている。
        /// </remarks>
        public static int ToOrdinalAgeOn(this DateTime birthDate, DateTime today)
        {
            return today.Year - birthDate.Year + 1; ;
        }

        /// <summary>
        /// 今日で数え年を計算します。
        /// </summary>
        /// <remarks>
        /// 数え年は東アジア(中国、韓国、日本)で使われている。
        /// </remarks>
        public static int ToOrdinalAge(this DateTime birthDate)
        {
            return birthDate.ToOrdinalAgeOn(DateTime.Today);
        }

        /// <summary>
        /// 年度末年齢を計算します。
        /// 日本の場合は、次の3/31時点の年齢です。
        /// </summary>
        public static int ToFiscalYearAgeOn(this DateTime birthDate, DateTime today)
        {
            var baseDate = today.EndOfTerm(3, 31);
            return birthDate.ToAgeOn(baseDate);
        }
    }
}