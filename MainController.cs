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
        
        /*  Dictionaries for maintaining the records of tickets booked */
        Dictionary<string, int> theatreAndCapacity = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, int>> showTimeAndCapacity = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<Movie, Dictionary<string, Dictionary<string, int>>> bookingDetails = new Dictionary<Movie, Dictionary<string, Dictionary<string, int>>>();
        
        /* For checking theatreCapacity */
        public Dictionary<string, int> theatreCapacity = new Dictionary<string, int>();
 
        public ArrayList ticketList = new ArrayList();
        static int ticketCount;
        static string ticketID;
        double totalRevenue = 0;

        public MainController()
        {
            ticketCount = 1;

            theatreCapacity.Add(theatreController.theatre1.theatreName, 0);
            theatreCapacity.Add(theatreController.theatre2.theatreName, 0);

            ticketID = "Ticket" + ticketCount;
        }

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

                                        if (theatreObject.theatreCapacity < theatreCapacity[theatreObject.theatreName])
                                        {
                                            return 1;
                                        }

                                        theatreCapacity[theatreObject.theatreName] = theatreCapacity[theatreObject.theatreName] + 1;

                                        if (theatreAndCapacity.ContainsKey(theatre))
                                        {
                                            theatreAndCapacity[theatreObject.theatreName] = theatreAndCapacity[theatre] + 1;
                                        }
                                        else
                                        {
                                            theatreAndCapacity.Add(theatreObject.theatreName, theatreCapacity[theatreObject.theatreName]);
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
