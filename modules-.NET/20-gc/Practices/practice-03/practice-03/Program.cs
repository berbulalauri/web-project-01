using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public class Resources : IDisposable
{
    private Component component;
   public Resources(int x)
   {
        component = new Component();
        Console.WriteLine($"Resource {x} was created\n");
   }
   ~Resources()
   {
        Console.Error.WriteLine("Object finalization.");
        Dispose(false);
   }
    public void Dispose()
   {
        Dispose(true);
        //Blocking to run finalizer!
        GC.SuppressFinalize(this); 
   }

   private void Dispose(bool disposing)
   {
         if (disposing) {
            Console.Error.WriteLine("Dispose managed resources.");
            if (component != null) { Console.WriteLine("Disposing!\n"); component.Dispose(); }
        }
         string output = "Resource 2 was created.";
         Console.WriteLine(output);
   }
}

public class Example
{
   public static void Main()
   {
      Resources mydispose = new Resources(1);
      mydispose.Dispose();
   }
}