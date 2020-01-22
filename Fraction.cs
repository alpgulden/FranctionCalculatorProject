using System;

namespace franctions_alpgulden
{
    public partial class Fractions
    {
            // fields
            // loosely coopled - composition defined between fractions and numbers.
            private Numbers _numerator;
            private Numbers _denominator;
            private long _simplyFiedNumerator;
            private long _simplyFiedDenominator;

            //properties

            //constructor
            public Fractions(long numerator, long denominator)
            {

            try
            {

                // If both less than 0 than make them pozitive
                if (numerator < 0 && denominator < 0)
                {
                    numerator = -numerator;
                    denominator = -denominator;
                }

                    // creating Number objects
                this._numerator = SetNumberObject(numerator);
                this._denominator =   SetNumberObject(denominator);
                
                // if numerator is 0
                if(numerator!=0)
                    // assigning simplified numbers
                    SetSimplifyFieldValues();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            private Numbers SetNumberObject(long value)
            {
                // create a Number object instance
                var number = new Numbers(value);
                return number;
            }

            private void SetSimplifyFieldValues()
            {
                if (_numerator.Value == 0)
                    _denominator.Value = 0;

                //finding greatest common factor
                long divisor = Utility.GCF(this._numerator.Value, this._denominator.Value);

                // set simplyfied values
                if (divisor != 1)
                {
                    this._simplyFiedNumerator = Utility.Division(this._numerator.Value, divisor);
                    this._simplyFiedDenominator = Utility.Division(this._denominator.Value, divisor);
                }
                else
                {
                    this._simplyFiedNumerator = this._numerator.Value;
                    this._simplyFiedDenominator = this._denominator.Value;
                }
            }

            //operator overloading
            public static Fractions operator -(Fractions f)
            {
                return new Fractions(-f._numerator.Value, f._denominator.Value);
            }

            public static Fractions operator +(Fractions f1, Fractions f2)
            {
                return new Fractions(f1._numerator.Value * f2._denominator.Value + f2._numerator.Value * f1._denominator.Value, f1._denominator.Value * f2._denominator.Value);
            }

            public static Fractions operator -(Fractions f1, Fractions f2)
            {
            return new Fractions(f1._numerator.Value * f2._denominator.Value - f2._numerator.Value * f1._denominator.Value, f1._denominator.Value * f2._denominator.Value);
            }

            public static Fractions operator *(Fractions f1, Fractions f2)
            {
                return new Fractions(f1._numerator.Value * f2._numerator.Value, f1._denominator.Value * f2._denominator.Value);
            }

            public static Fractions operator /(Fractions f1, Fractions f2)
            {
                if (f2._numerator.Value == 0)
                {
                    //application stops
                    throw new DivideByZeroException();
                }
                return new Fractions(f1._numerator.Value * f2._denominator.Value, f1._denominator.Value * f2._numerator.Value);
            }

            public static Boolean operator ==(Fractions f1, Fractions f2)
            {
                if (f1._numerator.Value == f2._numerator.Value && f1._denominator.Value == f2._denominator.Value)
                    return true;
                else
                    return false;
            }

            public static Boolean operator <(Fractions f1, Fractions f2)
            {
                if (f1._numerator.Value * f2._denominator.Value < f2._numerator.Value * f1._denominator.Value)
                    return true;
                else
                    return false;
            }

            public static Boolean operator >(Fractions f1, Fractions f2)
            {
                if (f1._numerator.Value * f2._denominator.Value > f2._numerator.Value * f1._denominator.Value)
                    return true;
                else
                    return false;
            }


            public static Boolean operator !=(Fractions f1, Fractions f2)
            {
                if (f1._numerator.Value != f2._numerator.Value || f1._denominator.Value != f2._denominator.Value)
                    return true;
                else
                    return false;
            }

            public override string ToString()
            {
                if (_simplyFiedNumerator == 0)
                    return "0";
                else if(_simplyFiedDenominator == 1)
                    return _simplyFiedNumerator.ToString();
                else if (_simplyFiedNumerator == _simplyFiedDenominator)
                    return _simplyFiedNumerator.ToString();
                else if (Math.Abs(_simplyFiedNumerator) > Math.Abs(_simplyFiedDenominator))
                    return $"{_simplyFiedNumerator} / {_simplyFiedDenominator} ({_simplyFiedNumerator % _simplyFiedDenominator} {_simplyFiedNumerator - ((_simplyFiedNumerator % _simplyFiedDenominator) * _simplyFiedDenominator)}/{_simplyFiedDenominator})";
                else
                    return $"{_simplyFiedNumerator} / {_simplyFiedDenominator}";
            }
    }
    
}
