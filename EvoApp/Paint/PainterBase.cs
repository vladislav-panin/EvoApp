﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    abstract public class PainterBase
    {
        // здесь, по крайней мере, должен быть созданы bkGround и graphfObj_for_bkGround
        abstract protected void InitBitmaps();

        // canvasGraph - это Graphics панели, на которой рисуем по событию Paint этой панели
        abstract public void panelPaint(Graphics canvasGraph);

        // команда привести в соотвествие с новым смещением поля класса, - здесь перерисовать битмапы и т.д.
        abstract public void offsetCanged();

        // *******************************************************************************************************************************        
        public int cellWidthPx { get; set; }
        public int cellHeightPx { get; set; }

        static public int colCount { get; } = 20;  // количество столбцов (то есть ячеек в ширину) на большой панели
        static public int rowCount { get; } = 20;  // количество строк (то есть ячеек в высоту) на большой панели

        public int widthPx { get; set; } = 0;  // ширина (в пикселях) панели, на которой буду рисовать
        public int heightPx { get; set; } = 0; // высота (в пикселях) панели, на которой буду рисовать

        public int paintInterval { get; set; } = 1000; // интервал прорисовки большой панели 200 миллисекунд (то есть 5 раз в секунду)

        public int hSlider_xTickCount { get; set; } = -1; // max положение горизонтального слайдера, минимальное выставляем в 0 на форме
        public int vSlider_yTickCount { get; set; } = -1; // max положение вертикального слайдера, минимальное выставляем в 0 на форме
        // *******************************************************************************************************************************        

        protected Desk gameDesk { get; set; } = null;
        protected GeoEx geoEx { get; set; } = null;

        public Bitmap bkGround = null;   //  буфер для Bitmap-изображения
        public Graphics graphfObj_for_bkGround = null;  //  холст, который умеет рисовать на bkGround

        protected Invertor invertor = null;

        // значения idxColsOffset и idxRowsOffset устанавливаются сейчас только при смещении слайдера
        // поэтому я зашил их изменение в методы set() полей-свойств VSlider_Val и HSlider_Val
        //
        protected int idxColsOffset = -1; // X-смещение области, рисуемой на panelEvoBig (количество ячеек, на которое нужно сместится)
        protected int idxRowsOffset = -1; // Y-смещение области, рисуемой на panelEvoBig (количество ячеек, на которое нужно сместится)

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

                offsetCanged(); 
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

                offsetCanged();
            }
        }

        // *****************************************************************************************************************
        // int widthPx, heightPx  - ширина и высота (в пикселях) панели, на которой буду рисовать
        virtual public void Init(int cellWidthPx, int cellHeightPx)
        {
            this.gameDesk = Program.app.desk;
            this.geoEx = Program.app.desk.geoEx;

            InitDimensions(cellWidthPx, cellHeightPx);
            InitBitmaps();
        }

        virtual public void InitDimensions (int cellWidthPx, int cellHeightPx)
        {
            this.widthPx = cellWidthPx;
            this.heightPx = cellHeightPx;

            this.cellWidthPx = cellWidthPx / colCount;
            this.cellHeightPx = cellHeightPx / rowCount;

            this.hSlider_xTickCount = (Program.app.desk.geoEx.colCount / PainterBigEvoPanel.colCount);
            this.vSlider_yTickCount = (Program.app.desk.geoEx.rowCount / PainterBigEvoPanel.rowCount);

            this.invertor = new Invertor(0, this.vSlider_yTickCount - 1, this.vSlider_yTickCount - 1);
        }

        // *****************************************************************************************************************
        virtual public String GetOffsetString()
        {
            String ret = "(" + idxColsOffset + "; " + idxRowsOffset + ")";
            return ret;
        }
        // *****************************************************************************************************************
    }
}