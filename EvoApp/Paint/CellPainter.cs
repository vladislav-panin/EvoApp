using System;
using System.Drawing;

namespace EvoApp
{
    public class CellPainter
    {
        public static Font fnt = new Font("Arial", 7);
        public static Point txtOrigin = new Point(2, 5);

        static Pen borderPen = new Pen(Color.FromArgb(255, 255, 255, 255), 1);

        // ****************************************************************************************
        public CellPainter()
        {

        }

        // ****************************************************************************************
        // int originX_inPixels, int originY_inPixels - это координаты точки на панели, в пикселях, откуда начинаем писать
        virtual public void signCell(Graphics canvasGraph, String sign, int originX_inPixels, int originY_inPixels)
        {
            if (PainterBigEvoPanel.isCoordRequired)
                canvasGraph.DrawString(sign, fnt, Brushes.Blue, txtOrigin.X + originX_inPixels, txtOrigin.Y + originY_inPixels);
        }

        // ****************************************************************************************
        // int originX_inPixels, int originY_inPixels - это координаты точки на панели, в пикселях, откуда начинаем рисоовать
        virtual public void paintCell(Graphics canvasGraph, Rectangle rect)
        {
            if (PainterBigEvoPanel.isGridRequired)
                canvasGraph.DrawRectangle(CellPainter.borderPen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        // ****************************************************************************************
    }
}
