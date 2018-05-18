using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Movie
    {
        public string movieID = "";
        public string movieName = "";
        public string movieLanguage = "";
        
        public Movie(string movieID, string movieName, string movieLanguage)
        {
            this.movieID = movieID;
            this.movieName = movieName;
            this.movieLanguage = movieLanguage;
        }

    }

    //public class Movies
    //{
    //    public string movieID { get; set; }
    //    public string movieName { get; set; }
    //    public string movieLanguage { get; set; }

    //}
}
