using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class HerbivoreRabbit : Herbivore
    {
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 3;
        }
        protected override int getMaxAllowed_Y_Shift()  {
            return 3;
        }
        // *************************************************************************************************************************************************
        public HerbivoreRabbit(long id, EUnitSex sex) : base(id, EUnitType.EHerbivoreRabbit, sex)
        {
        }
        // *************************************************************************************************************************************************
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
