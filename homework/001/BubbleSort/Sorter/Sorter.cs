// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BubbleSort.Sorter.Strategy;

namespace BubbleSort.Sorter
{
    internal sealed class Sorter<T> where T : IComparable<T>
    {
        public static readonly IReadOnlyDictionary<SortStrategyEnum, AbstractSortStrategy<T>> SortStrategies = new Dictionary<SortStrategyEnum, AbstractSortStrategy<T>>()
    {
        { SortStrategyEnum.BubbleSort, new BubbleSortStrategy<T>() }
    };

        public SortDirection Direction { get; set; }
        public AbstractSortStrategy<T> Strategy;
        public IReadOnlyList<T> Values { get; set; }

        public Sorter(IReadOnlyList<T> values,
            AbstractSortStrategy<T> sortStrategy,
            SortDirection sortDirection = SortDirection.Ascending)
        {
            Direction = sortDirection;
            Strategy = sortStrategy;
            Values = values;
        }

        public List<T> Sort()
        {
            var sorted = Strategy.Sort(Values);
            if (Direction == SortDirection.Descending)
            {
                sorted.Reverse();
            }
            return sorted;
        }
    }
}
