using System.Drawing;

namespace EvoApp
{
    public enum ELandscape
    {
        Desert    = 10,
        Sea       = 20,
        Mountains = 30,
        Lake      = 40,        
        Grass     = 50,
        WoodEdge  = 60,
        Wood      = 70
    }

    // **********************************************************************************************************
    public class Lands
    {               
        public static Landscape Desert    = new Landscape (ELandscape.Desert);
        public static Landscape Sea       = new Landscape (ELandscape.Sea);
        public static Landscape Mountains = new Landscape (ELandscape.Mountains);
        public static Landscape Lake      = new Landscape (ELandscape.Lake);
        public static Landscape Grass     = new Landscape (ELandscape.Grass);
        public static Landscape WoodEdge  = new Landscape(ELandscape.WoodEdge); 
        public static Landscape Wood      = new Landscape (ELandscape.Wood);

        public static Landscape GetLandscape(Color color, int idxColumn, int idxRow)
        {            
            if (isEquels(color, Lands.Desert.color))
                return Lands.Desert;

            if (isEquels(color, Lands.Sea.color))                
                return Lands.Sea;

            if (isEquels(color, Lands.Mountains.color))
                return Lands.Mountains;

            if (isEquels(color, Lands.Lake.color))
                return Lands.Lake;

            if (isEquels(color, Lands.Grass.color))
                return Lands.Grass;

            if (isEquels(color, Lands.WoodEdge.color))
                return Lands.WoodEdge;

            if (isEquels(color, Lands.Wood.color))
                return Lands.Wood;            

            return null;
        }

        public static bool isEquels(Color c1, Color c2) {
            
            if (c1.A == c2.A && c1.R == c2.R && c1.G == c2.G && c1.B == c2.B)
                return true;

            return false;
        }


    }

    // **********************************************************************************************************
    public class Landscape
    {
        public Color color { get; }
        public Brush textBrush { get; }        
        public SolidBrush brush { get; }
        public ELandscape elandscape { get; }

        private Bitmap bg; // фоновое изображение ячейки с конкретным ландшафтом

        // получить фоновое изображение ячейки с конкретным ландшафтом
        public Bitmap getBackground () {
            return bg;
        }

        // установить фоновое изображение ячейки с конкретным ландшафтом
        public void setBackground(Bitmap bg) {
            this.bg = bg;
        }


        // **********************************************************************************************************
        public Landscape(ELandscape land)
        {
            elandscape = land;
            textBrush = Brushes.Blue;

            switch (land)
            {
                case ELandscape.Desert:
                    color = Color.PaleGoldenrod;
                    break;

                case ELandscape.Sea:
                    color = Color.MediumBlue;
                    textBrush = Brushes.White;
                    break;

                case ELandscape.Mountains:
                    color = Color.DimGray;
                    textBrush = Brushes.White;
                    break;

                case ELandscape.Lake:
                    // color = Color.Aqua;
                    color = Color.FromArgb(0x04, 0xC6, 0xF7);
                    break;

                case ELandscape.Grass:
                    color = Color.MediumSeaGreen;
                    break;

                case ELandscape.WoodEdge:
                    color = Color.FromArgb(0x11, 0x79, 0x11);                    
                    textBrush = Brushes.White;
                    break;

                case ELandscape.Wood:
                    color = Color.DarkGreen;
                    textBrush = Brushes.White;
                    break;
            }

            brush = new SolidBrush(color);            
        }

    }
}
