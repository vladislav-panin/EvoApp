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
            PaintBiom       (canvasGraph, cell, rect);
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
        // ****************************************************************************************        

        virtual public void PaintBiom (Graphics canvasGraph, DeskCell cell, Rectangle cellPaintRect)
        {
            Population pop = Program.app.population;
            cell.lstEntity.Sort((ub1, ub2) => ub2.GetIcoExtentOrder().CompareTo(ub1.GetIcoExtentOrder()));

            UnitBase unit;
            Bitmap bmp;
            int xShift = 0, yShift = cellPaintRect.Height;

            // Здесь прорисовываются обитатели ячейки, видимой на большой панели            
            for (int i = 0; i < cell.lstEntity.Count; i++)
            {
                unit = cell.lstEntity[i];
                bmp = pop.GetBitmap(unit.TYPE, unit.sex);

                xShift = (unit.sex == EUnitSex.EFemale) ? 45 : 0;
                int extendVal = unit.GetIcoExtentOrder();

                switch (extendVal)
                {
                    case 10: xShift += 10;break;
                    case 11: xShift += 26; break;
                    case 12: xShift += 32; break;
                    case 13: xShift += 48; break;
                    case 14: xShift += 54; break;

                    case 30: xShift += 18; break;
                    case 40: xShift += 14; break;
                    case 50: xShift += 8; break;

                    case 75:
                        if (unit.sex == EUnitSex.EFemale)
                            xShift -= 20; break;
                }
                canvasGraph.DrawImage(bmp, cellPaintRect.X + xShift, cellPaintRect.Y + yShift - bmp.Height + 4 - (extendVal / 2));
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
