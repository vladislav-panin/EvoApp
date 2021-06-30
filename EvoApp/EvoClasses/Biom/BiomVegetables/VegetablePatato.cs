using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class VegetablePatato : Vegetable
    {
        // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        override public int GetIcoExtentOrder()
        {
            return 12;
        }
        // *************************************************************************************************************************************************
        protected override int getMaxAllowed_X_Shift() {
            return 4;
        }
        protected override int getMaxAllowed_Y_Shift() {
            return 4;
        }
        // *************************************************************************************************************************************************        
                
        public VegetablePatato(long id) : base(id, EUnitType.EVegetablePatato)
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
