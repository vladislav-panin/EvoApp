using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public abstract class Vegetable : BiomBase
    {
        public int satietySource = 5;

        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }

        public override void CheckDie()
        {
            throw new NotImplementedException();
        }

        public override void doSpawn()
        {
            throw new NotImplementedException();
        }

        public override void doEat()
        { 
        }
        public override void doDrink()
        { 
        }
        // *************************************************************************************************************************************************

        public Vegetable(long id, EUnitType type) : base(id, type, EUnitSex.none)
        { 
        }        
    }
}
