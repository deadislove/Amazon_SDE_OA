using Amazon_SDE_Phone_Interview.Interface;
using Amazon_SDE_Phone_Interview.Tree.Tree_Node;

namespace Amazon_SDE_Phone_Interview.Tree
{
    /**
     * Description: Given the root of a binary tree, return the level order traversal of its nodes' values. 
     * (i.e., from left to right, level by level).
     * 
     * Reference link: https://leetcode.com/problems/binary-tree-level-order-traversal/
     */
    internal class Binary_Tree_Level_Order_Traversal : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Binary Tree Level Order Traversal");
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var Result = LevelOrder(root);
            Console.WriteLine("root = [3,9,20,null,null,15,7]");
            string strResult = string.Empty;
            strResult = PrintResult(Result);
            Console.WriteLine($"Result: {strResult}");
            Console.WriteLine();

            root = new TreeNode(1);
            Result = LevelOrder(root);
            Console.WriteLine("root = [1]");
            strResult = PrintResult(Result);
            Console.WriteLine($"Result: {strResult}");

            root = new TreeNode();
            Result = LevelOrder(root);
            Console.WriteLine("root = []");
            strResult = PrintResult(Result);
            Console.WriteLine($"Result: {strResult}");
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
        ~Binary_Tree_Level_Order_Traversal()
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

        private string PrintResult(IList<IList<int>> ans)
        {
            string tmp = string.Empty;
            List<string> Result = new List<string>();

            foreach (var item in ans)
            {
                Result.Add(string.Format("[{0}]", string.Join(",", item)));
            }

            tmp = string.Format("[{0}]", string.Join(", ", Result));
            return tmp;
        }

        private IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if(root is null)
                return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var size = queue.Count;
                var oneResult = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    var cur = queue.Dequeue();
                    oneResult.Add(cur.val);

                    if (cur.left != null) { 
                        queue.Enqueue(cur.left);
                    }

                    if (cur.right != null) {
                        queue.Enqueue(cur.right);
                    }
                }

                result.Add(oneResult);
            }

            return result;
        }
    }
}
