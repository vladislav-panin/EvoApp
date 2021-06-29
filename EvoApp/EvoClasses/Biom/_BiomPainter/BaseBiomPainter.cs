using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public abstract class BiomPainter
    {
        // параметры текста глобальной координаты ячейки, которые пишем на поле большой панали
        public static Font  cooTxtFont = new Font("Arial", 16, FontStyle.Bold);
        public static Point cooTxtOrigin = new Point(2, 2);

        // Точку, откуда будем рисовать ячейки биома на большой панели, устанавливаемна 4 пиксела правее и ниже
        // прямоугольника, передаваемого для рисования этой клетки (рисуем в виртуальном методе этого класса Paint(Graphics, int, DeskCell, Rectangle))
        static public Size   drawOrigin { get; } = new Size(4, 4); 

        // параметры прорисовки аватарок на ячейке
        static public int    avatarWidthPx { get; } = 20;
        static public int    avatarHeightPx { get; } = 20;
        static public Size   avatarSz { get; } = new Size(avatarWidthPx, avatarHeightPx);

        static public int avatarShiftPx { get; } = 4; // число пикселей, на которое будет смещена прорисовка следующего аватара жывотного
        // ***********************************************************************************************************************************
       
        abstract public Brush   getBrush();
        // ***********************************************************************************************************************************

        public BiomPainter(long id)
        {
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

        // Прорисовка ячейки биома на большой панели
        // Rectangle rect - это координаты прямоугольникаи на панели, в пикселях, где рисуем
        virtual public void Paint(Graphics canvasGraph, int idxInList, DeskCell cell, Rectangle rect)
        {
            /*
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
                    x_offset = x_origin + (idxInList - 2) * (BaseEntity.avatarSz.Width + BaseEntity.avatarShiftPx);
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

            if (idxInList <= 8) // остальных не рисуем (пишем число)
            {
                drawOnRect(
                canvasGraph,
                x_offset,
                y_offset,
                BaseEntity.avatarSz.Width,
                BaseEntity.avatarSz.Height
                );

                return;
            }

            if (idxInList == (cell.BiomCount() - 1))
                canvasGraph.DrawString("" + idxInList, cooTxtFont, Brushes.Black, cooTxtOrigin.X, cooTxtOrigin.Y);
            */
        }
        // ***********************************************************************************************************************************
    }
}
