using Amazon_SDE_OA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_OA.Battle
{
    internal class Amazon_Battle1 : ISolution
    {
        public void Solution()
        {
            var Input = new List<int>() { 3, 1, 2 };
            var Output = imbalance(Input);
            Console.Write($"Ans:{Output}");
        }

        public long imbalance(List<int> rank) {

            //long totalImbalance = 0;

            //for (int groupSize = 2; groupSize <= rank.Count; groupSize++)
            //{
            //    for (int i = 0; i <= rank.Count - groupSize; i++)
            //    {
            //        var group = rank.GetRange(i, groupSize).OrderBy(r => r).ToList();
            //        for (int j = 0; j < group.Count - 1; j++)
            //        {
            //            if (group[j + 1] - group[j] > 1)
            //                totalImbalance++;
            //        }
            //    }
            //}
            //return totalImbalance;

            long imbalance = 0;
            int r = 0;
            HashSet<int> set = new();
            while (r < rank.Count - 1)
            {
                set.Clear();
                set.Add( rank[r]);
                long curImbalance = 0;
                for (int i = r + 1; i < rank.Count; i++)
                {
                    int e = rank[i];
                    set.Add( e);
                    var RangeListMax = set.Where(w => w < e);
                    var RangeListMin = set.Where(w => w > e);
                    int? f = RangeListMax is null || RangeListMax.Count().Equals(0)? null : RangeListMax.Max(x => x);
                    int? c = RangeListMin is null || RangeListMin.Count().Equals(0) ? null : RangeListMin.Min(x => x);

                    if (f == null)
                    { // added at beginning
                        curImbalance += (((c - e) > 1) ? 1 : 0);
                    }
                    else if (c == null)
                    {// added at end
                        curImbalance += (((e - f) > 1) ? 1 : 0);
                    }
                    else
                    {
                        curImbalance += (c - f) > 1 ? -1 : 0;
                        curImbalance += (((c - e) > 1) ? 1 : 0);
                        curImbalance += (((e - f) > 1) ? 1 : 0);
                    }
                    imbalance += curImbalance;
                }
                r++;
            }
            return imbalance;

        }

        #region Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
