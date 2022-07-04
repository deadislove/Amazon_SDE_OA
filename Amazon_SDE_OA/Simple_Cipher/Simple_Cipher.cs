using Amazon_SDE_OA.Interface;

namespace Amazon_SDE_OA.Simple_Cipher
{
    internal class Simple_Cipher : ISolution
    {
        public void Solution() {
            Console.WriteLine("Simple Chiper");
            var Input = "VTAOG";
            var Output = simpleChiper(Input, 2);
            Console.WriteLine("Example 1");
            Console.WriteLine($"Ans: {Output}");
        }

        public static string simpleChiper(string encrypted, int k)
        {
            char[] _encrpted = encrypted.ToCharArray();

            for (int i = 0; i < encrypted.Length; i++)
            {
                char x = _encrpted[i];
                // if the previous kth element is greater than 'A'
                if ((x - k) >= 65)
                    _encrpted[i] = (char)(x - k);
                else
                    _encrpted[i] = (char)(x - k + 26);
            }

            return new string(_encrpted);
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
}
