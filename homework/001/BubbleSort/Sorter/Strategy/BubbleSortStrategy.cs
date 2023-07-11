// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BubbleSort.Sorter.Strategy
{
    internal sealed class BubbleSortStrategy<T> : AbstractSortStrategy<T> where T : IComparable<T>
    {
        public override List<T> Sort(IReadOnlyList<T> toSort)
        {
            var result = toSort.ToList();

            bool noSwapped = false;
            while (!noSwapped)
            {
                noSwapped = true;
                for (int i = 0; i < result.Count - 1; i++)
                {
                    if (result[i].CompareTo(result[i + 1]) > 0)
                    {
                        noSwapped = false;
                        result.Reverse(i, 2);
                    }
                }
            }

            return result;
        }
    }
}
