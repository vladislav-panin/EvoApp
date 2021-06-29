using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class Woman : BaseHuman
    {
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 4;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 4;
        }
        
        public Woman(long id) : base(id, EUnitType.EHumanWoman, EUnitSex.EFemale)
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
