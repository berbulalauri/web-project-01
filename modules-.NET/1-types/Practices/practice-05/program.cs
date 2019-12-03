using System;

class MainClass {
  public static void Main (string[] args) {
  
    Console.WriteLine ("input string: ");
    var x = Console.ReadLine();
    char[] xnew = x.ToCharArray();
  	Console.WriteLine("new String: "+xnew[0] + xnew[1] + xnew[2] + xnew[3] );
  }
}
