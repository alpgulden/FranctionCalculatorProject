using System;

namespace franctions_alpgulden
{

    partial class fractions_alpgulden
    {
        static void Main(string[] args)
        {
            try
            {

                // It is ideal to sprerate presentation with business logic
                long numerator1 = Presentation.ReadInput("numerator");
                long denominator1 = Presentation.ReadInput("denominator");
                long numerator2 = Presentation.ReadInput("numerator");
                long denominator2 = Presentation.ReadInput("denominator");


                //create fractions
                var fraction1 = new Fractions(numerator1, denominator1);
                var fraction2 = new Fractions(numerator2, denominator2);


                //Addition - Subtraction - Multiplication - Division - Equality / non - equality - Greater than / less than - Display
                Presentation.WriteOutput(fraction1,fraction2);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

    }
}
