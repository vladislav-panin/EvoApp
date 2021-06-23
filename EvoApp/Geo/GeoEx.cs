using System.Drawing;

namespace EvoApp
{
    /* Поле программы - квадрат, размером [rowCount * colCount]
    Все вычисления параметризованы размерами поля (rowCount и colCount), и размерами областей ланшафта
    
    По краям квадрата:
      сверху и снизу - полосы соленого моря
      слева и справа - полосы гор
    В оставшееся пространство вписан элипс, пространство от элипс до моря и гор (т.е. на внешней стороне круга) - песок.
    Внутри элипс - трава, в центре круга - озеро , вокруг которого полоса леса.
    
    Рисовать буду так
       0) делаю подложку - заливаю песком все поле программы (прямоугольник)
       1) вдоль сторон поля программы рисую море и горы
       2) 
       3) рисую круг, вписанный в прямоугольник 2, середину заливаю травой
       4) по центру рисую круг леса
       5) по центру рисую круг озера меньшего диаметра, чем лес

    В пункте 2), между морем+горы и травой останется подложка - песок
    
    Рисовать буду на битмапе в памяти размером [rowCount * colCount] пикселей.
    Такой алгоритм прорисовки можно реализовать, используя только четыре дополнительных параметра геометрии - ширину полосы моря, ширину
    полосы гор, радиусы леса и озера.
    
    Полученный битмап использую для того, что бы:
       1) скопировать уменьшенную копию на маленькую карту-индикатор на левой панели
       2) инициировать ландшафт на доске эволюции - то есть пройдусь по битмапу и в соответствии с цветом пикселя, установлю ландшафт в ячейку
    
       Поскольку количество строк и столбцов битмапа и доски эволюции совпадают - соответствие цвета на битмапе и доске эволюции будет точным,
       и маленькая карта-индикатор будет передавать уменьшенную копию реальной доски эволюции.
    */
    public class GeoEx
    {        
        public int rowCount { get; } = 1000; // количество строк (ячеек всей игры) на поле программы 
        public int colCount { get; } = 1000; // количество столбцов(ячеек всей игры) на поле программы 


        public int widthSea       { get; set; } = 50; // ширина полосы моря
        public int widthMountains { get; set; } = 50; // ширина полосы гор
        public int widthLake      { get; set; } = 200; // радиус озера
        public int widthWood      { get; set; } = 300; // радиус леса

        public Bitmap etalonMap { get; set; } 
        public Graphics grafObj { get; set; }

        public GeoEx()
        {
            etalonMap = new Bitmap(rowCount, colCount);
            grafObj = Graphics.FromImage(etalonMap);
        }

        // ****************************************************************************************
        public void Init ()
        {
            Draw();
        }
        // ****************************************************************************************
        protected void Draw()        
        {
            DrawDesert();

            DrawSea();
            DrawMountains();
            DrawGrass();
            DrawWood();
            DrawLake();
        }

        // ****************************************************************************************
        // ****************************************************************************************
        protected void DrawDesert()
        {
            Rectangle rect = new Rectangle (0, 0, colCount, rowCount);
            SolidBrush brush = new SolidBrush(Lands.Desert.color);

            grafObj.FillRectangle (brush, rect);
        }

        // ****************************************************************************************
        protected void DrawSea()
        {
            Point[] topSeePoints = 
            { 
                new Point(0,                   0), 
                new Point(colCount,            0), 
                new Point(colCount - widthSea, widthSea),
                new Point(widthSea,            widthSea)
            };

            Point[] bottomSeePoints =
            {
                new Point(0,                   rowCount),
                new Point(colCount,            rowCount),
                new Point(colCount - widthSea, rowCount - widthSea),
                new Point(widthSea,            rowCount - widthSea)
            };

            SolidBrush brush = new SolidBrush(Lands.Sea.color);

            grafObj.FillPolygon(brush, topSeePoints);
            grafObj.FillPolygon(brush, bottomSeePoints);
        }

        // ****************************************************************************************
        protected void DrawMountains()
        {
            Point[] topSeePoints =
            {
                new Point(0,              0),
                new Point(0,              rowCount),
                new Point(widthMountains, rowCount - widthMountains),
                new Point(widthMountains, widthMountains)
            };

            Point[] bottomSeePoints =
            {
                new Point(colCount,                  0),
                new Point(colCount,                  rowCount),
                new Point(colCount - widthMountains, rowCount - widthMountains),
                new Point(colCount - widthMountains, widthMountains)
            };

            SolidBrush brush = new SolidBrush(Lands.Mountains.color);

            grafObj.FillPolygon(brush, topSeePoints);
            grafObj.FillPolygon(brush, bottomSeePoints);
        }

        // ****************************************************************************************
        protected void DrawGrass()
        {
            Rectangle rect = new Rectangle (widthSea, widthMountains, colCount - (2 * widthSea), rowCount - (2 * widthMountains));

            // Pen pen = new Pen(Color.White);
            SolidBrush brush = new SolidBrush(Lands.Grass.color);

            grafObj.FillEllipse(brush, rect);
            // grafObj.DrawEllipse(pen, rect);
        }

        // ****************************************************************************************
        protected void DrawWood()
        {
            int xCenter = (colCount / 2) - 1;
            int yCenter = (rowCount / 2) - 1;

            Rectangle rect1 = new Rectangle
                (
                    xCenter - (3 * widthWood / 4),
                    yCenter - (3 * widthWood / 4),
                    widthWood,
                    widthWood
                );

            Rectangle rect2 = new Rectangle
                (
                    xCenter - (widthWood / 4),
                    yCenter - (widthWood / 4),
                    widthWood,
                    widthWood
                );

            
            SolidBrush brush = new SolidBrush(Lands.Wood.color);            

            grafObj.FillEllipse(brush, rect1);
            grafObj.FillEllipse(brush, rect2);
        }

        // ****************************************************************************************
        protected void DrawLake()
        {
            int xCenter = (colCount / 2) - 1;
            int yCenter = (rowCount / 2) - 1;

            Rectangle rect1 = new Rectangle
                (
                    xCenter - (widthLake / 2) + 40,
                    yCenter - (widthLake / 2) + 70,
                    widthLake,
                    widthLake
                );

            Rectangle rect2 = new Rectangle
                (
                    xCenter - (widthLake / 2) + 70,
                    yCenter - (widthLake / 2) + 40,
                    widthLake,
                    widthLake
                );

            Rectangle rect3 = new Rectangle
                (
                    xCenter - (widthLake / 2) - 70,
                    yCenter - (widthLake / 2) - 40,
                    widthLake,
                    widthLake
                );

            Rectangle rect4 = new Rectangle
                (
                    xCenter - (widthLake / 2) - 40,
                    yCenter - (widthLake / 2) - 70,
                    widthLake,
                    widthLake
                );

            SolidBrush brush = new SolidBrush(Lands.Lake.color);
            //SolidBrush brush2 = new SolidBrush(Color.White);

            grafObj.FillEllipse(brush, rect1);
            grafObj.FillEllipse(brush, rect2);
            grafObj.FillEllipse(brush, rect3);
            grafObj.FillEllipse(brush, rect4);

        }
        // ****************************************************************************************
        // ****************************************************************************************
        public Bitmap ResizeBitmap(Bitmap origBmp, int newWidth, int newHeight)
        {
            Bitmap newBmp = new Bitmap(newWidth, newHeight);
            Graphics graphObj = Graphics.FromImage(newBmp);
            graphObj.DrawImage(origBmp, 0, 0, newWidth, newHeight);

            return newBmp;
        }
        // ****************************************************************************************
    }
}
