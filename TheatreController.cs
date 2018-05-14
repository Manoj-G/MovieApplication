using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class TheatreController
    {
        public ArrayList theatreList = new ArrayList();

        public TheatreController()
        {
            ShowController showController = new ShowController();

            Theatre theatre1 = new Theatre("Theatre1", "SatyamCinemas", 100, showController.theatre1Details);
            Theatre theatre2 = new Theatre("Theatre2", "EscapeCinemas", 150, showController.theatre2Details);

            theatreList.Add(theatre1);
            theatreList.Add(theatre2);
        }

       
    }
}
