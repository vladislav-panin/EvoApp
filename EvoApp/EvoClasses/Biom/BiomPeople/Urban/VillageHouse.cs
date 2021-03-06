using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class VillageHouse : Urban
    {
        protected Man man = null;
        protected Woman woman = null;

        protected List<Child> children = new List<Child>();

        // нужно, что бы упорядочить обитателей в списке юнитов ячейки по размеру изображения - при отрисовке будем рисовать сначала больших, потом маленьких.
        override public int GetIcoExtentOrder()
        {
            return 300;
        }
        // *************************************************************************************************************************************************
        public VillageHouse(long id) : base(id, EUnitType.EVilligeHouse)
        {
        }
        // ***********************************************************************************************************************************

        public void MakeManFromChild (Child child)
        { 
        }
        // ***********************************************************************************************************************************

        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }
        // ***********************************************************************************************************************************
    }
}
