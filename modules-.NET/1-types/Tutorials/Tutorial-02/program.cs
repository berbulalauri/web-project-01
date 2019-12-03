using System;

namespace firstDotnetApp
{
public class program
{
public static void Main(string[] arg)
 {
 DateTime currentdate = DateTime.Now;
  string currentdatestring = currentdate.ToString("dddd, dd MMMM yyyy");
  string seconddatestring = currentdate.ToString("dddd, yyyy");
  Console.WriteLine(currentdatestring);
 Console.WriteLine(seconddatestring); //{currentdatestring.Now.Year}

}
}
}



