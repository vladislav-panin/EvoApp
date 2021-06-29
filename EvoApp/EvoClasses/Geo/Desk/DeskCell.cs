using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvoApp
{
    // ячейка на поле игры
    public class DeskCell
    {
        static public int cellWidth { get; set; }  = -1; // в пикселях
        static public int cellHeight { get; set; } = -1; // в пикселях

        public int idxCol { get; set; }
        public int idxRow { get; set; }        

        public String cooIdxsTxt { get; set; }
        public Landscape land { get; set; }

        public List<UnitBase> lstEntity { get; set; } = new List<UnitBase>();

        public int BiomCount()
        {
            return lstEntity.Count;
        }

        public bool Contains(UnitBase ent)
        {
            return lstEntity.Contains (ent);
        }

        public void BiomAdd(UnitBase ent)
        {
            lstEntity.Add(ent);
        }

        public bool BiomRemove(UnitBase ent)
        {
            return lstEntity.Remove(ent);
        }

        public void BiomRemoveAll()
        {
            lstEntity.Clear();
        }

        public void BiomCalcNextStepAll()
        {
            for (int i = 0; i < lstEntity.Count; i++)
            {
                try
                {
                    UnitBase unitBase = lstEntity[i];
                    unitBase.CalcNextStep (this);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Перехвачено исключение: " + e.Message);
                }
            }
        }

        // ****************************************************************************************
        public DeskCell(int idxRow, int idxColumn)
        {
            this.idxRow = idxRow;
            this.idxCol = idxColumn;

            this.cooIdxsTxt = "(" + this.idxRow + "; " + this.idxCol + ")";
        }

        // ****************************************************************************************
        static public void InitCell (int cell_width, int cell_height)
        {
            DeskCell.cellWidth = cell_width;
            DeskCell.cellHeight = cell_height;
        }

        // ****************************************************************************************
        public void paint (Graphics canvasGraph, CellPainter cellPainter, int xCellIdx, int yCellIdx)
        {
            cellPainter.paintCell (canvasGraph, this, xCellIdx, yCellIdx);
        }
        // ****************************************************************************************
    }
}
