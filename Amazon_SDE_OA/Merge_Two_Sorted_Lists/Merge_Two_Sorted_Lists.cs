using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Merge_Two_Sorted_Lists
{
    internal class Merge_Two_Sorted_Lists : ISolution
    {
        public void Solution() {
            Console.WriteLine("Merge Two Sorted Lists");

            Console.WriteLine("Only solution source code.");
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode listNode = new ListNode(0);
            ListNode tail = listNode;

            while (true)
            {
                if (l1 == null)
                {
                    tail.next = l2;
                    break;
                }

                if (l2 == null)
                {
                    tail.next = l1;
                    break;
                }

                if (l1.val <= l2.val)
                {
                    tail.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tail.next = l2;
                    l2 = l2.next;
                }

                tail = tail.next;
            }

            return listNode.next;
        }

        #region Dispose mechanism
        /// <summary>
        /// Dispose mechanism.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
