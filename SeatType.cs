using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class SeatType
    {
        public char seatName;
        public int seatCount = 0;
        public double seatPrice = 0;

        public SeatType(char seatName, int seatCount, int seatPrice)
        {
            this.seatName = seatName;
            this.seatCount = seatCount;
            this.seatPrice = seatPrice;
        }
    }
}
