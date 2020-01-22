using System;

namespace franctions_alpgulden
{
  
    //Utility function are very usefull when we have big scale applications.
    // Static functions used to call utulity functions without generating the instance.(Singleton).
    public class Utility
    { 
        //finding the greatest common fraction
        public static long GCF(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            StatusIndicator();

            if (b == 0)
                return a;
            return GCF(b, a % b);

        }

        private static void StatusIndicator()
        {
            Console.Write("/");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("-");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(@"\");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("|");
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        //function fpr simplifing the fraction
        public static long Division(long a, long b)
        {
            if (b > 0)
                a = a / b;
            
            return (a);
        }
    }

    

}
