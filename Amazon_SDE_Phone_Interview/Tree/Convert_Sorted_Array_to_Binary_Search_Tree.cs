using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;
using System.Text;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Description: Given an integer array nums where the elements are sorted in ascending order, 
     * convert it to a height-balanced binary search tree. 
     * 
     * A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.
     * 
     * Reference link: https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
     */
    internal class Convert_Sorted_Array_to_Binary_Search_Tree : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Convert Sorted Array to Binary Search Tree");
            int[] nums = new int[] { -10, -3, 0, 5, 9 };
            var Result = SortedArrayToBST(nums);
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
        ~Convert_Sorted_Array_to_Binary_Search_Tree()
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

        /// <summary>
        /// Print TreeNode result(array format)
        /// </summary>
        /// <param name="ans"></param>
        private void PrintResult(TreeNode ans)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");

            while (ans != null)
            {
                if (ans.left != null)
                {
                    result.Append(ans.left.val.ToString());                    
                }

                if (ans.right != null)
                {
                    result.Append(ans.right.ToString());
                }

                
            }
        }

        private TreeNode SortedArrayToBST(int[] nums)
        {
            return sortArrayToBST(nums, 0, nums.Length - 1);
        }

        public virtual TreeNode sortArrayToBST(int[] arr, int start, int end)
        {
            /* Base Case */
            if (start > end)
            {
                return null;
            }

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(arr[mid]);

            /* Recursively construct the left subtree and make it  
             left child of root */
            node.left = sortArrayToBST(arr, start, mid - 1);

            /* Recursively construct the right subtree and make it  
             right child of root */
            node.right = sortArrayToBST(arr, mid + 1, end);

            return node;
        }
    }
}
