using shapes.Shapes;

Triangle trriangle = new(new Point(2, 4), new Point(3, -6), new Point(7, 8));
Square square = new(new Point(0, 0), 10);
Circle circle = new(new Point(0, 0), 500);

List<IShape> shapes = new()
{
    trriangle,
    square,
    circle,
};

foreach (IShape item in shapes)
{
    Console.WriteLine($"{item.ToString()!.Split('.').Last()}'s area: {item.GetArea()}");
    Console.WriteLine($"{item.ToString()!.Split('.').Last()}'s perimeter: {item.GetPerimeter()}");
    Console.WriteLine();
}
