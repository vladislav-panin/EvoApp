using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    public class CellPainter
    {
        public static Font fnt = new Font("Arial", 7);
        public static Point txtOrigin = new Point(2, 2);

        static Pen borderPen = new Pen(Color.FromArgb(255, 255, 255, 255), 1);

        // ****************************************************************************************
        public CellPainter()
        {
        }

        // ****************************************************************************************
        // Здесь прорисовывается ландшафт ячейки, видимой на большой панели        
        virtual public void paintCell(Graphics canvasGraph, DeskCell cell, int xCellIdx, int yCellIdx)
        {
            Rectangle rect = new Rectangle(); // координаты прямоугольника на большой панели, в пикселях, где рисуем

            rect.X = xCellIdx * DeskCell.cellWidth;
            rect.Y = yCellIdx * DeskCell.cellHeight;

            rect.Width = DeskCell.cellWidth;
            rect.Height = DeskCell.cellHeight;

            paintBackground (canvasGraph, cell, rect);
            paintBiom       (canvasGraph, cell, rect);
            paintUrban      (canvasGraph, cell, rect);

            signCell (canvasGraph, cell, rect);
            paintGrid(canvasGraph, rect);
        }
        // ****************************************************************************************        

        virtual public void paintBackground (Graphics canvasGraph, DeskCell cell, Rectangle cellPaintRect)
        {
            canvasGraph.DrawImage(
                cell.land.getBackground(), 
                cellPaintRect.X, 
                cellPaintRect.Y);
        }

        virtual public void paintBiom (Graphics canvasGraph, DeskCell cell, Rectangle cellPaintRect)
        {
            BiomBase ent;
            // Здесь прорисовываются обитатели ячейки, видимой на большой панели            
            for (int i = 0; i < cell.lstEntity.Count; i++)
            {
                //ent = lstEntity[i];
                //ent. Paint (canvasGraph, i, this, this.cellRect);
            }
        }
        // ****************************************************************************************

        virtual public void paintUrban(Graphics canvasGraph, DeskCell cell, Rectangle cellPaintRect)
        {            
        }
        // ****************************************************************************************

        virtual public void signCell(Graphics canvasGraph, DeskCell cell, Rectangle cellPaintRect)        
        {
            String sign = cell.cooIdxsTxt;

            if (!PainterEvoPanelBig.isCoordRequired)
                return;

            Brush br = (cell.land.elandscape == ELandscape.Wood) ? Brushes.White : Brushes.Red;                
            canvasGraph.DrawString(sign, fnt, br, cellPaintRect.X + txtOrigin.X, cellPaintRect.Y + txtOrigin.Y);
        }
        // ****************************************************************************************

        virtual public void paintGrid(Graphics canvasGraph, Rectangle rect)
        {
            if (!PainterEvoPanelBig.isGridRequired)
                return;
            
            canvasGraph.DrawRectangle(CellPainter.borderPen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        // ****************************************************************************************

        

            

    }
}
