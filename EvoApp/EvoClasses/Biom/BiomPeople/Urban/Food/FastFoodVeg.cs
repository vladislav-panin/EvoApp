using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class FastFoodVeg: FastFood
    {
        // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        override public int GetIcoExtentOrder()
        {
            return 40;
        }

        protected static int SATIETY_FACTOR_VEG = 10;
        // *************************************************************************************************************************************************        

        public FastFoodVeg(long id) : base(id, EUnitType.EFastFoodFromVeg)
        {
            this.satietyFactor = SATIETY_FACTOR_VEG;
        }
        // ***********************************************************************************************************************************
    }
}
