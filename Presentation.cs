using System;

namespace franctions_alpgulden
{

    public class Presentation
    {


        public static long ReadInput(string inputType)
        {
            try
            {
                // asking input until we get the valid input
                Console.WriteLine($"Please enter the {inputType} :");
                string input;
                do
                {
                    input = Console.ReadLine();
                }
                while (!ValidateInput(input, inputType));

                return Convert.ToInt64(input);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


        }

        // normally we should have presentation utilituy functions in different class.
        //also we could have a better error handling to show messages in one sigle class.
        public static bool ValidateInput(string input, string inputType)
        {
            bool valid = false;

            // validating 3 conditions. null, character adn denominator being 0.
            if (CheckForNull(input, inputType))
                return false;
            else if (CheckForCharacter(input, inputType))
                return false;
            else if (CheckDenominatorIsZero(input, inputType))
                return false;

            return true;

        }

        private static bool CheckForNull(string input, string inputType)
        {
            // check if numerator is not empty
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"{inputType} can not be empty or null.");
                Console.WriteLine("Please another number:");
                return true; 
            }
            else
                return false;
        }

        private static bool CheckForCharacter(string input, string inputType)
        {
            long value = 0;

            // check if input is NOT a number
            if (!long.TryParse(input, out value))
            {
                // check first char for sign
                if ((input[0] == '-') && (input.Length > 1))
                {
                    // check the rest of the string.
                    if (long.TryParse(input.Substring(1, input.Length-1), out value))
                        return false; 
                }
                Console.WriteLine($"Please pick a number for {inputType} not character.");
                Console.WriteLine("Please another number:");
                return true;
            }
            else
                return false;

        }

        private static bool CheckDenominatorIsZero(string input, string inputType)
        {
            //check denominator is not 0
            long value = Convert.ToInt64(input);
            if ((inputType == "denominator") && (value == 0))
            {
                Console.WriteLine($"{inputType} can not be 0.");
                Console.WriteLine("Please another number:");
                return true;
            }
            else
                return false;
        }


        public static void WriteOutput(Fractions f1, Fractions f2)
        {
            Console.WriteLine("Add : " + (f1 + f2).ToString());
            Console.WriteLine("Subtract : " + (f1 - f2).ToString());
            Console.WriteLine("Multiply : " + (f1 * f2).ToString());
            Console.WriteLine("Division : " + (f1 / f2).ToString());
            Console.WriteLine("Is Equal : " + (f1 == f2).ToString());
            Console.WriteLine("Is not Equal : " + (f1 != f2).ToString());
            Console.WriteLine("Is Greater : " + (f1 < f2).ToString());
            Console.WriteLine("Is Smaller :" + (f1 > f2).ToString());
        }

    }
}
