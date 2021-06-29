using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    abstract public class BaseHuman : Omni
    {
        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }

        public override void CheckDie()
        {
            throw new NotImplementedException();
        }

        public override void doEat()
        {
            throw new NotImplementedException();
        }

        public override void doMove()
        {
            throw new NotImplementedException();
        }

        public override void doSpawn()
        {
            throw new NotImplementedException();
        }
        // *************************************************************************************************************************************************        

        public BaseHuman(long id, EUnitType type, EUnitSex sex) : base(id, type, sex)
        {
        }
        // ***********************************************************************************************************************************
    }
}
