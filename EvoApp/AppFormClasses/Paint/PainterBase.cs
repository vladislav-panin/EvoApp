using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    // Базоый класс с базовой логикой и реализацией поведения и отрисовки большой и малой панелей.
    //
    // Инициализация вызвается из конструктора главной формы
    // При инициализации создаются битмапы, которые будут скопированы на канву панелей главной формы (рнеализация двойной буферизации)
    // 
    // Виртуальная функция классов наследников PainterBase - реализация отрисовки фонового буфера по событию главной формы Paint
    // Идея реализации этой функции - предоставить оригинальный (чистый) битмап для отрисовки каждой из ячеек (будут вызваны методы
    // отрисовки экземпляра класса DeskCell, который знает как отрисовывать себя на куске битмапа, координаты которого ему передали.
    // Это более удобный способ реализации отрисовки юнитов, поскольку в ячейке хранится вся информация об обитателях и географии ячейки)
    //
    abstract public class PainterBase
    {
        abstract public void recalcOnOffsetChanged();

        // здесь, по крайней мере, должен быть созданы bkGround и graphfObj_for_bkGround
        abstract protected void InitBitmaps();

        // canvasGraph - это Graphics панели, на которой рисуем по событию Paint этой панели
        abstract public void panelPaint(Graphics canvasGraph);

        // *******************************************************************************************************************************        
        public int cellWidthPx { get; set; }
        public int cellHeightPx { get; set; }

        protected int deskColCountMaxIdx = 0; // максимальный индекс колонки на доске Эволюции (999)
        protected int deskRowCountMaxIdx = 0; // максимальный индекс строки на доске Эволюции (999)

        protected int maxColOffset = 0;
        protected int maxRowOffset = 0;

        static public int colCount { get; } = 10;  // количество столбцов (то есть ячеек в ширину) на большой панели. Количество колонок на Desk должно быть кратным colCount
        static public int rowCount { get; } = 10;  // количество строк (то есть ячеек в высоту) на большой панели. Количество строк на Desk должно быть кратным rowCount

        public int widthPx { get; set; } = 0;  // ширина (в пикселях) панели, на которой буду рисовать
        public int heightPx { get; set; } = 0; // высота (в пикселях) панели, на которой буду рисовать

        public int timerPaintInterval { get; set; } = 250; // интервал прорисовки большой панели 250 миллисекунд (то есть 4 раза в секунду)

        public int hSlider_xTickCount { get; set; } = -1; // max положение горизонтального слайдера, минимальное выставляем в 0 на форме
        public int vSlider_yTickCount { get; set; } = -1; // max положение вертикального слайдера, минимальное выставляем в 0 на форме
        // *******************************************************************************************************************************        

        public Bitmap   bkGround = null;   //  буфер для Bitmap-изображения
        public Graphics graphfObj = null;  //  холст, который умеет рисовать на bkGround

        protected Invertor invertor = null;

        // значения idxColOffset и idxRowOffset устанавливаются сейчас только при смещении слайдера
        // поэтому я зашил их изменение в методы set() полей-свойств VSlider_Val и HSlider_Val
        //
        protected int idxColOffset = -1; // X-смещение области, рисуемой на panelEvoBig (количество ячеек, на которое нужно сместится). Максимальное значение 990 при количестве столбцов 10 на большой панели 
        protected int idxRowOffset = -1; // Y-смещение области, рисуемой на panelEvoBig (количество ячеек, на которое нужно сместится). Максимальное значение 990 при количестве строк 10 на большой панели 

        protected int idxColSmallManualShift = 0; // X-смещение  отноcительно idxColOffset, регулируемое кнопками управления "влево / вправо". Где idxColsOffset устанавливается слайдером
        protected int idxRowSmallManualShift = 0; // Y-смещение  отноcительно idxRowOffset, регулируемое кнопками управления "вверх / вниз". Где idxRowsOffset устанавливается слайдером

        public int hSlider_Val; // текущее положение горизонтального слайдера, при старте приложения равно 0  
        public int vSlider_Val; // текущее положение вертикального слайдера, при старте установливаю в 0, и только после иницализации Desk устанавливаю значение в vSlider.Maximum  

        public int VSlider_Val
        {
            get {
                return vSlider_Val;
            }
            set {
                vSlider_Val = value;
                invertor.Set(vSlider_Val);
                idxRowOffset = invertor.Val() * rowCount;

                offsetChanged(); 
            }
        }
        public int HSlider_Val
        {
            get {
                return hSlider_Val;
            }
            set {
                hSlider_Val = value;
                idxColOffset = hSlider_Val * colCount;

                offsetChanged();
            }
        }

        // *****************************************************************************************************************
        // int widthPx, heightPx  - ширина и высота (в пикселях) панели, на которой буду рисовать
        virtual public void Init(int cellWidthPx, int cellHeightPx)
        {
            deskColCountMaxIdx = Program.app.getDesk().geoEx.colCount - 1;
            deskRowCountMaxIdx = Program.app.getDesk().geoEx.rowCount - 1;

            maxColOffset = (deskColCountMaxIdx + 1) - colCount;
            maxRowOffset = (deskRowCountMaxIdx + 1) - rowCount;

            InitDimensions(cellWidthPx, cellHeightPx);
            InitBitmaps();
        }

        virtual public void InitDimensions (int cellWidthPx, int cellHeightPx)
        {
            this.widthPx = cellWidthPx;
            this.heightPx = cellHeightPx;

            this.cellWidthPx = cellWidthPx / colCount;
            this.cellHeightPx = cellHeightPx / rowCount;

            this.hSlider_xTickCount = (Program.app.getDesk().geoEx.colCount / PainterEvoPanelBig.colCount);
            this.vSlider_yTickCount = (Program.app.getDesk().geoEx.rowCount / PainterEvoPanelBig.rowCount);

            this.invertor = new Invertor(0, this.vSlider_yTickCount - 1, this.vSlider_yTickCount - 1);
        }

        // *****************************************************************************************************************
        virtual public String GetOffsetString() {

            String ret = "(" + (idxColOffset + idxColSmallManualShift) + "; " + (idxRowOffset + idxRowSmallManualShift) + ")";
            return ret;
        }
        // *****************************************************************************************************************
        public void offsetChanged()
        {
            idxColSmallManualShift = 0;
            idxRowSmallManualShift = 0;

            recalcOnOffsetChanged();            
        }
        // *****************************************************************************************************************
        // уменьшить смещение idxColSmallManualShift на единицу
        public int ManualShift_X_incr()
        {
            idxColSmallManualShift++;
            recalcManualShift_X();

            return idxColSmallManualShift;
        }
        // уменьшить смещение idxColSmallManualShift на единицу
        public int ManualShift_X_decr()
        {
            idxColSmallManualShift--;
            recalcManualShift_X();

            return idxColSmallManualShift;
        }
        // увеличить смещение idxRowSmallManualShiftна единицу
        public int ManualShift_Y_incr()
        {
            idxRowSmallManualShift++;
            recalcManualShift_Y();

            return idxRowSmallManualShift;
        }
        // уменьшить смещение idxRowSmallManualShift на единицу
        public int ManualShift_Y_decr()
        {
            idxRowSmallManualShift--;
            recalcManualShift_Y();

            return idxRowSmallManualShift;
        }
        // ****************************************************************************************
        protected void recalcManualShift_X()
        {
            if ((-PainterBase.colCount) >= idxColSmallManualShift)
            {   // если пролистали влево вручную целую страничку

                idxColSmallManualShift = 0;
                idxColOffset -= PainterBase.colCount;

                if (idxColOffset < 0)
                    idxColOffset = 0;

                hSlider_Val = idxColOffset / colCount;
                return;
            }

            if (idxColSmallManualShift >= PainterBase.colCount)
            {   // если пролистали вправо вручную целую страничку

                idxColSmallManualShift = 0;
                idxColOffset += PainterBase.colCount;

                if (idxColOffset > maxColOffset)
                    idxColOffset = maxColOffset;

                hSlider_Val = idxColOffset / colCount;
                return;
            }

            if (0 > idxColSmallManualShift)
            {
                // если просто решили листнуть влево - нужно проверить, и еcли сейчас находимся на самой левой странице - то дальше
                // листать нельзя, а idxColSmallManualShift нужно обнулить
                if (idxColOffset == 0)
                {
                    idxColSmallManualShift = 0;
                    return;
                }
            }

            if (idxColSmallManualShift > 0)
            {
                // если просто решили листнуть право - нужно проверить, и еcли сейчас находимся на самой правой странице - то дальше
                // листать нельзя, а idxColSmallManualShift нужно обнулить
                if (idxColOffset == maxColOffset)
                {
                    idxColSmallManualShift = 0;
                    return;
                }
            }
        }
        // ****************************************************************************************
        protected void recalcManualShift_Y()
        {
            if ((-PainterBase.rowCount) >= idxRowSmallManualShift)
            {   // если пролистали вверх вручную целую страничку

                idxRowSmallManualShift = 0;
                idxRowOffset -= PainterBase.rowCount;

                if (idxRowOffset < 0)
                    idxRowOffset = 0;

                int inverted = idxRowOffset / rowCount;
                invertor.Set(inverted);
                vSlider_Val = invertor.Val();

                return;
            }

            if (idxRowSmallManualShift >= PainterBase.rowCount)
            {   // если пролистали вниз вручную целую страничку

                idxRowSmallManualShift = 0;
                idxRowOffset += PainterBase.rowCount;

                if (idxRowOffset > maxRowOffset)
                    idxRowOffset = maxRowOffset;

                int inverted = idxRowOffset / rowCount;
                invertor.Set(inverted);
                vSlider_Val = invertor.Val();

                return;
            }

            if (0 > idxRowSmallManualShift)
            {
                // если просто решили листнуть вверх - нужно проверить, и еcли сейчас находимся на самой верхней странице - то дальше
                // листать нельзя, а idxRowSmallManualShift нужно обнулить
                if (idxRowOffset == 0)
                {
                    idxRowSmallManualShift = 0;
                    return;
                }
            }

            if (idxRowSmallManualShift > 0)
            {
                // если просто решили листнуть вниз - нужно проверить, и еcли сейчас находимся на самой нижней странице - то дальше
                // листать нельзя, а idxRowSmallManualShift нужно обнулить
                if (idxRowOffset == maxRowOffset)
                {
                    idxRowSmallManualShift = 0;
                    return;
                }
            }

        }
        // *****************************************************************************************************************
        public void SetNewBigPanelOrigin(Point newOrigin)
        { 

        }
        // *****************************************************************************************************************
    }
}
