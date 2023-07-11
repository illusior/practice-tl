// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BubbleSort.Sorter.Strategy
{
    internal abstract class AbstractSortStrategy<T> where T : IComparable<T>
    {
        public abstract List<T> Sort(IReadOnlyList<T> toSort);
    }
}
