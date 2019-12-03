using System;

class MainClass {
  public static void Main (string[] args) {
  
    Console.WriteLine ("write first line: ");
    var xvar = Console.ReadLine();
    double xdouble = Convert.ToDouble(xvar);
    Console.WriteLine ("write second line: ");
    var yvar = Console.ReadLine();
    double ydouble = Convert.ToDouble(yvar);

    Console.WriteLine ("numbers {0} and {1} are equal: {2} ", xdouble, ydouble, (xdouble == ydouble));
  }
}
