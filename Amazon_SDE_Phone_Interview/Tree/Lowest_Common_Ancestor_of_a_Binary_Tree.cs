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
     * Reference link: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/submissions/
     */
    internal class Lowest_Common_Ancestor_of_a_Binary_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Lowest Common Ancestor of a Binary Tree");
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
        ~Lowest_Common_Ancestor_of_a_Binary_Tree()
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
            if (root == p || root == q || root == null)
                return root;

            TreeNode l = LowestCommonAncestor(root.left, p, q),
                     r = LowestCommonAncestor(root.right, p, q);

            //return l != null && r != null ? root : l == null ? r : l;
            return l != null && r != null ? root : l ?? r;
        }
    }
}
