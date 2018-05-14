# MovieApplication
An Console Application for Booking Tickets for the specified Movie by Users.

This Application focusses on booking tickets to the users choice and tracking them.
Each and every ticket the user booked is tracked by this system by creating separate class for the Ticket.

1) Program.cs
	This is the main Class in this application, this acts as the View in MVC model, Where all the interactions take place.
2) MainController.cs
	All the rest of the Classes are executed and Invoked from this Controller Class, which also tracks all the details of the entire system.
3) Movie.cs
	This Class gives the details of a specific movie.
4) MovieController.cs
	This Controller assigns Movie Class with specific details.
	Like what Language is that movie,etc.
5) Show.cs
	This Class gives details about wha kind of show it is and at what time the show begins.
	The movie class is assigned inside this class.
6) ShowController.cs
	This Controller Class assigns data and information to the Show Class
7) Theatre.cs
	Theatre Class contains details about what does shows does it have and what kind of movies does it show.
8) TheatreController.cs
	This class is for assigning details to Theatre class.
9) seatType.cs
	This class has seat type name, its cost and its capacity.
	The details for this class is assigned from TheatreController.cs
10) Ticket.cs
	Ticket Class generates a ticket for each user and tracks them. 
10)   
