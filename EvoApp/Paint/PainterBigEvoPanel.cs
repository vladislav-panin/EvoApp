using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    public class PainterBigEvoPanel
    {
        public static int colCount { get; }  = 20;  // количество столбцов (то есть ячеек в ширину) на большой панели
        public static int rowCount { get; } = 20;  // количество строк (то есть ячеек в высоту) на большой панели

        public int paintInterval { get; set; } = 1000; // интервал прорисовки большой панели 200 миллисекунд (то есть 5 раз в секунду)

        public int hSlider_xTickCount { get; set; } = -1; // максимальное положение горизонтального слайдера, минимальное выставляем в 0 на форме
        public int vSlider_yTickCount { get; set; } = -1; // максимальное положение вертикального слайдера, минимальное выставляем в 0 на форме

        // *******************************************************************************************************************************
        // *******************************************************************************************************************************

        public Graphics grafObj;  //  графический объект — некий холст
        public Bitmap buf;      //  буфер для Bitmap-изображения

        Desk gameDesk = null;
        DrawCell drawCell = new DrawCell();

        int cellWidthPx { get; set; }
        int cellHeightPx { get; set; }

        protected Invertor invertor = null;

        private int idxColsOffset = 0;
        private int idxRowsOffset = 0;

        public int hSlider_Val; // текущее положение горизонтального слайдера, при старте приложения равно 0  
        public int vSlider_Val; // текущее положение вертикального слайдера, при старте приложения равно 0  

        public int VSlider_Val
        {
            get
            {
                return vSlider_Val;
            }
            set
            {
                vSlider_Val = value;
                invertor.Set(vSlider_Val);
                idxRowsOffset = invertor.Val() * colCount;
            }
        }
        public int HSlider_Val
        {
            get
            {
                return hSlider_Val;
            }
            set
            {
                hSlider_Val = value;
                idxColsOffset = hSlider_Val * rowCount;
            }
        }


        public int getIdxColsOffset()
        {
            return idxColsOffset;
        }
        public int getIdxRowsOffset ()
        {
            return idxRowsOffset;
        }

        // ****************************************************************************************
        public String GetOffsetString ()
        {
            String ret = "(" + idxColsOffset + "; " + idxRowsOffset + ")";
            return ret;
        }

        public void SwitchShowGrid(bool isChecked)
        {
            drawCell.isGridRequired = isChecked;
        }

        public void SwitchShowCoo (bool isChecked)
        {
            drawCell.isCoodRequired= isChecked;
        }

        // ****************************************************************************************
        // ****************************************************************************************
        // int widthPx  - ширина (в пикселях) большой панели, на которой рисую эволюцию
        // int heightPx - высота (в пикселях) большой панели, на которой рисую эволюцию
        public void Init(int widthPx, int heightPx)
        {
            this.cellWidthPx = widthPx / colCount;
            this.cellHeightPx = heightPx / rowCount;

            gameDesk = Program.app.desk;

            this.hSlider_xTickCount = (Program.app.desk.geoEx.colCount / PainterBigEvoPanel.colCount);
            this.vSlider_yTickCount = (Program.app.desk.geoEx.rowCount / PainterBigEvoPanel.rowCount);

            this.invertor = new Invertor(0, this.vSlider_yTickCount - 1, this.vSlider_yTickCount - 1);
        }
        // ****************************************************************************************
        // ****************************************************************************************
        static int counter_panelPaint = 0;
        // **************************** //
        public void panelPaint(Graphics canvasGraph)
        {
            panelPaint_OLD (canvasGraph);
            // panelPaint_NEW(canvasGraph);
        }

        // ****************************************************************************************
        public void panelPaint_NEW (Graphics canvasGraph)
        {
            counter_panelPaint++;
            int columnIdx;
            int rowIdx;

            for (rowIdx = 0; rowIdx < rowCount; rowIdx++)
            {
                List<DeskCell> row = gameDesk.cellTable[rowIdx + idxRowsOffset];
                for (columnIdx = 0; columnIdx < colCount; columnIdx++)
                {
                    // нашли ячейку Desk-поля, соотвествующую ячеке на экране (панели) где собрались рисовать
                    DeskCell cell = row[columnIdx + idxColsOffset];
                    //cell.paint(canvasGraph);
                }
            }
        }
        
        // ****************************************************************************************
        public void panelPaint_OLD (Graphics canvasGraph)
        {
            counter_panelPaint++;
            int columnIdx;
            int rowIdx;

            for (rowIdx = 0; rowIdx < rowCount; rowIdx++)
            {
                List<DeskCell> row = gameDesk.cellTable[rowIdx + idxRowsOffset];                
                for (columnIdx = 0; columnIdx < colCount; columnIdx++)
                {
                    // нашли ячейку Desk-поля, соотвествующую ячеке на экране (панели) где собрались рисовать
                    DeskCell cell = row[columnIdx + idxColsOffset];  
                    this.paintCell(canvasGraph, cell, columnIdx, rowIdx);
                }
             }
        }       
        // ****************************************************************************************
        public void paintCell(Graphics canvasGraph, DeskCell cell, int screenCell_idxX, int screenCell_idxY)
        {
            String sign = cell.cooIdxsTxt;

            int originX = screenCell_idxX * this.cellWidthPx;
            int originY = screenCell_idxY * this.cellHeightPx;

            /*
            Console.WriteLine("** " + counter_panelPaint + " * " +

                "origin = (" + idxColsOffset     +  ", "     + idxRowsOffset + ") *** " +
                ">> ---   (" + screenCell_idxX  +  ", "     + screenCell_idxY + ")"  + 
                " ***  X = " + originX          +  "; Y = " + originY);
            */
            drawCell.paintCell(canvasGraph, originX, originY, this.cellWidthPx, this.cellHeightPx);
            drawCell.signCell (canvasGraph, sign, originX, originY);
        }
        // ****************************************************************************************
    }
}
