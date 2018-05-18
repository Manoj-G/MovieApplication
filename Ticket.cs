using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Ticket
    {
        public string ticket;
        public string theatre;
        public string showName;
        public string movieName;
        public double price;

        public Ticket(string ticket, string theatre, string showName, string movieName, double price)
        {
            this.ticket = ticket;
            this.theatre = theatre;
            this.showName = showName;
            this.movieName = movieName;
            this.price = price;
        }
    }
}
