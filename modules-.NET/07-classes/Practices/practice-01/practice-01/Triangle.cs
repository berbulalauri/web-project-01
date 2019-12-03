using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tutorial_01
{
    public class Triangle
    {
        public double Perimeter { get; set; }
        public bool IsIsosceles { get; set; }
        public double firstSide { get; set; }
        public double secondSide { get; set; }
        public double thirdSide { get; set; }

        public Triangle(double FirstSide, double SecondSide, double ThirdSide)
        {
            this.firstSide = FirstSide;
            this.secondSide = SecondSide;
            this.thirdSide = ThirdSide;

            this.Perimeter = FirstSide + SecondSide + ThirdSide;
            if (FirstSide == SecondSide && FirstSide == ThirdSide && SecondSide == ThirdSide) { IsIsosceles = true; } else { IsIsosceles = false; };

        }
        public string PrintOutTransaction()
        {
            string result = $"Triangle {Environment.NewLine}";
            result += $"A: {firstSide}{Environment.NewLine}";
            result += $"B: {secondSide}{Environment.NewLine}";
            result += $"C: {thirdSide}{Environment.NewLine}";
            result += $"Perimeter: {Perimeter}{Environment.NewLine}";
            result += $"IsIsosceles: {IsIsosceles}{Environment.NewLine}";
            return result;
        }

    }
}
