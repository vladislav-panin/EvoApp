using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public abstract class BaseEntity
    {
        abstract public  Point[] getStepShift();
        abstract public void Move();
        // *************************************************************************************************************************************************
        public int idOfEntity { get; } = -1;
        public int helthy { get; set; } = 100;
        public int speed_X  { get; set; } = 100;

        public int speed_Y { get; set; } = 100;

        public static Random rndStepIndexGenerator = new Random();

        public Point position { get; set; } = new Point (0, 0); // текущий индекс ячейки, то есть сущность находится в ячейке с индексами position.X , position.Y

        public BaseEntity (int idOfEntity)
        {
            this.idOfEntity = idOfEntity;
        }  
        
        public static List<List<DeskCell>> Cells()
        {
            return Program.app.desk.cellTable;
        }
    }
}
