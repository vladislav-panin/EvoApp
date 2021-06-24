using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    public class PainterEvoPanelBig: PainterBase
    {
        static public bool isGridRequired { get; set; } = true;
        static public bool isCoordRequired  { get; set; } = true;
        static public CellPainter cellPainter { get; set; } = null;

        // ****************************************************************************************
        override public void Init(int cellWidthPx, int cellHeightPx)
        {
            base.Init(cellWidthPx, cellHeightPx);
        }

        // ****************************************************************************************
        // int widthPx  - ширина (в пикселях) большой панели, на которой рисую эволюцию
        // int heightPx - высота (в пикселях) большой панели, на которой рисую эволюцию
        override public void InitDimensions(int widthPx, int heightPx)
        {
            base.InitDimensions(widthPx, heightPx);
        }

        override protected void InitBitmaps()
        {
            this.bkGround = new Bitmap (this.widthPx, this.heightPx);
            this.graphfObj_for_bkGround = Graphics.FromImage(this.bkGround);

            PainterEvoPanelBig.cellPainter = new CellPainter();
        }

        // ****************************************************************************************
        override public void offsetCanged()
        {
            // смещение области прорисовки изменилось - значит на панели нужно будет рисовать другую область.
            // Сейчас можно сделать чтонибудь красивое или полезное - 
            // Например, написать координаты нового смещения на панели или еще что-нибудь.
            // 
            // Но я делать этого не буду - побочная функциональность для выполнения задания и так зашкаливает.
            // А перерисовка самой области уже параметризована на значения смещения, то есть на событие Paint
            // прорисовка новой области будет произведена корректно.
        }
        // ****************************************************************************************
        
        // ****************************************************************************************
        #region Новый вариант прорисовки панели, с использованием двойной буфферизации
        // ****************************************************************************************
        override public void panelPaint (Graphics panelCanvasGraph)
        {
            drawBkBitmap (graphfObj_for_bkGround);
            panelCanvasGraph.DrawImage(this.bkGround, 0, 0);// весь битмап копируем на всю панель. 
        }

        public void drawBkBitmap(Graphics canvasGraph)
        {
            int columnIdx;
            int rowIdx;

            for (rowIdx = 0; rowIdx < rowCount; rowIdx++)
            {
                List<DeskCell> row = Program.app.getDesk().cellTable[rowIdx + idxRowsOffset];

                for (columnIdx = 0; columnIdx < colCount; columnIdx++)
                {
                    // нашли ячейку Desk-поля, соотвествующую ячеке на экране (панели) где собрались рисовать
                    DeskCell cell = row[columnIdx + idxColsOffset];

                    int idxX = columnIdx + idxColsOffset;
                    int idxY = rowIdx + idxRowsOffset;

                    cell.paint(canvasGraph, cellPainter, columnIdx, rowIdx);
                }
            }
        }
        // ****************************************************************************************
        #endregion
        // ****************************************************************************************
    }
}
