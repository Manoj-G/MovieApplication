using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class MovieController
    {
        ArrayList moviesList = new ArrayList();

        public Movie Wolverine = new Movie("ID1", "Wolverine", "English");
        public Movie XMen = new Movie("ID2", "XMen", "English");
        public Movie Coco = new Movie("ID3", "Coco", "English");
        public Movie Avengers = new Movie("ID4", "Avengers", "English");
        public Movie JusticeLeague = new Movie("ID5", "JusticeLeague", "English");
        public Movie Avatar = new Movie("ID6", "Avatar", "English");
        public Movie Mummy = new Movie("ID7", "Mummy", "English");
        public Movie PacificRim = new Movie("ID8", "PacificRim,", "English");
        public Movie ToyStory = new Movie("ID9", "ToyStory", "English");

        public ArrayList getMovies()
        {
            moviesList.Add(Wolverine);
            moviesList.Add(XMen);
            moviesList.Add(Coco);
            moviesList.Add(Avengers);
            moviesList.Add(JusticeLeague);
            moviesList.Add(Avatar);
            moviesList.Add(Mummy);
            moviesList.Add(PacificRim);
            moviesList.Add(ToyStory);

            return moviesList;
        }

    }
}
