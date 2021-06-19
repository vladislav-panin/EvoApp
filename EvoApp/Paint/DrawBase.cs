using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class DrawBase
    {
        public static Font fnt = new Font("Arial", 7);
        public static Point txtOrigin = new Point(2, 5);

        public bool isGridRequired { get; set; } = true;
        public bool isCoodRequired { get; set; } = true;

        Pen borderPen = new Pen(Color.FromArgb(255, 255, 255, 255), 0.1f);


        // ****************************************************************************************
        public DrawBase()
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
        }
        // ****************************************************************************************

        // int originX_inPixels, int originY_inPixels - это координаты точки на панели, в пикселях, откуда начинаем рисоовать
        virtual public void paintCell(Graphics canvasGraph, int originX_inPixels, int originY_inPixels, int width, int height)
        {
            if (isGridRequired)
                canvasGraph.DrawRectangle(borderPen, originX_inPixels, originY_inPixels, width, height);            
        }

        // int originX_inPixels, int originY_inPixels - это координаты точки на панели, в пикселях, откуда начинаем писать
        virtual public void signCell(Graphics canvasGraph, String sign, int originX_inPixels, int originY_inPixels)
        {
            if (isCoodRequired)
                canvasGraph.DrawString(sign, fnt, Brushes.Blue, txtOrigin.X + originX_inPixels, txtOrigin.Y + originY_inPixels);
        }
        // ****************************************************************************************
    }
}
