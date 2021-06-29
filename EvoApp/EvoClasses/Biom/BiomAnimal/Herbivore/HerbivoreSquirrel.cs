using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class HerbivoreSquirrel : Herbivore
    {
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 2;
        }
        protected override int getMaxAllowed_Y_Shift()  {
            return 2;
        }

       

        // *************************************************************************************************************************************************

        public HerbivoreSquirrel(long id, EUnitSex sex) : base(id, EUnitType.EHerbivoreSquirrel, sex)
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
