using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Reference link: https://leetcode.com/problems/invert-binary-tree/
     */
    internal class Invert_Binary_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Invert Binary Tree");
            TreeNode root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            var Result = InvertTree(root);
            Console.WriteLine("root = [2,1,3]");
            Console.WriteLine("Result: [2, 3, 1]");
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
        ~Invert_Binary_Tree()
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

        private TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode right = InvertTree(root.right);
            TreeNode left = InvertTree(root.left);
            root.left = right;
            root.right = left;

            return root;
        }
    }
}
