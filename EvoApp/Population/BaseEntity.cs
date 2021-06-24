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

        static public Size paint_szStartOffset { get; } = new Size(4, 4);
        static public Size paint_szEntity { get; } = new Size(20, 20);
        static public int  paint_shiftEntity { get; } = 4;
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
        virtual public int Paint(Graphics canvasGraph, int idxInList, DeskCell cell, Rectangle rect)
        {
            // точка, откуда разрешено рисовать в ряд, по порядку на место индекса idxInList
            int x_origin = rect.X + BaseEntity.paint_szStartOffset.Width;
            int y_origin = rect.Y + BaseEntity.paint_szStartOffset.Height;

            // смещение, которое пропорционально количеству(= idxInList) уже нарисованных ентетей 
            int x_offset = x_origin + idxInList * (BaseEntity.paint_szEntity.Width + BaseEntity.paint_shiftEntity);
            int y_offset = y_origin + idxInList * (BaseEntity.paint_szEntity.Height + BaseEntity.paint_shiftEntity);

            drawOnRect(
                canvasGraph, 
                x_offset, 
                y_offset, 
                BaseEntity.paint_szEntity.Width, 
                BaseEntity.paint_szEntity.Height
                );            

            return 0;
        }
        // ***********************************************************************************************************************************
    }
}
