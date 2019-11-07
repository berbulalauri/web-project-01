using System;
class MainClass
{
    public static void Main(string[] args)
    {
      var sa = new int[] { 0,0,0,0,0 };
      
      for (int i=0; i<5; i++){
        for (int j=0; j<=i; j++){
          if(j==i){ 
            sa[sa.Length-j-1] = 1;
            Console.WriteLine(sa[0]+" "+sa[1]+" "+sa[2]+" "+sa[3]+" "+sa[4]);
            sa[sa.Length-j-1] = 0;
          } else {
           sa[j] = 0;
           }
        }
      }
    }
}


