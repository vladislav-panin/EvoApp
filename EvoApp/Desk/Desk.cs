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
        public void Init()
        {
            cellLst = new List<List<DeskCell>>();

            for (int i = 0; i < 1000; i++)
            {
                List<DeskCell> cell = new List<DeskCell>();
                cellLst.Add(cell);
                
                for (int j = 0; j < 1000; j++)
                {
                    DeskCell dc = new DeskCell();
                    cell.Add(dc);
                }
            }
        }
    }
}
