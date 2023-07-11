// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BubbleSort.Writer
{
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
}
