using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Theater
{

    public class Seat
    {

        public string Row { get; }

        public int SeatNumber { get; }

        public Seat(string row, int seatNumber)
        {
            this.Row = row;
            this.SeatNumber = seatNumber;
        }

        public override string ToString()
        {
            return this.Row + this.SeatNumber;
        }
    }

}
