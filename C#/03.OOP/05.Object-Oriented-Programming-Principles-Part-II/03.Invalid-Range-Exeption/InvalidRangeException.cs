using System;
using System.Linq;

namespace _03.Invalid_Range_Exeption
{
    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable<T>
    {
        public T MinValue { get; private set; }
        public T MaxValue { get; private set; }
        public T Value { get; private set; }

        public InvalidRangeException(T value, T minValue, T maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.Value = value;

        }

        public override string ToString()
        {
            return string.Format("The value {0} is outside the boundries {1} - {2}.", this.Value, this.MinValue, this.MaxValue);
        }
    }
}
