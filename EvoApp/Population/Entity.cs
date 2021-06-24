using EvoApp.Properties;
using System.Drawing;
using System.Resources;

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
        
        override public Point[] getStepShift() {
            return stepEntity;
        }

        // *************************************************************************************************************************************************
        static private SolidBrush paint_brush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

        override public Brush getBrush() {
            return paint_brush;
        }
        // *************************************************************************************************************************************************
        // *************************************************************************************************************************************************
        public Entity (long entityId) : base (entityId) {
        }
        // *************************************************************************************************************************************************
        public Entity(long entityId, int cellX, int cellY) : base(entityId) {
            this.position.X = cellX;
            this.position.Y = cellY;
        }
        // *************************************************************************************************************************************************        
        // Rectangle rect - это координаты прямоугольникаи на панели, в пикселях, где рисуем
        /*
        override protected void drawOnRect(Graphics canvasGraph, int xOriginGlobal, int yOriginGlobal, int width, int height)
        {
            //base.drawOnRect(canvasGraph, xOriginGlobal, yOriginGlobal, width, height);

            canvasGraph.FillEllipse (
                getBrush(),
                xOriginGlobal,
                yOriginGlobal,
                width,
                height);
        }
        */
        override protected void drawOnRect(Graphics canvasGraph, int xOriginGlobal, int yOriginGlobal, int width, int height)
        {
            canvasGraph.DrawImage(Population.bmpEntity, xOriginGlobal, yOriginGlobal);
        }
        // *************************************************************************************************************************************************
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
        // *************************************************************************************************************************************************
    }
}
