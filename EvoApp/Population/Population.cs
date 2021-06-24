using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class Population
    {
        public static int entityMaxCount { get; set; } = 10000;             
        public Dictionary<long, DeskCell> entityLocations { get; set; } = new Dictionary<long, DeskCell>();
        // ***********************************************************************************************************************************

        public static Bitmap bmpEntity { get; set; } = null;
        public static Bitmap bmpHerbivore { get; set; } = null;        
        // ***********************************************************************************************************************************

        public int EntityCount() {
            return entityLocations.Count;
        }

        public Population() {
        }

        // ***********************************************************************************************************************************
        public static GeoEx geo ()
        {
            return Program.app.getDesk().geoEx;
        }
        public static List<List<DeskCell>> Cells()
        {
            return Program.app.getDesk().cellTable;
        }
        // ***********************************************************************************************************************************
        public int Generate()
        {
            CreateInhabitansBitmaps();

            long entityId = 0;
            for (int idxRow = 0; idxRow < geo().rowCount; idxRow++)
            {
                for (int idxColumn = 0; idxColumn < geo().colCount; idxColumn++)
                {
                    if (entityId >= entityMaxCount)
                        return entityLocations.Count;

                    DeskCell cell = Cells() [idxRow][idxColumn];

                    if (idxColumn >=100)
                        continue;

                    // Console.WriteLine("Сущность порождена и будет помещена в ячейку X =" + idxColumn + "; Y = " + idxRow);

                    Entity entity = new Entity(entityId, idxColumn, idxRow);
                    entityLocations.Add(entityId++, cell);

                    Cells() [idxRow][idxColumn].EntityAdd(entity);                    
                }
            }

            // в левую верхнюю колонку помещаем второго ентити
            Entity ent = new Entity(entityId, 0, 0); 

            Cells()[0][0].EntityAdd(ent);
            entityLocations.Add(entityId++, Cells()[0][0]);

            // в левую верхнюю колонку помещаем третьего ентити
            ent = new Entity(entityId, 0, 0); 

            Cells()[0][0].EntityAdd(ent);
            entityLocations.Add(entityId++, Cells()[0][0]);



            return entityLocations.Count;
        }
        // ***********************************************************************************************************************************
        void CreateInhabitansBitmaps()
        {
            Bitmap pic;
            ResourceManager rm = Resources.ResourceManager;

            pic = (Bitmap)rm.GetObject("digger");
            bmpEntity = new Bitmap(pic, 20, 20);

            pic = (Bitmap)rm.GetObject("dolly");
            bmpHerbivore = new Bitmap(pic, 20, 20);
    }
        // ***********************************************************************************************************************************
    }
}
