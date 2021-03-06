using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class VegetableTomato : Vegetable
    {
        // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        override public int GetIcoExtentOrder()
        {
            return 14;
        }
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 3;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 3;
        }
        // *************************************************************************************************************************************************        

        public VegetableTomato(long id) : base(id, EUnitType.EVegetableTomato)
        {
        }

        // *************************************************************************************************************************************************
        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }
        // *************************************************************************************************************************************************  
    }
}
