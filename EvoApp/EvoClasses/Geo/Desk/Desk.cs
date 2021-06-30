using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    public class Desk
    {
        // ****************************************************************************************
        public List<List<DeskCell>> cellTable { get; set; } = null;        
        public GeoEx                geoEx     { get; set; } = null;

        protected Population population = null;

        // ****************************************************************************************
        public Desk()
        {
            geoEx = new GeoEx();
            geoEx.Init();
        }

        // ****************************************************************************************
        //инициализация ячеек игрового поля 1000*1000
        public int Init(Population population)
        {
            this.population = population;

            int cellCount =  CreateCells();
            SetLandscape();

            return cellCount;
        }

        // ****************************************************************************************
        public int CreateCells()
        {
            cellTable = new List<List<DeskCell>>();
            int counter;

            int idxRow = 0;
            int idxColumn = 0;

            for (idxRow = 0; idxRow < geoEx.rowCount; idxRow++) 
            {
                List<DeskCell> cellRow = new List<DeskCell>();
                cellTable.Add(cellRow);
                for (idxColumn = 0; idxColumn < geoEx.colCount; idxColumn++)
                {
                    DeskCell cell = new DeskCell(idxRow, idxColumn);                    
                    cellRow.Add(cell);
                }
            }

            counter = idxRow * idxColumn;
            return counter;
        }

        // ****************************************************************************************
        /*
         * Всего 1000 х 1000 ячеек
         * устанавливаем ланшафт по цвету ячеек эталонной карты GeoEx.etalonMap
         */
        public void SetLandscape()
        {
            Color clr;

            for (int idxRow = 0; idxRow < geoEx.rowCount; idxRow++) {

                for (int idxColumn = 0; idxColumn < geoEx.colCount; idxColumn++) {

                    clr = geoEx.etalonMap.GetPixel(idxColumn, idxRow);
                    cellTable[idxRow][idxColumn].land = Lands.GetLandscape(clr, idxColumn, idxRow);                    
                }            
            }
        }

        // ****************************************************************************************  
        // вызывается в потоке App.evoThread
        public void CalcNextTick_slow()
        {
            for (int idxRow = 0; idxRow < geoEx.rowCount; idxRow++) {

                for (int idxColumn = 0; idxColumn < geoEx.colCount; idxColumn++) {

                    cellTable [idxRow] [idxColumn]. UnitCalcNextStepAll ();
                }
            }
        }
        // ****************************************************************************************       
        public void CalcNextTick()
        {
            // дома, амбары, деревни и еда - не иттерируются. Они создаются переносятся в другие ячейки действиями людей 

            foreach (var pair in population._vegetables.unitByID)
            {
                long id = pair.Key;
                UnitBase ub = pair.Value;

                ub.CalcNextStep(UnitBase.Cells()[ub.idxCol][ub.idxRow]);
            }

            foreach (var pair in population._humans.unitByID)
            {
                long id = pair.Key;
                UnitBase ub = pair.Value;

                ub.CalcNextStep(UnitBase.Cells()[ub.idxCol][ub.idxRow]);
            }

            foreach (var pair in population._raptors.unitByID)
            {
                long id = pair.Key;
                UnitBase ub = pair.Value;

                ub.CalcNextStep(UnitBase.Cells()[ub.idxCol][ub.idxRow]);
            }

            foreach (var pair in population._omnis.unitByID)
            {
                long id = pair.Key;
                UnitBase ub = pair.Value;

                ub.CalcNextStep(UnitBase.Cells()[ub.idxCol][ub.idxRow]);
            }

            foreach (var pair in population._herbivores.unitByID)
            {
                long id = pair.Key;
                UnitBase ub = pair.Value;

                ub.CalcNextStep(UnitBase.Cells()[ub.idxCol][ub.idxRow]);
            }

            foreach (var pair in population._herbivores.unitByID)
            {
                long id = pair.Key;
                UnitBase ub = pair.Value;

                ub.CalcNextStep(UnitBase.Cells()[ub.idxCol][ub.idxRow]);
            }
        }
        // ****************************************************************************************       
    }
}
