using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    public class CellPainter
    {
        public static Font fnt = new Font("Arial", 7);
        public static Point txtOrigin = new Point(2, 30);

        static Pen borderPen = new Pen(Color.FromArgb(255, 255, 255, 255), 1);

        // ****************************************************************************************
        public CellPainter()
        {

        }

        // ****************************************************************************************
        // int originX_inPixels, int originY_inPixels - это координаты точки на панели, в пикселях, откуда начинаем писать
        virtual public void signCell(Graphics canvasGraph,Brush txtBrush, String sign, int originX_inPixels, int originY_inPixels)
        {
            if (PainterEvoPanelBig.isCoordRequired)
                canvasGraph.DrawString(sign, fnt, txtBrush, txtOrigin.X + originX_inPixels, txtOrigin.Y + originY_inPixels);
        }

        // ****************************************************************************************
        // Здесь прорисовывается ландшафт ячейки, видимой на большой панели
        // Rectangle rect - это координаты прямоугольникаи на панели, в пикселях, где рисуем
        virtual public void paintCellBackground(Graphics canvasGraph, Rectangle rect)
        {
            if (PainterEvoPanelBig.isGridRequired)
                canvasGraph.DrawRectangle(CellPainter.borderPen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        // ****************************************************************************************        
    }
}
