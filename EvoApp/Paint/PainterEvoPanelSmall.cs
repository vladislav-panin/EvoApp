using System.Drawing;

namespace EvoApp
{
    public class PainterEvoPanelSmall : PainterBase
    {
        int rowsBigPanel = 0;
        int colsBigPanel = 0;

        double oneColWidthPx;
        double oneRowHeightPx;

        int widthAreaPx;
        int heightAreaPx;

        SolidBrush indicatorBbrush = null;
        Rectangle indicatorRect = new Rectangle (0, 0, 0, 0);

        // bkGround - здесь буду использовать под карта мира без индикатора
        private Bitmap bkGround_withScreenIndicator = null; // карта мира с индикатором
        private Graphics graphObj_for_bkGround_withScreenIndicator = null;

        // **************************************************************************************************        
        public PainterEvoPanelSmall()
        {
        }

        // **************************************************************************************************
        // int widthPx, heightPx  - ширина и высота (в пикселях) панели, на которой буду рисовать
        override public void InitDimensions (int widthPx, int heightPx)
        {
            base.InitDimensions (widthPx, heightPx);

            this.oneColWidthPx = (double)widthPx / (double)Program.app.getDesk().geoEx.colCount;
            this.oneRowHeightPx = (double)heightPx / (double)Program.app.getDesk().geoEx.rowCount;

            this.colsBigPanel = PainterEvoPanelBig.colCount;
            this.rowsBigPanel = PainterEvoPanelBig.rowCount;

            this.widthAreaPx = (int)(oneColWidthPx * this.colsBigPanel);
            this.heightAreaPx = (int)(oneRowHeightPx * this.rowsBigPanel);
        }

        // **************************************************************************************************
        override protected void InitBitmaps()
        {
            this.bkGround = Program.app.getDesk().geoEx.ResizeBitmap(Program.app.getDesk().geoEx.etalonMap, this.widthPx, this.heightPx);
            this.graphfObj_for_bkGround = Graphics.FromImage(this.bkGround);

            this.bkGround_withScreenIndicator = new Bitmap(bkGround);
            this.graphObj_for_bkGround_withScreenIndicator = Graphics.FromImage(this.bkGround_withScreenIndicator);

            this.indicatorRect.X = 0;
            this.indicatorRect.Y = 0;
            this.indicatorRect.Width = this.widthAreaPx;
            this.indicatorRect.Height = this.heightAreaPx;

            this.indicatorBbrush = new SolidBrush(Color.Red);
            this.graphObj_for_bkGround_withScreenIndicator.FillRectangle(this.indicatorBbrush, this.indicatorRect);
        }

        // **************************************************************************************************
        // canvasGraph - это Graphics панели, на которой рисуем по событию Paint этой панели
        override public void panelPaint(Graphics panelCanvasGraph)
        {
            // весь битмап копируем на всю панель. 
            panelCanvasGraph.DrawImage(this.bkGround_withScreenIndicator, 0, 0);
        }

        // **************************************************************************************************
        /*  Подробная область мира (ПОМ) (отображаемая на большой панели) сдвинулось на новое место.
            В полях this.idxColsOffset и this.idxRowsOffset -  уже установлены новые индексы смещения 
         
            Теперь ячейка левого верхнего угла области ПОМ, имеет индекс [this.idxColsOffset, this.idxRowsOffset]

            Маленькая панель - это карта всего мира, на котором красным квадратиком отмечаем положение области ПОМ,
            и эта картинка хранится в битмапе bkGround_withScreenIndicator.
            Значит, теперь этот битмап нужно перерисовать - это и делаем здесь
        */
        override public void offsetCanged ()        
        {
            // считаем смещение в пикселях на панели
            int xOrigin = (int)( ((double)this.idxColsOffset) * this.oneColWidthPx); 
            int yOrigin = (int)( ((double)this.idxRowsOffset) * this.oneRowHeightPx);

            // ширину и высоту индикатора не присваиваем, они прежними, изменилась только точка, откуда рисуем прямоугольник
            this.indicatorRect.X = xOrigin;
            this.indicatorRect.Y = yOrigin;

            this.graphObj_for_bkGround_withScreenIndicator.DrawImage(bkGround, 0, 0); // Копируем карту мира без индикатора на битмап с индикатором
            this.graphObj_for_bkGround_withScreenIndicator.FillRectangle(this.indicatorBbrush, this.indicatorRect); // заливаем индикатор
        }
        // **************************************************************************************************
    }
}
