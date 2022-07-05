using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.RecursionAndRecursiveStrings
{
    internal class ReverseStringByRecursion : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Print reverse of a string using recursion");
            var Input = "Geeks of Geeks";
            ReversePrint(Input);

            var Output = RecursiveReverseByStack(Input.ToCharArray());
            Console.WriteLine("Reverse string by stack");
            Console.WriteLine(Output);
            Console.WriteLine("Reverse string by Iterative");
            Output = RecursiveReverseByIterative(Input);
            Console.WriteLine(Output);
            Console.WriteLine("Reverse string by Iterative using two pointers");
            Output = RecursiveReverseByIterativeUsingTwoPointers(Input);
            Console.WriteLine("Reverse string method 1");
            var tmp = Input.ToCharArray();
            RecursiveReverse1(tmp, 0);
            Output = String.Join("", tmp);
            Console.WriteLine(Output);
            Console.WriteLine("Reverse string method 2");
            Output = RecursiveReverse2(Input);
            Console.WriteLine(Output);            
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
        ~ReverseStringByRecursion()
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

        internal static void ReversePrint(string str)
        {
            if ((str == null) || (str.Length <= 1))
                Console.Write(str);

            else
            {
                Console.Write(str[str.Length - 1]);
                ReversePrint(str.Substring(0, (str.Length - 1)));
            }
        }

        /**
         * Time complexity : O(n) 
         * Auxiliary Space : O(n)
         */
        internal static string RecursiveReverseByStack(char[] str)
        {
            Stack<char> st = new Stack<char>();
            for(int i=0; i < str.Length;i++)
                st.Push(str[i]);

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = st.Peek();
                st.Pop();
            }

            return String.Join("", str);
        }

        #region RecursiveReverseByIterative
        /**
         * Time complexity : O(n) 
         * Auxiliary Space : O(1)
         */
        internal static string RecursiveReverseByIterative(string str)
        {
            int n = str.Length;

            // Swap character starting from two
            // corners
            for (int i = 0; i < n / 2; i++)
                str = swap(str, i, n - i - 1);
            return str;
        }

        private static string swap(string str, int i, int j)
        {
            char[] ch = str.ToCharArray();
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
            return string.Join("", ch);
        }
        #endregion

        /**
         * Time complexity : O(n) 
         * Auxiliary Space : O(1)
         */
        internal static string RecursiveReverseByIterativeUsingTwoPointers(string str)
        {
            int n = str.Length;
            char[] ch = str.ToCharArray();
            char temp;

            // Swap character starting from two corners
            for (int i = 0, j = n - 1; i < j; i++, j--)
            {
                temp = ch[i];
                ch[i] = ch[j];
                ch[j] = temp;
            }

            return String.Join("", ch);
        }

        /**
         * RecursiveReverse 1
         */
        internal static void RecursiveReverse1(char[] str, int i)
        {
            int n = str.Length;
            if (i == n / 2)
                return;
            swap(str, i, n - i - 1);
            RecursiveReverse1(str, i + 1);
        }

        internal static char[] swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return arr;
        }

        internal static string RecursiveReverse2(string str)
        {
            char[] temparray = str.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return String.Join("", temparray);
        }
    }
}
