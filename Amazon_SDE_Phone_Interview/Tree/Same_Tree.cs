using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Reference link: https://leetcode.com/problems/same-tree/
     */
    internal class Same_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {

            Console.WriteLine("Is Same Tree - Problem");

            bool Result = false;

            TreeNode p = new TreeNode(1);
            p.left = new TreeNode(2);
            p.right = new TreeNode(3);
            TreeNode q = new TreeNode(1);
            q.left = new TreeNode(2);
            q.right = new TreeNode(3);
            Result = IsSameTree(p, q);
            Console.WriteLine($"Result:{Result}");
            Console.WriteLine();
            p = new TreeNode(1);
            p.left = new TreeNode(2);
            q = new TreeNode(1);
            q.right = new TreeNode(2);
            Result = IsSameTree(p, q);
            Console.WriteLine($"Result:{Result}");
        }

        #region DIspose
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
        ~Same_Tree()
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

        private bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null || q == null)
                return false;

            if (p.val == q.val)
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            else
                return false;
        }
    }
}
