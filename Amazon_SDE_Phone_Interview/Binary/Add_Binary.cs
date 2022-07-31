using Amazon_SDE_Phone_Interview.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_Phone_Interview.Binary
{
    internal class Add_Binary : ISolution
    {
        /**
         * Reference link: https://leetcode.com/problems/add-binary/
         */
        private bool disposedValue;

        public void Solution()
        {
            string a, b;
            a = string.Empty;
            b = string.Empty;

            Console.WriteLine("a = 11; b = 1");
            a = "11";
            b = "1";
            AddBinary(a, b);
            Console.WriteLine("a = 1010; b = 1011");
            a = "1010";
            b = "1011";
            AddBinary(a, b);
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
        ~Add_Binary()
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

        private string AddBinary(string a, string b)
        {
            char[] sum = new char[Math.Max(a.Length, b.Length) + 1];
            bool carry = false;

            if (b.Length > a.Length)
            {
                string c = a;
                a = b;
                b = c;
            }

            for (int i = a.Length - 1, j = b.Length - 1, k = sum.Length - 1;
                i >= 0; i--, j--, k--
                )
            {
                char numA = a[i];
                char numB = j >= 0 ? b[j] : '0';

                Console.WriteLine(numA + " " + numB);

                if (carry)
                {
                    sum[k] = numA == numB ? '1' : '0';
                    carry = numA == '1' || numB == '1';
                }
                else
                {
                    sum[k] = numA == numB ? '0' : '1';
                    carry = numA == '1' && numB == '1';
                }
            }

            if (carry)
            {
                sum[0] = '1';
                return new string(sum);
            }

            return new string(sum, 1, sum.Length - 1);
        }
    }
}
