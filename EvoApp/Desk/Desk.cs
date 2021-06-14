using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class Desk
    {
        protected List<List<DeskCell>> cellLst = null;

        public Desk() 
        {
            
        }
        //инициализация ячеек игрового поля 1000*1000
        public int Init()
        {
            cellLst = new List<List<DeskCell>>();
            int counter = 0;
            int i = 0;
            int j = 0;

            for (i = 0; i < 1000; i++)
            {
                List<DeskCell> cell = new List<DeskCell>();
                cellLst.Add(cell);
                
                for (j = 0; j < 1000; j++)
                {
                    DeskCell dc = new DeskCell();
                    cell.Add(dc);
                }
            }

            counter = i * j;
            return counter;
        }
    }
}
