using System;

class MainClass {
  public static void Main (string[] args) {
  
    Console.WriteLine ("Input double number: ");
    var xvar = Console.ReadLine();
    double xdouble = Convert.ToDouble(xvar);
    
    Console.WriteLine ("result: "+Convert.ToInt32(xdouble));
  }
}
