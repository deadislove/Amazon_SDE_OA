using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.LRU_Cache.Leetcode
{
    /**
     * Reference link: https://leetcode.com/problems/lru-cache/
     */
    internal class LRU_Cache_Leetcode : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("LRU Cache - Leetcode");
            int Result = 0;
            List<int?> ResultList = new List<int?>();
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            ResultList.Add(null);
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            ResultList.Add(null);
            Result = lRUCache.Get(1);    // return 1
            ResultList.Add(Result);
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            ResultList.Add(null);
            Result = lRUCache.Get(2);    // returns -1 (not found)
            ResultList.Add(Result);
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            ResultList.Add(null);
            Result = lRUCache.Get(1);    // return -1 (not found)
            ResultList.Add(Result);
            Result = lRUCache.Get(3);    // return 3
            ResultList.Add(Result);
            Result = lRUCache.Get(4);    // return 4

            Console.WriteLine(string.Format("[{0}]", string.Join(",", ResultList)));
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
        ~LRU_Cache_Leetcode()
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
    }

    internal class LRUCache { 
        private int capacity = 0;
        private LinkedList<int[]> list = new LinkedList<int[]>();
        private Dictionary<int, LinkedListNode<int[]>> dict = new Dictionary<int, LinkedListNode<int[]>>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        private void Reorder(LinkedListNode<int[]> node) {
            if (node.Next != null) list.Remove(node);
            if (list.Last != node) list.AddLast(node);
        }

        public int Get(int key) {
            if (!dict.ContainsKey(key)) return -1;

            Reorder(dict[key]);

            return dict[key].Value[1];

        }

        public void Put(int key, int value) {
            if (dict.ContainsKey(key))
                dict[key].Value[1] = value;
            else {
                if (dict.Count.Equals(capacity)) {
                    _ = dict.Remove(list.First.Value[0]);
                    list.RemoveFirst();
                }
                dict.Add(key, new LinkedListNode<int[]>(new int[] { key, value }));
            }

            Reorder(dict[key]);
        }
    }
}
