using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class ShowController
    {
        static MovieController movieController = new MovieController();
        static TheatreController theatreController = new TheatreController();

        public ArrayList theatre1Details = new ArrayList();
        public ArrayList theatre2Details = new ArrayList();
        public ArrayList seatType1 = new ArrayList();
        public ArrayList seatType2 = new ArrayList();

        SeatType seatA1 = new SeatType('A', 50, 100);
        SeatType seatB1 = new SeatType('B', 40, 70);
        SeatType seatC1 = new SeatType('C', 10, 50);

        SeatType seatA2 = new SeatType('A', 70, 100);
        SeatType seatB2 = new SeatType('B', 50, 70);
        SeatType seatC2 = new SeatType('C', 30, 60);

       
        public ShowController()
        {
            seatType1.Add(seatA1);
            seatType1.Add(seatB1);
            seatType1.Add(seatC1);

            seatType2.Add(seatA2);
            seatType2.Add(seatB2);
            seatType2.Add(seatC2);

            Show morningShow1 = new Show("MorningShow", "8:30AM", movieController.Wolverine, seatType1);
            Show eveningShow1 = new Show("EveningShow", "8:30AM", movieController.Coco, seatType1);
            Show nightShow1 = new Show("NightShow", "8:30AM", movieController.JusticeLeague, seatType1);

            Show morningShow2 = new Show("MorningShow", "8:30AM", movieController.Mummy, seatType2);
            Show eveningShow2 = new Show("EveningShow", "8:30AM", movieController.ToyStory, seatType2);
            Show nightShow2 = new Show("NightShow", "8:30AM", movieController.Coco, seatType2);
            
            theatre1Details.Add(morningShow1);
            theatre1Details.Add(eveningShow1);
            theatre1Details.Add(nightShow1);

            theatre2Details.Add(morningShow2);
            theatre2Details.Add(eveningShow2);
            theatre2Details.Add(nightShow2);

        }

    }
}
