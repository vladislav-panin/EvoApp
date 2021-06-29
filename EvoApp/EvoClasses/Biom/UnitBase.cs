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

        public long ID { get; } = -1;
        public EUnitSex sex = EUnitSex.none;
        public EUnitType TYPE = EUnitType.none;
        
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
    }
}
