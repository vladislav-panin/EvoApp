using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class Population
    {
        public static int entityMax { get; set; } = 10000;
       
        public Dictionary<int, DeskCell> entityLocations { get; set; } = new Dictionary<int, DeskCell>();
        public int EntityCount()
        {
            return entityLocations.Count;
        }
        public Population()
        {

        }

        //инициализация ячеек игрового поля 1000*1000
        public int Generate()
        {
            int entityId = 0;

            for (entityId = 0; entityId < entityMax; entityId++)
            {
                
            }

            List<List<DeskCell>> lst = Program.app.desk.cellTable;

            int rowCount = Program.app.desk.geoEx.rowCount;
            int colCount = Program.app.desk.geoEx.colCount;
     
            for (int idxRow = 0; idxRow < rowCount; idxRow++)
            {               

                for (int idxColumn = 0; idxColumn < colCount; idxColumn++)
                {
                    DeskCell dc = lst[idxRow][idxColumn];
                    
                    if(idxColumn > 80 && idxColumn < 500)
                    {
                        Entity entity = new Entity(entityId);
                        entityLocations.Add(entityId++, dc);

                        Program.app.desk.cellTable[idxRow][idxColumn].EntityAdd(entity);


                    if (entityId > entityMax)
                        break;
                    }
                }
            }
            return entityId;
        }
    }
}
