using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class VegetableStrawberry : Vegetable
    {
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 7;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 7;
        }
        // *************************************************************************************************************************************************        

        public VegetableStrawberry(long id) : base(id, EUnitType.EVegetableStrawberry)
        { 
        }


        // *************************************************************************************************************************************************
        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }
        // *************************************************************************************************************************************************
    }
}
