using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class RaptorLynx : Raptor
    {
        // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        override public int GetIcoExtentOrder()
        {
            return 60;
        }
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 3;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 3;
        }
        // *************************************************************************************************************************************************        

        public RaptorLynx(long id, EUnitSex sex) : base(id, EUnitType.ERaptorLynx, sex)
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
