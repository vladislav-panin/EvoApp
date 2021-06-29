using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class Man : BaseHuman
    {
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 5;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 5;
        }
        
        public Man(long id) : base(id, EUnitType.EHumanMen, EUnitSex.EMale)
        {
        }
        public Man(Child child) : base(child.ID, EUnitType.EHumanMen, EUnitSex.EMale)
        {
            this.satiety = child.satiety;
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
