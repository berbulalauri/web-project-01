using System;
class MainClass
{
    public static void Main(string[] args)
    {
      Console.WriteLine("input first number: ");
      var x = Console.ReadLine();
      double xint = Convert.ToDouble(x);
      Console.WriteLine("input second number: ");
      var y = Console.ReadLine();
      double yint = Convert.ToDouble(y);
      int xcheck;
      int ycheck;
      var xparsed = int.TryParse(x, out xcheck);
      var yparsed = int.TryParse(y, out ycheck);
      Console.WriteLine("Expected Output: ");
      if (xparsed && yparsed) {
        if(yint>xint) {
          for (double i=xint+1; i<yint; i++) {
          Console.WriteLine (i);
          }
        } else {
          Console.WriteLine ("range can't be calculated");
        }    
      }
      else
      {
          Console.WriteLine("not integer format");
      }
    }
}
