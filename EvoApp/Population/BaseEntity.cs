using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class BaseEntity
    {
        public int idOfEntity { get; } = -1;
        public int helthy { get; set; } = 100;
        public int speed  { get; set; } = 100;

        public Point position { get; set; } = new Point (0, 0); // индекс ячейки
        
        
        public BaseEntity (int idOfEntity)
        {
            this.idOfEntity = idOfEntity;
        }        
    }
}
