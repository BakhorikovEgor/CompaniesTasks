using FlatFigures.Figures;

namespace FlatFigures.Tests;

public class FlatFiguresTests
{
    private const double Delta = 0.001;

    private static bool AreDoublesEqual(double first, double second)
        => Math.Abs(first - second) < Delta;


    public static IEnumerable<TestCaseData> CorrectDataForAreaCalculationsOfCircles ()
    {
        yield return new TestCaseData(new Circle(1), Math.PI);
        yield return new TestCaseData(new Circle(0), 0);
    }
    
    
    public static IEnumerable<TestCaseData> CorrectDataForAreaCalculationsOfTriangles ()
    {
        yield return new TestCaseData(new Triangle(3, 2, 2), 1.984);
        yield return new TestCaseData(new Triangle(3, 4, 5), 6);
    }
    
    
    [TestCaseSource(nameof(CorrectDataForAreaCalculationsOfCircles))]
    [TestCaseSource(nameof(CorrectDataForAreaCalculationsOfTriangles))]
    public void CalculateAreaWithCorrectData_ShouldReturnExpected(IFlatFigure figure, double expected)
        => Assert.That(AreDoublesEqual(figure.CalculateArea(), expected), Is.True);
}