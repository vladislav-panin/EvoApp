using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    abstract public class FastFood : UnitBase
    {
        public int satietyFactor = 0;
        // *************************************************************************************************************************************************        

        public FastFood(long id, EUnitType type) : base(id, type, EUnitSex.none)
        {
        }
        // ***********************************************************************************************************************************
        public override void CalcNextStep(DeskCell cell)
        {            
        }
    }
}
