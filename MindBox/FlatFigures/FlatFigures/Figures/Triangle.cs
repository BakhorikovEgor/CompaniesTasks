namespace FlatFigures.Figures;

public record struct Triangle : IFlatFigure
{
    public int FirstSide { get; }
    public int SecondSide { get; }
    public int ThirdSide { get; }

    private double? _area;

    public Triangle(int firstSide, int secondSide, int thirdSide)
        => (FirstSide, SecondSide, ThirdSide) = firstSide >= 0 && secondSide >= 0 && thirdSide >= 0
                                                && IsTriangle(firstSide, secondSide, thirdSide)
            ? (firstSide, secondSide, thirdSide)
            : throw new ArgumentException("The values of the sides do not specify a triangle");


    public double CalculateArea()
    {
        if (_area.HasValue)
        {
            return _area.Value;
        }

        var p = (FirstSide + SecondSide + ThirdSide) / 2.0;
        _area = Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));

        return _area.Value;
    }

    public bool IsRectangular()
        => FirstSide * FirstSide == SecondSide * SecondSide + ThirdSide * ThirdSide ||
           SecondSide * SecondSide == FirstSide * FirstSide + ThirdSide * ThirdSide ||
           ThirdSide * ThirdSide == SecondSide * SecondSide + FirstSide * FirstSide;


    private static bool IsTriangle(int firstSide, int secondSide, int thirdSide)
        => firstSide + secondSide > thirdSide &&
           secondSide + thirdSide > firstSide &&
           thirdSide + firstSide > secondSide;
}