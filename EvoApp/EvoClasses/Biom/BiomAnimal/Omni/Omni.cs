using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public abstract class Omni  : Animal <BiomBase>
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
        public Omni(long id, EUnitType type, EUnitSex sex) : base(id, type, sex)
        {
        }
        // *************************************************************************************************************************************************        
    }
}
