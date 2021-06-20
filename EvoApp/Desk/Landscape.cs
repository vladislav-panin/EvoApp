using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public enum ELandscape
    {
        Desert = 10,
        Sea    = 20,
        Mountains = 30,
        Lake = 40,        
        Grass = 50,
        Wood = 70
    }

    // **********************************************************************************************************
    public class Lands
    {               
        public static Landscape Desert    = new Landscape (ELandscape.Desert);
        public static Landscape Sea       = new Landscape (ELandscape.Sea);
        public static Landscape Mountains = new Landscape (ELandscape.Mountains);
        public static Landscape Lake      = new Landscape (ELandscape.Lake);
        public static Landscape Grass     = new Landscape (ELandscape.Grass);
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

            if (isEquels(color, Lands.Wood.color))
                return Lands.Wood;

            return null;
        }

        public static bool isEquels(Color c1, Color c2)
        {
            if (c1.A == c2.A && c1.R == c2.R && c1.G == c2.G && c1.B == c2.B)
                return true;

            return false;
        }
    }

    // **********************************************************************************************************
    public class Landscape
    {
        public Brush textBrush { get; }
        public Color color { get; }
        public SolidBrush brush { get; }
        public ELandscape elandscape { get; }

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
                    break;

                case ELandscape.Lake:
                    // color = Color.Aqua;
                    color = Color.FromArgb(0x04, 0xC6, 0xF7);
                    break;

                case ELandscape.Grass:
                    color = Color.MediumSeaGreen;
                    break;

                case ELandscape.Wood:
                    color = Color.DarkGreen;
                    break;
            }

            brush = new SolidBrush(color);

            
        }

    }
}
