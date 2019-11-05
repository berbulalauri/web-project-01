using System;

namespace firstDotnetApp 
{
public class program 
{
public static void Main(string[] arg)
 {
	Console.WriteLine("enter first number : ");
	var firstinput = Console.ReadLine();
	double firstdouble = Convert.ToDouble(firstinput);
	Console.WriteLine("enter second number : ");
	var secondinput = Console.ReadLine();
	double seconddouble = Convert.ToDouble(secondinput);
	var sum = firstdouble + seconddouble;
	var isEven = (sum % 2) == 0; 
	Console.WriteLine("result : {0}" ,sum);
	Console.WriteLine("result is even number: {0}", isEven );	
 }
}
}


