using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Description: Given an n-ary tree, return the level order traversal of its nodes' values.
     * Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).
     * 
     * Reference link: https://leetcode.com/problems/n-ary-tree-level-order-traversal/
     */
    internal class N_ary_Tree_Level_Order_Traversal : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("N-ary Tree Level Order Traversal");
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
        // ~N_ary_Tree_Level_Order_Traversal()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public IList<IList<int>> LevelOrder(Node root)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> temp = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    temp.Add(curr.val);

                    foreach (var child in curr.children)
                        queue.Enqueue(child);
                }
                res.Add(temp);
            }

            return res;

        }
    }
}
