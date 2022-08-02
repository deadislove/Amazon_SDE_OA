using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.Word_Ladder.Leetcode
{
    /**
     * Reference link: https://leetcode.com/problems/word-ladder/
     */
    internal class Word_Ladder_Leetcode : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Word Ladder");
            string beginWord = string.Empty;
            string endWord = string.Empty;
            IList<string> words = new List<string>();
            int Result = 0;

            beginWord = "hit";
            endWord = "cog";
            words.Add("hot");
            words.Add("dot");
            words.Add("dog");
            words.Add("lot");
            words.Add("log");
            words.Add("cog");
            Result = LadderLength(beginWord, endWord, words);
            Console.WriteLine($"beginWord = \"hit\", endWord = \"cog\", wordList = [\"hot\",\"dot\",\"dog\",\"lot\",\"log\",\"cog\"]");
            Console.WriteLine($"{Result}");

            words.Remove("cog");
            Result = LadderLength(beginWord, endWord, words);
            Console.WriteLine("beginWord = \"hit\", endWord = \"cog\", wordList = [\"hot\",\"dot\",\"dog\",\"lot\",\"log\"]");
            Console.WriteLine($"{Result}");

        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Word_Ladder_Leetcode()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int count = 1, countInLevel = 0;
            Queue<string> queue = new Queue<string>();
            string currentWord = string.Empty;
            HashSet<string> dictionary = new HashSet<string>(wordList);
            char[] temp = null;

            queue.Enqueue(beginWord);

            while (queue.Count != 0) { 
                currentWord = queue.Dequeue();

                if (currentWord.Equals(endWord))
                    return count;

                temp = currentWord.ToCharArray();

                for (int i = 0; i <= temp.Length - 1; i++) {
                    temp = currentWord.ToCharArray();

                    for (int j = 0; j < 26; j++) {
                        if (dictionary.Contains(new string(temp)))
                        {
                            queue.Enqueue(new string(temp));
                            dictionary.Remove(new string(temp));
                        }
                    }
                }

                count++;
            }

            return 0;
        }
    }
}
