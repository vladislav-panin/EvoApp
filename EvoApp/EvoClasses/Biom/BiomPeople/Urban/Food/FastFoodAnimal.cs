using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class FastFoodAnimal : FastFood
    {

        protected static int SATIETY_FACTOR_MEAT = 50;
        // *************************************************************************************************************************************************        

        public FastFoodAnimal(long id) : base(id, EUnitType.EFastFoodFromAnimal)
        {
            this.satietyFactor = SATIETY_FACTOR_MEAT;
        }       
        // ***********************************************************************************************************************************
    }
}
