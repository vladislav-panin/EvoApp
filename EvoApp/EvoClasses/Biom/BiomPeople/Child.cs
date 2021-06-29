using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class Child : BaseHuman
    {
        protected int chilhwood_counter = 0;
        protected int max_chilhwood = 300;
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 3;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 3;
        }
        
        public Child(long id, EUnitSex sex) : base(id, EUnitType.EHumanChild, sex)
        {
        }
        // ***********************************************************************************************************************************
        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }
        // *************************************************************************************************************************************************
        public override void doEat()
        {
            throw new NotImplementedException();
        }
        // *************************************************************************************************************************************************
    }
}
