using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _05.BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;
        private readonly bool[] bitArr = new bool[64];

        public ulong Number
        {
            get { return this.number; }
            private set { number = value; }
        }

        public BitArray64(ulong number)
        {
            this.number = ConvertToBitArray(number);
            
        }

        private ulong ConvertToBitArray(ulong number)
        {
            ulong temp = number;
            for (byte i = 0; i < 64; i++)
            {
                if ((temp & 1) == 1)
                {
                    this.bitArr[i] = true;
                }
                else
                {
                    this.bitArr[i] = false;
                }
                temp = temp >> 1;

                if (temp == 0)
                {
                    break;
                }
            }
            return number;
        }

        public bool this[int index]
        {
            get { return this.bitArr[index]; }
            set 
            {
                if (index<0 || index > 63)
                {
                    throw new IndexOutOfRangeException("You have to be kidding me, ulong has indexes from 0 to 63 tops!?!");
                }
                else
                {
                    this.bitArr[index] = value;
                    NewNumber(index, value);
                }
            }
        }

        private void NewNumber(int index, bool value)
        {
            if (value == true)
            {
                ulong mask = (ulong)1 << index;
                this.number = this.number | mask;
            }
            else
            {
                ulong mask = ~((ulong)1 << index);
                this.number = this.number & mask;
            }
        }

        public override string ToString()
        {
            string str = "";
            ulong temp = this.number;

            while (temp != 0)
            {

                str = (temp & 1) + str;
                temp = temp >> 1;

            }
            return str;
        }

        public override bool Equals(object obj)
        {
            BitArray64 bits = obj as BitArray64;

            if (bits == null)
            {
                return false;
            }
            else if (!Object.Equals(this.number, bits.number))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(BitArray64 bits1,BitArray64 bits2)
        {
            return BitArray64.Equals(bits1, bits2);
        }

        public static bool operator !=(BitArray64 bits1, BitArray64 bits2)
        {
            return !(BitArray64.Equals(bits1, bits2));
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = this.bitArr.Length-1; i >=0; i--)
            {
                if (this.bitArr[i] == true)
                {
                    yield return 1;
                }
                else
                {
                    yield return 0;
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
