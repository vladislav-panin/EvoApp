using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    public abstract class BaseEntity
    {
        abstract public void Move();
        abstract public Point[] getStepShift();

        abstract public Brush getBrush ();
        // ***********************************************************************************************************************************

        public long idOfEntity { get; } = -1;

        public int helthy { get; set; } = 100;
        public int speed_X  { get; set; } = 100;
        public int speed_Y { get; set; } = 100;

        public static Random rndStepIndexGenerator = new Random();

        public Point position = new Point (0, 0); // текущий индекс ячейки, то есть сущность находится в ячейке с индексами position.X , position.Y
        // ***********************************************************************************************************************************
        public static Font fnt = new Font("Arial", 9);
        public static Point txtOrigin = new Point(10, 50);

        static public Size drawOrigin { get; } = new Size(4, 4);

        static public int  avatarWidthPx { get; } = 20;
        static public int  avatarHeightPx { get; } = 20;
        static public Size avatarSz { get; } = new Size(avatarWidthPx, avatarHeightPx);

        static public int  avatarShiftPx { get; } = 4; // число пикселей, на которое будет смещена прорисовка следующего аватара жывотного
        // ***********************************************************************************************************************************

        public BaseEntity (long idOfEntity) {
            this.idOfEntity = idOfEntity;
        }          
        public static List<List<DeskCell>> Cells() {
            return Program.app.getDesk().cellTable;
        }
        // ***********************************************************************************************************************************        
        virtual protected void drawOnRect(Graphics canvasGraph, int xOriginGlobal, int yOriginGlobal, int width, int height)
        {
            canvasGraph.FillRectangle(
                getBrush(),
                xOriginGlobal,
                yOriginGlobal,
                width,
                height);
        }
        // ***********************************************************************************************************************************        
        // Rectangle rect - это координаты прямоугольникаи на панели, в пикселях, где рисуем
        virtual public void Paint(Graphics canvasGraph, int idxInList, DeskCell cell, Rectangle rect)
        {
            // точка, откуда разрешено рисовать в ряд, по порядку на место индекса idxInList
            int x_origin = rect.X + BaseEntity.drawOrigin.Width;
            int y_origin = rect.Y + BaseEntity.drawOrigin.Height;

            // смещение, которое пропорционально количеству(= idxInList) уже нарисованных ентетей 
            int x_offset = x_origin;
            int y_offset = y_origin;

            // настроен на квадрат примерно 90х90 px. Можно свободно разместить 9 аватарок 20х20,
            // остальных не рисуем (будем писать число)
            switch (idxInList)
            {
                case 0:
                case 1:
                case 2:
                    x_offset = x_origin + idxInList * (BaseEntity.avatarSz.Width + BaseEntity.avatarShiftPx);
                    y_offset = y_origin + idxInList * (BaseEntity.avatarSz.Height + BaseEntity.avatarShiftPx);
                    break;

                case 3:
                    x_offset = x_origin;
                    y_offset = y_origin + (idxInList - 1) * (BaseEntity.avatarSz.Height + BaseEntity.avatarShiftPx);
                    break;

                case 4:
                    x_offset = x_origin + (idxInList - 2)* (BaseEntity.avatarSz.Width + BaseEntity.avatarShiftPx);
                    y_offset = y_origin;
                    break;

                case 5:
                    x_offset = x_origin;
                    y_offset = y_origin + 1 * (BaseEntity.avatarSz.Height + BaseEntity.avatarShiftPx);
                    break;

                case 6:
                    x_offset = x_origin + 1 * (BaseEntity.avatarSz.Width + BaseEntity.avatarShiftPx);
                    y_offset = y_origin;
                    break;

                case 7:
                    x_offset = x_origin + 2 * (BaseEntity.avatarSz.Width + BaseEntity.avatarShiftPx);
                    y_offset = y_origin + 1 * (BaseEntity.avatarSz.Height + BaseEntity.avatarShiftPx);
                    break;

                case 8:
                    x_offset = x_origin + 1 * (BaseEntity.avatarSz.Width + BaseEntity.avatarShiftPx);
                    y_offset = y_origin + 2 * (BaseEntity.avatarSz.Height + BaseEntity.avatarShiftPx);
                    break;
            }

            if (idxInList > 8) // остальных не рисуем (пишем число)
            {
                if (idxInList == (cell.EntityCount() - 1)  )
                    canvasGraph.DrawString("Ents=" + idxInList, fnt, Brushes.White, txtOrigin.X, txtOrigin.Y);

                return;
            }

            drawOnRect(
                canvasGraph, 
                x_offset, 
                y_offset, 
                BaseEntity.avatarSz.Width, 
                BaseEntity.avatarSz.Height
                );    
        }
        // ***********************************************************************************************************************************
    }
}
