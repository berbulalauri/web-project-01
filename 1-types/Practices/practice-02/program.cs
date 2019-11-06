using System;

class MainClass {
  public static void Main (string[] args) {
  
    Console.WriteLine ("Input first number: ");
    var xvar = Console.ReadLine();
    double xdouble = Convert.ToDouble(xvar);
    Console.WriteLine ("Input second number: ");
    var yvar = Console.ReadLine();
    double ydouble = Convert.ToDouble(yvar);

    Console.WriteLine ("result {0} is greater than 10 is: {1}",(xdouble*ydouble),((xdouble*ydouble)>10));
  }
}
