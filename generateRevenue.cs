using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class GenerateRevenue
    {
        public int printCSVFile(Dictionary<string, Dictionary<string, double>> theatreRevenue)
        {            
            if (theatreRevenue.Count == 0)
            {
                return 0;
            }

            var csv = new StringBuilder();

            foreach (string theatre in theatreRevenue.Keys)
            {
                foreach (string showName in theatreRevenue[theatre].Keys)
                {
                    var newLine = string.Format("{0},{1},{2}", theatre, showName, theatreRevenue[theatre][showName]);
                    csv.AppendLine(newLine); 
                }
                
            }

            try
            {
                File.WriteAllText("E:\\Revenue.csv", csv.ToString());
            }
            catch(Exception)
            {
                return 0;
            }
            
            return 1;
        }
    }
}
