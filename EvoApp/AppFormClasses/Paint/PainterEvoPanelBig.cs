using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    // Логика и реализация отрисовки большой панели Эволюции
    //
    // Инициализация вызвается из конструктора главной формы
    // При инициализации создается битмап, который будут скопирован на канву панелей главной формы (рнеализация двойной буферизации)
    // 
    // Виртуальный метод Paint() реализует отрисовку фонового буфера по событию главной формы Paint
    // Метод предоставляет оригинальный (чистый) битмап для отрисовки каждой из ячеек, вызывая метод paint() ячеек доски,
    // отображаемых на большой панели. Ячейки хранят всю информацию о своих обитателях и геометрии, поэтому логично предоставить им отрисовку 
    // самих себя
    public class PainterEvoPanelBig: PainterBase
    {
        static public bool isGridRequired { get; set; } = false;  // нужна ли отрисовка сетки ячеек
        static public bool isCoordRequired  { get; set; } = false; // нужна ли отрисовка координат ячеек

        static public CellPainter cellPainter { get; set; } = null;  // экземпляр пайнтера, умеющего отрисовать ячейки.

        // ****************************************************************************************
        override public void Init(int cellWidthPx, int cellHeightPx) {

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
            this.graphfObj = Graphics.FromImage(this.bkGround);

            PainterEvoPanelBig.cellPainter = new CellPainter();
        }

        // ****************************************************************************************
        override public void recalcOnOffsetChanged()
        {            
        }
        // ****************************************************************************************
        
        override public void panelPaint (Graphics panelCanvasGraph) {

            drawBgBitmap (graphfObj);
            panelCanvasGraph.DrawImage(this.bkGround, 0, 0);// весь битмап копируем на всю панель. 
        }

        public void drawBgBitmap(Graphics canvasGraph)
        {
            int idxGlobalX;
            int idxGlobalY;

            for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
            {
                idxGlobalY = get_Y_globalOffset(rowIdx);
                List<DeskCell> row = Program.app.getDesk().cellTable[rowIdx + idxRowOffset + idxRowSmallManualShift];

                for (int columnIdx = 0; columnIdx < colCount; columnIdx++)
                {
                    idxGlobalX = get_X_globalOffset(columnIdx);

                    DeskCell cell = row[idxGlobalX]; // ячейка Desk-поля, соотвествующую ячеке на экране (панели) где собрались рисовать
                    cell.paint(canvasGraph, cellPainter, columnIdx, rowIdx);
                }
            }
        }

        // ****************************************************************************************        
        protected int get_X_globalOffset(int columnIdx) 
        {
            int gOffsetX = columnIdx + idxColOffset + idxColSmallManualShift;
            return gOffsetX;
        }

        protected int get_Y_globalOffset(int rowIdx)
        {
            int gOffsetY = rowIdx + idxRowOffset + idxRowSmallManualShift;
            return gOffsetY;
        }
        // ****************************************************************************************        
    }
}
