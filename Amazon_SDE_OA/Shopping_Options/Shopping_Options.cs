using Amazon_SDE_OA.Interface;
using System.Collections;

namespace Amazon_SDE_OA.Shopping_Options
{
    internal class Shopping_Options : ISolution
    {
        public void Solution() {
            int Input = 4;
            List<ArrayList> result = print_all_sum(Input);
            print(result);
        }

        public static void print_all_sum_rec(
            int target,
            int current_sum,
            int start,
            List<ArrayList> output,
            ArrayList result
            ) {

            if (target.Equals(current_sum))
                output.Add((ArrayList)result.Clone());

            for (int i = start; i < target; i++) {
                int temp_num = current_sum + i;

                if (temp_num <= target)
                {
                    result.Add(i);
                    print_all_sum_rec(target, temp_num, i, output, result);
                    
                    result.RemoveAt(result.Count - 1);
                }
                else
                    return;
            }
        }

        static List<ArrayList> print_all_sum(int target) {
            List<ArrayList> output = new();
            ArrayList result = new();
            print_all_sum_rec(target, 0, 1, output, result);
            return output;
        }

        static void print(List<ArrayList> arr) {
            for (int i = 0; i < arr.Count(); i++) {
                Console.Write("[ ");

                for (int j = 0; j < arr[i].Count; j++)
                {
                    Console.Write(arr[i][j] + ", ");
                }

                Console.WriteLine("]");
            }
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
