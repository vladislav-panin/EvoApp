using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class DeskCell
    {
        static protected int width = -1; // в пикселях
        static protected int height = -1; // в пикселях

        public int idxCol { get; set; }
        public int idxRow { get; set; }        

        public String cooIdxsTxt { get; set; }
        public Landscape land { get; set; }
        public PaintCell painter { get; set; }

        // ****************************************************************************************
        public DeskCell(int idxRow, int idxColumn)
        {
            this.idxRow = idxRow;
            this.idxCol = idxColumn;

            this.cooIdxsTxt = "(" + this.idxRow + "; " + this.idxCol + ")";
        }

        // ****************************************************************************************
        virtual public void Init()
        {
            // DeskCell.width = PaintCell.cellWidthPx;
            //DeskCell.height = PaintCell.cellHeightPx;
        }

        // ****************************************************************************************
        public void paint (Graphics canvasGraph, int originX, int originY)
        {
            String sign = this.cooIdxsTxt;

            painter.paintCell(canvasGraph, originX, originY, DeskCell.width, DeskCell.height);
        }
        // ****************************************************************************************
    }
}
