namespace FlatFigures.Figures;

public record struct Circle : IFlatFigure
{
    public int Radius { get; }
    
    public Circle(int radius)
        => Radius = radius >= 0
            ? radius
            : throw new ArgumentException(" Radius can not be less than zero.");

    
    public double CalculateArea()
        => Math.PI * Radius * Radius;
}
