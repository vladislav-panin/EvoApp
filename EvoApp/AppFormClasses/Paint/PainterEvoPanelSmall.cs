using System.Drawing;

namespace EvoApp
{
    // Логика и реализация отрисовки маленькой панели Эволюции
    //
    // функциональность здесь небольшая - реализация отрисовки положения индикатора положения
    // области большой панели на общей схеме доски Эволюции. Реализовано с использованием двойной буферизации
    //
    public class PainterEvoPanelSmall : PainterBase
    {
        int colBigPanel = 0; // количество колонок в большой панели, нужно для вычисления положения красного индикатора
        int rowBigPanel = 0; // количество строк в большой панели, нужно для вычисления положения красного индикатора

        double oneColWidthPx; // количество ячеек по ширине в одном пикселе малой панели
        double oneRowHeightPx;  // количество ячеек по высоте в одном пикселе малой панели

        int widthAreaPx;  // ширина малой панели в пикселях
        int heightAreaPx; // высота малой панели в пикселях

        SolidBrush indicatorBbrush = null;
        Rectangle indicatorRect = new Rectangle (0, 0, 0, 0);

        // bkGround - здесь буду использовать под карта Эволюции без индикатора
        private Bitmap   bkGround_dblBuff = null; // карта мира с индикатором
        private Graphics graphObj_dblBuff = null;

        // **************************************************************************************************        
        public PainterEvoPanelSmall() {
        }

        // **************************************************************************************************
        // int widthPx, heightPx  - ширина и высота (в пикселях) панели, на которой буду рисовать
        override public void InitDimensions (int widthPx, int heightPx)
        {
            base.InitDimensions (widthPx, heightPx);

            this.oneColWidthPx = (double)widthPx / (double)Program.app.getDesk().geoEx.colCount;
            this.oneRowHeightPx = (double)heightPx / (double)Program.app.getDesk().geoEx.rowCount;

            this.colBigPanel = PainterEvoPanelBig.colCount;
            this.rowBigPanel = PainterEvoPanelBig.rowCount;

            this.widthAreaPx = (int)(oneColWidthPx * this.colBigPanel);
            this.heightAreaPx = (int)(oneRowHeightPx * this.rowBigPanel);
        }

        // **************************************************************************************************
        override protected void InitBitmaps()
        {
            this.bkGround = Program.app.getDesk().geoEx.ResizeBitmap(Program.app.getDesk().geoEx.etalonMap, this.widthPx, this.heightPx);
            this.graphfObj = Graphics.FromImage(this.bkGround);

            this.bkGround_dblBuff = new Bitmap(bkGround);
            this.graphObj_dblBuff = Graphics.FromImage(this.bkGround_dblBuff);

            this.indicatorRect.X = 0;
            this.indicatorRect.Y = 0;
            this.indicatorRect.Width = this.widthAreaPx;
            this.indicatorRect.Height = this.heightAreaPx;

            this.indicatorBbrush = new SolidBrush(Color.Red);
            this.graphObj_dblBuff.FillRectangle(this.indicatorBbrush, this.indicatorRect);
        }

        // **************************************************************************************************
        // canvasGraph - это Graphics панели, на которой рисуем по событию Paint этой панели
        override public void panelPaint(Graphics panelCanvasGraph)
        {
            // весь битмап копируем на всю панель. 
            panelCanvasGraph.DrawImage(this.bkGround_dblBuff, 0, 0);
        }

        // **************************************************************************************************
        /*  Подробная область мира (ПОМ) (отображаемая на большой панели) сдвинулось на новое место.
            В полях this.idxColOffset и this.idxRowOffset -  уже установлены новые индексы смещения 
         
            Теперь ячейка левого верхнего угла области ПОМ, имеет индекс [this.idxColsOffset, this.idxRowsOffset]

            Маленькая панель - это карта всего мира, на котором красным квадратиком отмечаем положение области ПОМ,
            и эта картинка хранится в битмапе bkGround_withScreenIndicator.
            Значит, теперь этот битмап нужно перерисовать - это и делаем здесь
        */
        override public void recalcOnOffsetChanged()
        {
            // считаем смещение в пикселях на панели
            int xOrigin = (int)(((double)this.idxColOffset) * this.oneColWidthPx);
            int yOrigin = (int)(((double)this.idxRowOffset) * this.oneRowHeightPx);

            // ширину и высоту индикатора не присваиваем, они прежними, изменилась только точка, откуда рисуем прямоугольник
            this.indicatorRect.X = xOrigin;
            this.indicatorRect.Y = yOrigin;

            this.graphObj_dblBuff.DrawImage(bkGround, 0, 0); // Копируем карту мира без индикатора на битмап с индикатором
            this.graphObj_dblBuff.FillRectangle(this.indicatorBbrush, this.indicatorRect); // заливаем индикатор
        }
        // **************************************************************************************************
    }
}
