using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class FastFoodAnimal : FastFood
    {

        // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        override public int GetIcoExtentOrder()
        {
            return 40;
        }

        protected static int SATIETY_FACTOR_MEAT = 50;
        // *************************************************************************************************************************************************        

        public FastFoodAnimal(long id) : base(id, EUnitType.EFastFoodFromAnimal)
        {
            this.satietyFactor = SATIETY_FACTOR_MEAT;
        }       
        // ***********************************************************************************************************************************
    }
}
