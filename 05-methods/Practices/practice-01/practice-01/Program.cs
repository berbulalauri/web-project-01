using System;

public class MainClass
{
    public static double bmiCounterMethod(double weight,double height)
    {
        return Math.Round(weight / Math.Pow(height, 2), 2, MidpointRounding.ToEven);
         
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Input your name: ");
        var nameInput = Console.ReadLine();

        Console.WriteLine("Input weight (kg): ");
        var weigthInput = Console.ReadLine();
        double.TryParse(weigthInput, out double wiout);
        Console.WriteLine("Input height (m): ");
        var heigthInput = Console.ReadLine();
        double.TryParse(heigthInput, out double hiout);

        double bmiMain = bmiCounterMethod(wiout,hiout);

        Console.WriteLine("{0}, your BMI = {1}", nameInput, bmiMain);

        if (bmiMain <= 18.5)
        {
            Console.WriteLine("BMI category: Underweight ");
        }
        else if (18.5 < bmiMain && bmiMain < 24.9)
        {
            Console.WriteLine("BMI category: Normal weight ");
        }
        else if (25 < bmiMain && bmiMain < 29.9)
        {
            Console.WriteLine("BMI category: Overweight ");
        }
        else { Console.WriteLine("BMI category: Obesity "); }

     
    }
}

