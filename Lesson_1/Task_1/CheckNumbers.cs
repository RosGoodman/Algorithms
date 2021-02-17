
namespace Task_1
{
    public static class CheckNumbers
    {
        /// <summary>Проверка, является ли число простым.</summary>
        /// <param name="n">Проверяемое число.</param>
        /// <returns>True/False - простое/не простое</returns>
        public static bool SimpleNumb(int number)
        {
            int d = 0;
            int i = 2;

            if (number < 0) return false;   //простые числа - натуральные больше 0.

            while (i < number)
            {
                if (number % i == 0) d++;

                i++;
            }

            if (d == 0)
                return true;
            else
                return false;
        }
    }
}
