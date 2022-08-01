using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Reference link: https://leetcode.com/problems/maximum-depth-of-binary-tree/
     */
    internal class Maximum_Depth_of_Binary_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Maximum Depth of Binary Tree");
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20, new TreeNode(15), new TreeNode(7));
            int MaxDeepthNumber = MaxDepth(root);
            Console.WriteLine("root = [3,9,20,null,null,15,7]");
            Console.WriteLine($"Result: {MaxDeepthNumber}");

            root = new TreeNode(1, left: null, new TreeNode(2));
            MaxDeepthNumber = MaxDepth(root);
            Console.WriteLine("root = [1,null,2]");
            Console.WriteLine($"Result: {MaxDeepthNumber}");
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
        ~Maximum_Depth_of_Binary_Tree()
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

        private int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int lDepth = MaxDepth(root.left);
                int rDepth = MaxDepth(root.right);

                if (lDepth > rDepth)
                    return lDepth + 1;
                else
                    return rDepth + 1;
            }
        }
    }
}
