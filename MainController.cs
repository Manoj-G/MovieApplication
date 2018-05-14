using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class MainController
    {
        TheatreController theatreController = new TheatreController();
        Dictionary<string, int> theatreAndCapacity = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, int>> showTimeAndCapacity = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<Movie, Dictionary<string, Dictionary<string, int>>> bookingDetails = new Dictionary<Movie, Dictionary<string, Dictionary<string, int>>>();
        int theatreCapacity = 1;
        public ArrayList ticketList = new ArrayList();
        static int ticketCount = 1;
        static string ticketID = "Ticket" + ticketCount;
        double totalRevenue = 0;

        public int bookTicket(string theatre, string movie, char seatType)
        {
            if (theatre == "" || movie == "" || (seatType.ToString()).Length == 0)
            {
                return 1;
            }

            foreach (Theatre theatreObject in theatreController.theatreList)
            {
                if (theatreObject.theatreName == theatre)
                {
                    foreach (Show show in theatreObject.shows)
                    {
                        if (show.movie.movieName == movie)
                        {
                            foreach (SeatType seatTypeObject in show.seatType)
                            {
                                if (seatTypeObject.seatName == seatType)
                                {

                                    if (theatreObject.theatreCapacity < theatreCapacity)
                                    {
                                        return 1;
                                    }

                                    if (theatreAndCapacity.ContainsKey(theatre))
                                    {
                                        theatreAndCapacity[theatreObject.theatreName] = theatreAndCapacity[theatre] + 1;
                                    }
                                    else
                                    {
                                        theatreAndCapacity.Add(theatreObject.theatreName, theatreCapacity);
                                    }

                                    if (showTimeAndCapacity.ContainsKey(show.showTime))
                                    {
                                        showTimeAndCapacity[show.showTime] = theatreAndCapacity;
                                    }
                                    else
                                    {
                                        showTimeAndCapacity.Add(show.showTime, theatreAndCapacity);
                                    }

                                    if (bookingDetails.ContainsKey(show.movie))
                                    {
                                        bookingDetails[show.movie] = showTimeAndCapacity;
                                    }
                                    else
                                    {
                                        bookingDetails.Add(show.movie, showTimeAndCapacity);
                                    }
                                    totalRevenue = totalRevenue + seatTypeObject.seatPrice;

                                    Ticket ticket = new Ticket(ticketID, theatreObject.theatreName, show.showName, show.movie.movieName, seatTypeObject.seatPrice);
                                    ticketCount++;
                                    ticketID = "Ticket" + ticketCount;
                                    theatreCapacity++;
                                    ticketList.Add(ticket);

                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public ArrayList getTheatre(string inputMovie)
        {
            int movieNotFound = 0;
            ArrayList theatreList = new ArrayList();

            foreach (Theatre theatre in theatreController.theatreList)
            {
                foreach (Show show in theatre.shows)
                {
                    if (show.movie.movieName == inputMovie)
                    {
                        movieNotFound = 1;
                        theatreList.Add(theatre);
                    }
                }
            }

            if (movieNotFound == 0)
            {
                return theatreList;
            }

            return theatreList;
        }
    }
}
