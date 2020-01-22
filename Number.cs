using System;

namespace franctions_alpgulden
{
    
    // Just to experimenting to have extensible design by defining a Numbers class as interface
    // decided to have generic number class that we can use it assign rational numbers or complex number for scailability.
    // this may not be the shortest solution but i wanted include some encapsulation and inheritance.
    public interface INumbers
    {
        
    }

    //drived from and interface. we dont have anything specific needed but in future if we need a function or property we can add here 
    public class RationalNumbers: INumbers
    { 
    
        private long _value;

        //properties used for encapsulation and keep fields private
        public long Value { get => _value; set => _value = value; }


        //construcor
        public RationalNumbers()
        {
        }

        public RationalNumbers(long value)
        {
            this.Value = value;
        }
             
        
    }

    public class ComplexNumbers : INumbers
    {

        
    }
}
