using System;

namespace Shapes
{
    public class Triangle : ITriangle
    {
        private readonly Lazy<bool> _isRightTriangle;
        
        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA < Constants.CalculationAccuracy)
                throw new ArgumentException(Constants.ErrorSideMessage, nameof(edgeA));

            if (edgeB < Constants.CalculationAccuracy)
                throw new ArgumentException(Constants.ErrorSideMessage, nameof(edgeB));

            if (edgeC < Constants.CalculationAccuracy)
                throw new ArgumentException(Constants.ErrorSideMessage, nameof(edgeC));

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if ((perimeter - maxEdge) - maxEdge < Constants.CalculationAccuracy)
                throw new ArgumentException(Constants.HypotenuseMustBeSmallerMessage);

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;

            _isRightTriangle = new Lazy<bool>(IsThisRightAngleTriangle);
        }

        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }
        public bool IsRightTriangle => _isRightTriangle.Value;

        private bool IsThisRightAngleTriangle()
        {
            double maxEdge = EdgeA, b = EdgeB, c = EdgeC;
            if (b - maxEdge > Constants.CalculationAccuracy)
                Utils.Swap(ref maxEdge, ref b);

            if (c - maxEdge > Constants.CalculationAccuracy)
                Utils.Swap(ref maxEdge, ref c);

            return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
        }

        public double GetSquare()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2d;
            var square = Math.Sqrt(
                halfP
                * (halfP - EdgeA)
                * (halfP - EdgeB)
                * (halfP - EdgeC)
            );

            return square;
        }
    }
}