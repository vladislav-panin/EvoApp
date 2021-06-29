using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class VegetablePatato : Vegetable
    {
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 4;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 4;
        }
        // *************************************************************************************************************************************************        
                
        public VegetablePatato(long id) : base(id, EUnitType.EVegetablePatato)
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
