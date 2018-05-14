using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication5;
using System.Collections;

namespace MovieApplicationTest
{
    [TestClass]
    public class UnitTest1
    {
        MainController mainController = new MainController();
        TheatreController theatreController = new TheatreController();

        [TestMethod]
        public void getTheatre()
        {
            //Assign
            string inputMovie = "";
            ArrayList expected = new ArrayList();

            //Assign
            inputMovie = "Wolverine";
            expected.Add(theatreController.theatre1);
            
            //Act
            ArrayList a = mainController.getTheatre(inputMovie);

            //Assert
            Assert.IsNotNull(a);
            Assert.AreEqual(expected.Count, a.Count);

            // Assign
            inputMovie = "Coco";
            expected.Add(theatreController.theatre2);

            //Act
            a = mainController.getTheatre(inputMovie);

            //Assert
            Assert.IsNotNull(a);
            Assert.AreEqual(expected.Count, a.Count);

            // Assign
            inputMovie = "PacificRim";
            a.Clear();
            expected.Clear();

            //Act
            a = mainController.getTheatre(inputMovie);

            //Assert
            Assert.IsNotNull(a);
            Assert.AreEqual(expected.Count, a.Count);

        }

        [TestMethod]
        public void bookTicket()
        {
            // Assign
            string theatre = "SatyamCinemas";
            string movie = "Wolverine";
            char seatType = 'A';

            // Act
            int bookedOrNot = mainController.bookTicket(theatre, movie, seatType);
            
            // Assert
            Assert.AreEqual(0, bookedOrNot);
            Assert.AreNotEqual(-1, bookedOrNot);

            // Assign
             theatre = "";
             movie = "";
             seatType = 'A';

            // Act
            bookedOrNot = mainController.bookTicket(theatre, movie, seatType);

            // Assert
            Assert.AreEqual(1, bookedOrNot);
            Assert.AreNotEqual(-1, bookedOrNot);

        }
    }
}
