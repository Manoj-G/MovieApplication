using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Show
    {
        public string showName = "";
        public string showTime = "";
        public ArrayList seatType = new ArrayList();
        public Movie movie;

        public Show(string showName, string showTime, Movie movie, ArrayList seatType)
        {
            this.showName = showName;
            this.showTime = showTime;
            this.movie = movie;
            this.seatType = seatType;
        }
    }
}
