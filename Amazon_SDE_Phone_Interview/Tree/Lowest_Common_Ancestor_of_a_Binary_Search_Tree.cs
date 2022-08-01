using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Reference link: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
     */
    internal class Lowest_Common_Ancestor_of_a_Binary_Search_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Lowest Common Ancestor of a Binary Search Tree");            
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
        ~Lowest_Common_Ancestor_of_a_Binary_Search_Tree()
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

        private TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root is null) return root;

            while (root != null)
            {
                if (root.val == q.val || root.val == p.val)
                    return root;
                // both nodes on the right side
                else if (root.val < p.val && root.val < q.val)
                    root = root.right;
                // both nodes are on left side
                else if (root.val > p.val && root.val > q.val)
                    root = root.left;
                else if ((root.val > p.val && root.val < q.val) || (root.val > q.val && root.val < p.val))
                    return root;
            }

            return root;
        }
    }
}
