using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Theatre { TheatreA, TheatreB }

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {   
            MainController mainController = new MainController();
            MovieController movieController = new MovieController();
           // Dictionary<Movie, string> bookingDetails = new Dictionary<Movie, string>();

            while (true)
            {
                Console.WriteLine("Do you want to register yourself for a movie\nYES\nNO");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "YES")
                {
                    Console.WriteLine("Which Movie would you like to Book!!");
                    ArrayList movies = movieController.getMovies();

                    foreach (Movie mov in movies)
                    {
                        Console.WriteLine(mov.movieName);
                    }

                    Console.WriteLine("\nEnter the movie you want to watch!!!(Enter the movie name in the SAME manner GIVEN above)");
                    string inputMovie = Console.ReadLine();

                    ArrayList theatreList = mainController.getTheatre(inputMovie);

                    if (theatreList.Count == 0)
                    {
                        Console.WriteLine("\nSorry!! This movie is not available in any of the Theatres!!!");
                        continue;
                    }

                    Console.WriteLine("\nSelected Movie found in following theatres \n");
                    foreach (Theatre theatre in theatreList)
                    {
                        Console.WriteLine("Theatre ID is --> " + theatre.theatreID + "\nTheatre Name is --> " + theatre.theatreName);
                        foreach (Show show in theatre.shows)
                        {
                            if (show.movie.movieName == inputMovie)
                            {
                                Console.WriteLine("Show is --> " + show.showName + "\nShow Time is --> " + show.showTime);
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("In which theatre do you want to book your movie");
                    foreach (Theatre theatre in theatreList)
                    {
                        Console.WriteLine(theatre.theatreName);
                    }
                    string theatreChoice = Console.ReadLine();

                    Console.WriteLine("Which Seat Class you prefer from the following\nA\nB\nC");
                    char seatType = Convert.ToChar(Console.ReadLine());

                    int status = mainController.bookTicket(theatreChoice, inputMovie, seatType);

                    if (status == 0)
                    {
                        Console.WriteLine("Your Movie ticket has been Booked ");
                        ArrayList ticket = mainController.ticketList;
                        Ticket registeredTicket = (Ticket)ticket[ticket.Count-1];
                        Console.WriteLine(registeredTicket.ticket+" "+registeredTicket.movieName+" "+ registeredTicket.showName+" "+registeredTicket.theatre+" Price-->"+registeredTicket.price);
                    }
                    else
                    {
                        Console.WriteLine("Sorry!!, The show in this theatre is out of seats\nPlease check something else...");
                        continue;
                    }

                    Console.WriteLine("-------------------------------------------------------------------------------");
                }
                else if (choice == "NO")
                {
                    Console.WriteLine("Synopsis\n");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
