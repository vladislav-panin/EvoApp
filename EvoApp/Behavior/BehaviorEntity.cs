using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class BehaviorEntity : IBehavior
    {
        public int shiftX { get; set; } = 1;
        public int shiftY { get; set; } = 1;

        public BehaviorEntity(int shiftX, int shiftY)
        {
            this.shiftX = shiftX;
            this.shiftY = shiftY;
        }

        public DeskCell Move(DeskCell fromCell)
        {
            DeskCell to = null;

            int col = fromCell.idxCol;
            int row = fromCell.idxRow;

            /*if (col + shiftY)


            Program.app.desk.cellLst []
            */

            return to;
        }

        public bool Catch(DeskCell current, DeskCell tryingToRichCell)
        {
            return false;
        }

        public bool Eat (Entity who, Entity whom, DeskCell current)
        {
            return false;
        }
    }
}
