// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using DataType = int;

Console.WriteLine("Hello, World! My name is Baddas BubbleSort :)");

var sorter = new Sorter<DataType>(
    new List<DataType>() { -10, 1050, 0, 1, -1, 656, -9090 },
    Sorter<DataType>.SortStrategies.GetValueOrDefault(SortStrategyEnum.BubbleSort)!
);

Console.Write("Collection was: ");
var writer = new ReadOnlyCollectionWriter<DataType>(sorter.Values, Console.Out);
writer.WriteWithNewLine();

var sorted = sorter.Sort();

Console.Write("Collection now: ");
writer.Collection = sorted;
writer.WriteWithNewLine();

internal abstract class SortStrategy<T> where T : IComparable<T>
{
    public abstract List<T> Sort(IReadOnlyList<T> toSort);
}

internal sealed class BubbleSortStrategy<T> : SortStrategy<T> where T : IComparable<T>
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

internal enum SortDirection
{
    ASCENDING = 0,
    DESCENDING,
}

internal enum SortStrategyEnum
{
    BubbleSort = 0,
}

internal sealed class Sorter<T> where T : IComparable<T>
{
    public static readonly IReadOnlyDictionary<SortStrategyEnum, SortStrategy<T>> SortStrategies = new Dictionary<SortStrategyEnum, SortStrategy<T>>()
    {
        { SortStrategyEnum.BubbleSort, new BubbleSortStrategy<T>() }
    };

    public SortDirection Direction { get; set; }
    public SortStrategy<T> Strategy;
    public IReadOnlyList<T> Values { get; set; }

    public Sorter(IReadOnlyList<T> values,
        SortStrategy<T> sortStrategy,
        SortDirection sortDirection = SortDirection.ASCENDING)
    {
        Direction = sortDirection;
        Strategy = sortStrategy;
        Values = values;
    }

    public List<T> Sort()
    {
        var sorted = Strategy.Sort(Values);
        if (Direction == SortDirection.DESCENDING)
        {
            sorted.Reverse();
        }
        return sorted;
    }
}

internal sealed class ReadOnlyCollectionWriter<T>
{
    public IReadOnlyCollection<T> Collection { get; set; }
    public TextWriter TextWriter { get; set; }
    public char Delimeter { get; set; }
    public ReadOnlyCollectionWriter(IReadOnlyCollection<T> collection, TextWriter textWriter, char delimeter = ',')
    {
        Collection = collection;
        Delimeter = delimeter;
        TextWriter = textWriter;
    }

    public void Write()
    {
        if (Collection.Count == 0)
        {
            return;
        }

        foreach (var (value, i) in Collection.Select((value, i) => (value, i)))
        {
            if (value == null)
            {
                continue;
            }
            TextWriter.Write($"{value}{(i < Collection.Count - 1 ? $"{Delimeter} " : "")}");
        }
    }

    public void WriteWithNewLine()
    {
        Write();
        TextWriter.WriteLine();
    }
}
