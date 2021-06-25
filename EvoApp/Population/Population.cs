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
        public static Bitmap bmpRaptor { get; set; } = null;


        // ***********************************************************************************************************************************

        public int EntityCount()
        {
            return entityLocations.Count;
        }

        public Population()
        {
        }

        // ***********************************************************************************************************************************
        public static GeoEx geo()
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
                    {
                        debug_addExtraCountEntity(entityId);
                        return entityLocations.Count;
                    }

                    DeskCell cell = Cells()[idxRow][idxColumn];

                    if (idxColumn >= 100)
                        continue;

                    Entity entity = new Entity(entityId, idxColumn, idxRow);
                    entityLocations.Add(entityId++, cell);

                    Cells()[idxRow][idxColumn].EntityAdd(entity);
                }
            }
            return entityLocations.Count;
        }

        private void debug_addExtraCountEntity(long entityId)
        {
            // в левую верхнюю колонку помещаем еще несколько ентити
            for (int i = 0; i < 4; i++)
            {
                Entity ent = new Entity(entityId, 0, 0);

                Cells()[0][0].EntityAdd(ent);
                entityLocations.Add(entityId++, Cells()[0][0]);
            }
        }
        // ***********************************************************************************************************************************
        void CreateInhabitansBitmaps()
        {
            Bitmap pic;
            ResourceManager rm = Resources.ResourceManager;

            pic = (Bitmap)rm.GetObject("smile");
            bmpEntity = new Bitmap(pic, 20, 20);

            pic = (Bitmap)rm.GetObject("dolly");
            bmpHerbivore = new Bitmap(pic, 20, 20);

            pic = (Bitmap)rm.GetObject("digger");
            bmpRaptor = new Bitmap(pic, 20, 20);
        }
        // ***********************************************************************************************************************************

        protected Entity doCreature (long entityId, int idxColumn, int idxRow)
        {
            Entity entity = new Entity(entityId, idxColumn, idxRow);
            return entity;
        }
        // ***********************************************************************************************************************************
    }
}
