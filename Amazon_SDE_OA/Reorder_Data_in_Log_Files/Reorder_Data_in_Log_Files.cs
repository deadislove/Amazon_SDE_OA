﻿using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Reorder_Data_in_Log_Files
{
    internal class Reorder_Data_in_Log_Files : ISolution
    {
        public void Solution() {

            Console.WriteLine("Reorder Data in Log Files");
            var Input = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };

            var Output = ReorderLogFiles(Input);
            Console.WriteLine("Example 1");            
            Console.WriteLine($"Ans: {string.Join("", Output)}");
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            var separator = new[] { ' ' };
            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            for (int i = 0; i < logs.Length; i++)
            {
                var words = logs[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                bool letter = words[1].ToCharArray().All(c => c >= 'a' && c <= 'z');
                if (letter)
                {
                    letterLogs.Add(logs[i]);
                }
                else
                {
                    digitLogs.Add(logs[i]);
                }
            }

            IList<string> res = new List<string>();

            letterLogs.Sort((l1, l2) =>
            {
                var words1 = l1.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var words2 = l2.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                var cmp = string.CompareOrdinal(string.Join(" ", words1.Skip(1).ToArray()), string.Join(" ", words2.Skip(1).ToArray()));
                if (cmp != 0)
                {
                    return cmp;
                }

                return string.CompareOrdinal(words1[0], words2[0]);
            });

            foreach (var letterLog in letterLogs)
            {
                res.Add(letterLog);
            }

            foreach (var digitLog in digitLogs)
            {
                res.Add(digitLog);
            }

            return res.ToArray();
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
