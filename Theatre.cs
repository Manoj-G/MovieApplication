using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Theatre
    {
        public string theatreID = "";
        public string theatreName = "";
        public int theatreCapacity = 0;
        public ArrayList shows = new ArrayList();

        public Theatre(string theatreID, string theatreName, int theatreCapacity, ArrayList shows)
        {
            this.theatreID = theatreID;
            this.theatreName = theatreName;
            this.theatreCapacity = theatreCapacity;
            this.shows = shows;
        }
    }
}
