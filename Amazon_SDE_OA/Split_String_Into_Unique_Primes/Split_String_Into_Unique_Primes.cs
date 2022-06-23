using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Split_String_Into_Unique_Primes
{
    internal class Split_String_Into_Unique_Primes :  ISolution
    {
        public void Solution() {
            Console.WriteLine("Split String Into Unique Primes");
            Console.WriteLine("Ans:");
            Console.WriteLine(findNumberOfWays("31173"));
        }

        HashSet<int> map = new HashSet<int>();

        public int findNumberOfWays(string input)
        {
            List<List<int>> ways = new List<List<int>>();
            List<int> results = new List<int>();
            findPermutations(input, results, ways);
            return ways.Count;
        }

        public void findPermutations(string suffix, List<int> results, List<List<int>> resultSet)
        {
            if (suffix.Length.Equals(0)) { 
                resultSet.Add(new List<int>(results));
                Console.WriteLine(string.Join(" ", results.ToArray()));
            }

            for (int i = 0; i < suffix.Length; i++) { 
                string snumber = suffix.Substring(0, i + 1);

                int numb = Int32.Parse(snumber);
                bool isPrime = isPrimeNumber(numb);

                if (isPrime) { 
                    results.Add(numb);
                    findPermutations(suffix.Substring(i + 1), results, resultSet);
                    results.RemoveAt(results.Count - 1);
                }
            }
        }

        public bool isPrimeNumber(int number) {
            if (map.Contains(number)) return true;

            bool isPrime = isPrime2(number);

            if (isPrime) map.Add(number);

            return isPrime;
        }

        public bool isPrime2(int n) {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i <= n / 2; i = i + 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        #region Dispose mechanism
        /// <summary>
        /// Dispose mechanism.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
