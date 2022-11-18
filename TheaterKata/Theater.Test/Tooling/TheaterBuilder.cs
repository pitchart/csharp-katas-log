using System.Collections;
using System.Collections.Generic;

namespace Theater.Test.Tooling
{

    public class TheaterBuilder
    {
        private IDictionary<string, IEnumerable<int>> _seats;

        private TheaterBuilder(IDictionary<string, IEnumerable<int>> seats)
        {
            _seats = seats;
        }

        public static TheaterBuilder ADefaultTheater()
        {
            var theaterMap = new Dictionary<string, IEnumerable<int>>()
            {
                { "A", new List<int> { 1, 2, 3, 4, 5, 6, 7 } },
                { "B", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 } },
                { "C", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { "D", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { "E", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } },
                { "F", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } },
                { "G", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } }
            };

            return new TheaterBuilder(theaterMap);
        }

        public Theater Build()
        {
            return new Theater(_seats);
        }
    }

}
