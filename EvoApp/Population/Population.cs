using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class Population
    {
        //public Dictionary<List<DeskCell>> cellLst { get; set; } = null;

        public int rowCount = 1000;
        public int columnCount = 1000;

        public Population()
        {

        }

        //инициализация ячеек игрового поля 1000*1000
        public int Init()
        {/*
            cellLst = new List<List<DeskCell>>();
            int counter = 0;

            int idxRow = 0;
            int idxColumn = 0;

            for (idxRow = 0; idxRow < rowCount; idxRow++)
            {
                List<DeskCell> cell = new List<DeskCell>();
                cellLst.Add(cell);

                for (idxColumn = 0; idxColumn < columnCount; idxColumn++)
                {
                    DeskCell dc = new DeskCell(idxRow, idxColumn);
                    cell.Add(dc);
                }
            }

            counter = idxRow * idxColumn;
            return counter;
            */
            return 0;
        }
    }
}
