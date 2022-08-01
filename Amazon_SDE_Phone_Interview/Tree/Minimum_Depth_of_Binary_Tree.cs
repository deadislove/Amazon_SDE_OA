using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Description: Given a binary tree, find its minimum depth. 
     * The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
     * Reference link: https://leetcode.com/problems/minimum-depth-of-binary-tree/
     */
    internal class Minimum_Depth_of_Binary_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Minimum Depth of Binary Tree");
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20, new TreeNode(15), new TreeNode(7));
            int Result = MinDepth(root);
            Console.WriteLine("root = [3,9,20,null,null,15,7]");
            Console.WriteLine($"Result: {Result}");

            root = new TreeNode(2);
            root.left = null;
            root.right = new TreeNode(3, left: null, new TreeNode(4, left: null, new TreeNode(5, left: null, new TreeNode(6))));
            Result = MinDepth(root);
            Console.WriteLine("root = [2,null,3,null,4,null,5,null,6]");
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
        ~Minimum_Depth_of_Binary_Tree()
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

        private int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;

            if(root.left == null)
                return MinDepth(root.right) +1;
            if (root.right == null)
                return MinDepth(root.left) + 1;

            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
    }
}
