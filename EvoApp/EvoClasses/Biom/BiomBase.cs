using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    // все, кто унаследован от BiomBase - юниты
    public abstract class BiomBase : UnitBase
    {
        public abstract void doSpawn();   // размножаться
        public abstract void CheckDie();   // проверка - если сытость равна 0, - удалить животное из эволюции. А растение может быть съедено, тогда его тоже нужно удалить

        abstract public void doEat();    // питаться         
        abstract public void doDrink();    // пить

        // ***********************************************************************************************************************************       

        public BiomBase (long id, EUnitType type, EUnitSex sex) : base(id, type, sex)
        {
        }
        // ***********************************************************************************************************************************

        public static Random rndGen = new Random();

        abstract protected int getMaxAllowed_X_Shift(); // модуль максимального смещения X от текущей ячейки
        abstract protected int getMaxAllowed_Y_Shift(); // модуль максимального смещения Y от текущей ячейки

        // возвращает следующую ячейку
        virtual public Point getNextStep(int idxColCurrent, int idxRowCurrent)
        {
            int idxStepX = rndGen.Next(0, 2*getMaxAllowed_X_Shift());
            int idxStepY = rndGen.Next(0, 2*getMaxAllowed_Y_Shift());

            // координаты ячейкив которую ent прыгнет следующим шагом
            Point ret = new Point(
                idxColCurrent + (idxStepX - getMaxAllowed_X_Shift()),
                idxRowCurrent + (idxStepY - getMaxAllowed_Y_Shift()));

            return ret;
        }
        // *************************************************************************************************************************************************
    }
}
