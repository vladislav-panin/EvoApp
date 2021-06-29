using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class FastFoodVeg: FastFood
    {
        protected static int SATIETY_FACTOR_VEG = 10;
        // *************************************************************************************************************************************************        

        public FastFoodVeg(long id) : base(id, EUnitType.EFastFoodFromVeg)
        {
            this.satietyFactor = SATIETY_FACTOR_VEG;
        }
        // ***********************************************************************************************************************************
    }
}
