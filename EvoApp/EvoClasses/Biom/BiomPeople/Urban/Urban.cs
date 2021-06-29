using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    abstract public class Urban : UnitBase
    {
       

        // *************************************************************************************************************************************************        

        public Urban(long id, EUnitType type) : base(id, type, EUnitSex.none)
        {
        }

        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }
        // ***********************************************************************************************************************************
    }
}
