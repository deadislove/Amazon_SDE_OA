using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Top_K_Frequent_Words
{
    internal class Top_K_Frequent_Words : ISolution
    {
        public void Solution() {
            Console.WriteLine("Top K Frequent Words");
            var Input = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            var Input1 = 2;
            var Output = TopKFrequent(Input, Input1);
            Console.WriteLine("Example 1");
            Console.WriteLine($"Ans:{string.Join(" ", Output)}");
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            // Count of Frequency of each word 
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!dict.ContainsKey(words[i]))
                    dict.Add(words[i], 1);
                else
                    dict[words[i]]++;

            }
            // dictionary in C# has inbuilt method for sorting both key and value 
            // Sort first by frequency and then by key in case of tie like same frequency 
            List<KeyValuePair<string, int>> test =
               dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).ToList();

            //  return top k keys from dict  
            return test.Select(x => x.Key).ToList();
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
