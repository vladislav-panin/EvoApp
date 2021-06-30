using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public abstract class UnitBase
    {
        public abstract void CalcNextStep(DeskCell cell);

        public int idxCol { get; set; } = -1;
        public int idxRow { get; set; } = -1;

        public long ID { get; } = -1;
        public EUnitSex sex = EUnitSex.none;
        public EUnitType TYPE = EUnitType.none;

        public abstract int GetIcoExtentOrder(); // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        // ***********************************************************************************************************************************

        public UnitBase(long id, EUnitType type, EUnitSex sex)
        {
            this.ID = id;
            this.sex = sex;
            this.TYPE = type;
        }
        // ***********************************************************************************************************************************        

        // возвращает ссылку на глобальную доску (Desk)
        public static List<List<DeskCell>> Cells()
        {
            return Program.app.getDesk().cellTable;
        }
        // ***********************************************************************************************************************************
        public void SetCoo (int idxCol, int idxRow)
        {
            this.idxCol = idxCol;
            this.idxRow = idxRow;


        }
        // ***********************************************************************************************************************************
    }
}
