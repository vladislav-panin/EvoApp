using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class PainterSmallEvoPanel
    {
        int widthPx = -1;  // ширина панели в пикселях
        int heightPx = -1; // высота панели в пикселях

        int rowsCountInBigPainter = -1; // количество строк на панели BigEvoPanel
        int colsCountInBigPainter = -1; // количество колонок на панели BigEvoPanel

        double oneColWidthPx = -1.0f; // ширина колонки в пикселях на маленькой панели игры. Сильно меньше еденицы, поэтому double
        double oneRowHeightPx = -1.0d; // высота  колонки в пикселях на маленькой панели игры. Сильно меньше еденицы, поэтому double

        int widthBigPanelAreaPx; // ширина в пикселях большой панели игры
        int heightBigPanelAreaPx; // высота в пикселях большой панели игры

        GeoEx geoEx;

        Pen pen;
        SolidBrush brush;

        private Bitmap bkGround = null;
        private Bitmap bkGround_withScreenIndicator = null;

        // **************************************************************************************************

        public PainterSmallEvoPanel()
        {

        }

        // **************************************************************************************************
        public void Init(int widthPx, int heightPx)
        {
            this.geoEx = Program.app.desk.geoEx;

            this.widthPx = widthPx;
            this.heightPx = heightPx;

            this.oneColWidthPx = (double)widthPx / (double)geoEx.colCount;
            this.oneRowHeightPx = (double)heightPx / (double)geoEx.rowCount;

            this.colsCountInBigPainter = PainterBigEvoPanel.colCount;
            this.rowsCountInBigPainter = PainterBigEvoPanel.rowCount;

            this.widthBigPanelAreaPx = (int)(oneColWidthPx * this.colsCountInBigPainter);
            this.heightBigPanelAreaPx = (int)(oneRowHeightPx * this.rowsCountInBigPainter);

            MakeBitmaps();
        }

        // **************************************************************************************************
        private void MakeBitmaps()
        {
            bkGround = this.geoEx.ResizeBitmap(this.geoEx.etalonMap, this.widthPx, this.heightPx);

            // --------------
            bkGround_withScreenIndicator = new Bitmap(bkGround);
            Graphics graphObj = Graphics.FromImage(bkGround_withScreenIndicator);

            Rectangle rect = new Rectangle(0, 0, this.widthBigPanelAreaPx, this.heightBigPanelAreaPx);

            SolidBrush brush = new SolidBrush(Color.Red);
            graphObj.FillRectangle(brush, rect);

            //pen = new Pen(Color.Red);
            //graphObj.DrawRectangle(pen, rect);
        }

        // **************************************************************************************************
        public void panelPaint(Graphics canvasGraph)
        {
            canvasGraph.DrawImage(bkGround_withScreenIndicator, 0, 0);
        }

        // **************************************************************************************************
        public void setScreenIndicator (int xColsOffset, int yRowsOffset)
        {
            bkGround_withScreenIndicator.Dispose();
            bkGround_withScreenIndicator = new Bitmap(bkGround);

            int xOrigin = (int)((double)xColsOffset * this.oneColWidthPx);
            int yOrigin = (int)((double)yRowsOffset * this.oneRowHeightPx);

            Graphics graphObj = Graphics.FromImage(bkGround_withScreenIndicator);
            Rectangle rect = new Rectangle(xOrigin, yOrigin, this.widthBigPanelAreaPx, this.heightBigPanelAreaPx);

            brush = new SolidBrush(Color.Red);
            graphObj.FillRectangle(brush, rect);

            //pen = new Pen(Color.Red);
            //graphObj.DrawRectangle(pen, rect);
        }

        // **************************************************************************************************
    }
}
