namespace ShortCircuit.JaJp
{
    public static class DateTimeExtensionsToAge
    {
        /// <summary>
        /// ある日付で年齢を計算します。
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
        /// 今日で年齢を計算します。
        /// </summary>
        public static int ToAge(this DateTime birthDate)
        {
            return birthDate.ToAgeOn(DateTime.Today);
        }

        /// <summary>
        /// 年度年齢を計算します。
        /// </summary>
        /// <example>
        /// birthDate: 1990/11/1, today: 2000/10/1 → 9歳
        /// birthDate: 1990/11/1, today: 2000/10/1, baseDate: 2000/4/1 → 10歳
        /// </example>
        public static int ToYearAgeOn(this DateTime birthDate, DateTime today, DateTime baseDate)
        {
            throw new NotImplementedException();
        }
    }
}