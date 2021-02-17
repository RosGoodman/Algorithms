
namespace Task_2
{
    class Program
    {
        /// O(1 + N*N*N + 1)
        /// O(2 + N^3)
        /// В соответствии с правилом 3 методички сокращаем:
        /// O(N^3)

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;    //O(1)
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }
            return sum;     //O(1)
        }
    }
}
