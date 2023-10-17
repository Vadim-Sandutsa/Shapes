namespace Shapes.Tests;

public class TriangleTest
{
    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    [TestCase(1, 1, -1)]
    [TestCase(0, 0, 0)]
    public void InitTriangleWithErrorTest(double a, double b, double c)
    {
        Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Test]
    public void InitTriangleTest()
    {
        double a = 3d, b = 4d, c = 5d;
        
        var triangle = new Triangle(a, b, c);
        
        Assert.NotNull(triangle);
        Assert.Less(Math.Abs(triangle.EdgeA - a), Constants.CalculationAccuracy);
        Assert.Less(Math.Abs(triangle.EdgeB - b), Constants.CalculationAccuracy);
        Assert.Less(Math.Abs(triangle.EdgeC - c), Constants.CalculationAccuracy);
    }

    [Test]
    public void GetSquareTest()
    {
        double a = 4d, b = 5d, c = 3d;
        double result = 6d;
        var triangle = new Triangle(a, b, c);
        
        var square = triangle?.GetSquare();
        
        Assert.NotNull(square);
        Assert.Less(Math.Abs(square.Value - result), Constants.CalculationAccuracy);
    }

    [Test]
    public void InitNotTriangleTest()
    {
        Assert.Catch<ArgumentException>(() => new Triangle(1, 1, 4));
    }

    [TestCase(3, 4, 4, ExpectedResult = false)]
    [TestCase(3, 4, 4 + 2e-7, ExpectedResult = false)]
    [TestCase(3, 4, 5, ExpectedResult = true)]
    [TestCase(3, 4, 5.000000002, ExpectedResult = true)]
    public bool NotRightTriangle(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        
        var isRight = triangle.IsRightTriangle;
        
        return isRight;
    }
}