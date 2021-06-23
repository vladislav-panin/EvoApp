using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class Entity: BaseEntity
    {
        protected static Point[] stepEntity = new Point[]
        {
            new Point(+1,-2), new Point(-1,-2),
            new Point(+2,-1), new Point(-2,-1),
            new Point(+2,+1), new Point(-2,+1),
            new Point(+1,+2), new Point(-1,+2),
        };
        // *************************************************************************************************************************************************

        override public Point[] getStepShift()
        {
            return stepEntity;
        }

        public IBehavior behavior { get; set; }


        ///////////////////
       
        public Entity (int entityId) : base (entityId)
        {

        }

        //инициализация ячеек игрового поля 1000*1000
        virtual public int Paint (Graphics canvasGraph, DeskCell cell)
        {
            return 0;
        }

        ///////////////////
        override public void Move()
        {
            int idxStep = rndStepIndexGenerator.Next(0, 7);

            int indCellX = this.position.X; // получили индекс по горизонтали ячейки в которой ent распологается сейчас
            int indCellY = this.position.Y; // получили индекс по вертикали ячейки в которой ent распологается сейчас

            int indCellX_Next = this.position.X + getStepShift()[idxStep].X; // вычисляем индекс по горизонтали ячейки в которую ent прыгнет следующим шагом
            int indCellY_Next = this.position.Y + getStepShift()[idxStep].Y; // вычисляем индекс по вертикали ячейки в которую ent прыгнет следующим шагом

            Cells()[indCellY][indCellX].EntityRemove(this);
            Cells()[indCellY][indCellX].EntityAdd(this);
        }
        ///////////////////
    }
}
