using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {   
            MainController mainController = new MainController();
            MovieController movieController = new MovieController();
            GenerateRevenue generateRevenue = new GenerateRevenue();

            while (true)
            {
                Console.WriteLine("Do you want to register yourself for a movie\nYES\nNO");
                Console.WriteLine("*************************");
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
                    movies.Clear();

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

                    Console.WriteLine("In which following theatre do you want to book your movie:-> (Enter the Theatre type as given below)");
                    foreach (Theatre theatre in theatreList)
                    {
                        Console.WriteLine(theatre.theatreName);
                    }
                    Console.WriteLine("*************************");
                    string theatreChoice = Console.ReadLine();

                    /* Check if user's input matches the available theatres */
                    int theatrePresent = 0;
                    foreach (Theatre theatre in theatreList)
                    {
                        if (theatre.theatreName == theatreChoice)// What if theatre choice is null.
                        {
                            theatrePresent = 1;
                            break;
                        }
                    }
                    if (theatrePresent == 0)
                    {
                        Console.WriteLine("Entered input is not from the above displayed theatres");
                        continue;
                    }

                    Console.WriteLine("Which Seat Class you prefer from the following\nA\nB\nC (Enter the Seat type as given above)");
                    Console.WriteLine("*************************");
                    char seatType = Convert.ToChar((Console.ReadLine()).ToUpper());

                    int status = mainController.bookTicket(theatreChoice, inputMovie, seatType);

                    if (status == 0)
                    {
                        Console.WriteLine("Your Movie ticket has been Booked ");
                        ArrayList ticket = mainController.ticketList;
                        Ticket registeredTicket = (Ticket)ticket[ticket.Count-1];
                        Console.WriteLine(registeredTicket.ticket+" "+registeredTicket.movieName+" "+registeredTicket.showName+" "+registeredTicket.theatre+" Price-->"+registeredTicket.price);
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
                    Console.WriteLine("\nSynopsis\n");

                    Dictionary<Movie, Dictionary<string, Dictionary<string, int>>> bookingDetails = mainController.bookingDetails;

                    foreach (Movie movie in bookingDetails.Keys)
                    {
                        Console.WriteLine("Movie ID:-> "+movie.movieID+"|| Movie Name:-> "+movie.movieName+"|| Movie Lang:-> "+movie.movieLanguage);
                        foreach (string showTime in bookingDetails[movie].Keys)
                        {
                            Console.WriteLine(showTime);
                            foreach (string theatreName in bookingDetails[movie][showTime].Keys)
                            {
                                Console.WriteLine("Theatre Name:->"+theatreName+"|| Tickets Sold:-->"+bookingDetails[movie][showTime][theatreName]);
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("Do you want to print the revenue of System in a csv file \nYes\nNo\n");
                    string revenueChoice = Console.ReadLine().ToUpper();

                    if (revenueChoice == "YES")//What happens when users enters other than YES or NO
                    {
                        Dictionary<string, Dictionary<string, double>> theatreRevenue = mainController.theatreRevenue;

                        int generatedOrNot = generateRevenue.printCSVFile(theatreRevenue);

                        if (generatedOrNot == 1)
                        {
                            Console.WriteLine("Revenue Generated!!!");
                        }
                        else
                        {
                            Console.WriteLine("Revenue Not Generated!!! Maybe Due to InValid File Path");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You're exiting the system!!!");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Entered Choice is Incorrect!!!");
                    continue;
                }
            }
            Console.ReadKey();
        }
        //All operaions can be grouped into simple methods. for better redability. an method could not be that long.
    }
}
