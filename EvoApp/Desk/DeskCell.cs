using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    // ячейка на поле игры
    public class DeskCell
    {
        static public int cellWidth { get; set; }  = -1; // в пикселях
        static public int cellHeight { get; set; } = -1; // в пикселях

        public int idxCol { get; set; }
        public int idxRow { get; set; }        

        public String cooIdxsTxt { get; set; }
        public Landscape land { get; set; }

        Rectangle cellRect = new Rectangle();

         protected List<Entity> lstEntity { get; set; } = new List<Entity>();

        public void EntityAdd(Entity ent)
        {
            lstEntity.Add(ent);
        }

        public void EntityRemove(Entity ent)
        {
            lstEntity.Remove(ent);
        }

        public void EntityRemoveAll()
        {
            lstEntity.Clear();
        }

        public void EntityMoveAll()
        {
            for (int i = 0; i < lstEntity.Count; i++)
            {
                lstEntity[i].Move();
            }
        }

        // ****************************************************************************************
        public DeskCell(int idxRow, int idxColumn)
        {
            this.idxRow = idxRow;
            this.idxCol = idxColumn;

            this.cooIdxsTxt = "(" + this.idxRow + "; " + this.idxCol + ")";
        }

        // ****************************************************************************************
        static public void InitCell (int cell_width, int cell_height)
        {
            DeskCell.cellWidth = cell_width;
            DeskCell.cellHeight = cell_height;
        }

        // ****************************************************************************************
        public void paint (Graphics canvasGraph, CellPainter cellPainter, int xCellIdx, int yCellIdx)
        {
            String sign = this.cooIdxsTxt;

            int originX_OnBigPanel_inPixels = xCellIdx * DeskCell.cellWidth; 
            int originY_OnBigPanel_inPixels = yCellIdx * DeskCell.cellHeight;

            this.cellRect.X = originX_OnBigPanel_inPixels;
            this.cellRect.Y = originY_OnBigPanel_inPixels;
            this.cellRect.Width = DeskCell.cellWidth;
            this.cellRect.Height = DeskCell.cellHeight;

            canvasGraph.FillRectangle(land.brush, this.cellRect);

            cellPainter.signCell(canvasGraph, this.land.textBrush, sign, originX_OnBigPanel_inPixels, originY_OnBigPanel_inPixels) ;
            cellPainter.paintCell(canvasGraph, this.cellRect);
        }
        // ****************************************************************************************
    }
}
