using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.LRU_Cache.Geeksforgeeks
{
    /**
     * Reference link: https://www.geeksforgeeks.org/lru-cache-implementation/
     */
    internal class LRU_Cache_Geeksforgeeks : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("LRU Cache - Geeksforgeeks");
            LRUCache cache = new LRUCache(4);
            cache.refer(1);
            cache.refer(2);
            cache.refer(3);
            cache.refer(1);
            cache.refer(4);
            cache.refer(5);

            cache.Display();
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
        ~LRU_Cache_Geeksforgeeks()
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

        internal class LRUCache {
            private int capacity = 0;
            private LinkedList<int> list = new LinkedList<int>();
            private HashSet<int> hashSet = new HashSet<int>();

            public LRUCache(int capacity) 
            {
                this.capacity = capacity;
            }

            public void refer(int page)
            {
                if (!hashSet.Contains(page))
                {
                    if (list.Count == capacity) {
                        
                        list.RemoveLast();
                        hashSet.Remove(page);
                    }
                }
                else
                {
                    list.Remove(page);
                }

                list.AddFirst(page);
                hashSet.Add(page);
            }

            public void Display() {
                List<int> Result = list.ToList();
                foreach (var item in Result)
                {
                    Console.Write(item.ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
