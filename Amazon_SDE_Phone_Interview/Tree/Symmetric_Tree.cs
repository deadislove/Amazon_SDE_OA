using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    internal class Symmetric_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Symmetric tree");
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2, new TreeNode(3), new TreeNode(4));
            root.right = new TreeNode(2, new TreeNode(4), new TreeNode(3));
            bool Result = false;
            Result = IsSymmetric(root);
            Console.WriteLine("root = [1,2,2,3,4,4,3]");
            Console.WriteLine($"Result:{Result}");

            root = new TreeNode(1);
            root.left = new TreeNode(2, left: null, new TreeNode(3));
            root.right = new TreeNode(2, left: null, new TreeNode(3));
            Result = IsSymmetric(root);
            Console.WriteLine("root = [1,2,2,null,3,null,3]");
            Console.WriteLine($"Result: {Result}");
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
        ~Symmetric_Tree()
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

        private bool IsSymmetric(TreeNode root)
        {
            return isMirror(root, root);
        }

        private bool isMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return (t1.val == t2.val) &&
                isMirror(t1.right, t2.left) &&
                isMirror(t1.left, t2.right);
        }
    }
}
