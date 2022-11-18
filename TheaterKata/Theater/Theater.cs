using System.Collections;
using System.Collections.Generic;

namespace Theater
{

    public class Theater
    {
        private readonly IList<Seat> Seats = new List<Seat>();

        public Theater(IDictionary<string, IEnumerable<int>> seatData)
        {
            foreach ((var rowName, IEnumerable<int> seatsNumbers) in seatData)
            {
                foreach (var seatNumber in seatsNumbers)
                {
                    Seats.Add(new Seat(rowName, seatNumber));
                }
            }
        }
    }

}
