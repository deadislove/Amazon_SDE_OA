using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Dscription: Given a binary tree, determine if it is height-balanced.
     * For this problem, a height-balanced binary tree is defined as:
     * a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
     * 
     * Reference link: https://leetcode.com/problems/balanced-binary-tree/
     * 
     */
    internal class Balanced_Binary_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Balanced Binary Tree");
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20, new TreeNode(15), new TreeNode(7));
            bool Result = false;
            Result = IsBalanced(root);
            Console.WriteLine("root = [3,9,20,null,null,15,7]");
            Console.WriteLine($"Result: {Result}");

            root = new TreeNode(1);
            root.left = new TreeNode(2, 
                new TreeNode(3, new TreeNode(4), new TreeNode(4)), 
                new TreeNode(3));
            root.right = new TreeNode(2);
            Result = IsBalanced(root);
            Console.WriteLine("root = [1,2,2,3,3,null,null,4,4]");
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
        ~Balanced_Binary_Tree()
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

        private bool IsBalanced(TreeNode root)
        {
            int lh; // for height of left subtree 

            int rh; // for height of right subtree 

            /* If tree is empty then return true */
            if (root == null)
            {
                return true;
            }

            /* Get the height of left and right sub trees */
            lh = height(root.left);
            rh = height(root.right);

            if (Math.Abs(lh - rh) <= 1 && IsBalanced(root.left)
                && IsBalanced(root.right))
            {
                return true;
            }

            /* If we reach here then tree is not height-balanced */
            return false;
        }

        /* UTILITY FUNCTIONS TO TEST isBalanced() FUNCTION */
        /* The function Compute the "height" of a tree. Height is the  
            number of nodes along the longest path from the root node  
            down to the farthest leaf node.*/
        public virtual int height(TreeNode node)
        {
            /* base case tree is empty */
            if (node == null)
            {
                return 0;
            }

            /* If tree is not empty then height = 1 + max of left  
            height and right heights */
            return 1 + Math.Max(height(node.left), height(node.right));
        }
    }
}
