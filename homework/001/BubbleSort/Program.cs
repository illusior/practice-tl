// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

Console.WriteLine("Hello, World! My name is Badass BubbleSort :)");
Console.WriteLine();

// Set up sorter
Sorter<DataType> sorter = new(
    new List<DataType>() { -10, 1050, 0, 1, -1, 656, -9090 },
    Sorter<DataType>.SortStrategies.GetValueOrDefault(SortStrategyEnum.BubbleSort)!
);

// Ask user for sort direction
SortDirection direction = SortDirection.Unknown;
do
{
    Console.Write(@"Please, choose sort direction (1 or 2):
    1 - ascending
    2 - descending
    ");
    Console.WriteLine();

    string userInput = Console.ReadLine() ?? "-1";
    int res;
    if (!int.TryParse(userInput, out res) || !Enum.IsDefined(typeof(SortDirection), res))
    {
        continue;
    }

    direction = (SortDirection)res;
} while (direction == SortDirection.Unknown);

// Print before sort
Console.Write("Collection was: ");
TextWriter output = Console.Out;
ReadOnlyCollectionWriter<DataType> writer = new(sorter.Values, output);
writer.WriteWithNewLine();

// Sort
sorter.Direction = direction;
List<int> sorted = sorter.Sort();

// Print after sort
Console.Write("Collection now: ");
writer.Collection = sorted;
writer.WriteWithNewLine();
