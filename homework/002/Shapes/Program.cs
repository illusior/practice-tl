// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using shapes.Shapes;

Triangle tr = new(new Point(2, 4), new Point(3, -6), new Point(7, 8));
Square sq = new(new Point(0, 0), 10);
Circle cr = new(new Point(0, 0), 500);

List<IShape> shapes = new List<IShape>()
{
    tr,
    sq,
    cr,
};

foreach (var item in shapes)
{
    Console.WriteLine($"{item.ToString()!.Split('.').Last()}'s area: {item.GetArea()}");
    Console.WriteLine($"{item.ToString()!.Split('.').Last()}'s perimeter: {item.GetPerimeter()}");
    Console.WriteLine();
}
