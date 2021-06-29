using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class VegetableMushroom : Vegetable
    {
         // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 6;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 6;
        }
        // *************************************************************************************************************************************************        
                
        public VegetableMushroom(long id) : base(id, EUnitType.EVegetableMushroom)
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
