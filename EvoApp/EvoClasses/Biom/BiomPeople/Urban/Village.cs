using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;

namespace EvoApp
{
    public class Village : Urban
    {
        protected Dictionary <long, VillageBarn> dictBarn = new Dictionary <long, VillageBarn> ();  // словарь амбаров по ID
        protected Dictionary<long, VillageHouse> dictHouse = new Dictionary<long, VillageHouse>();  // словарь домов по ID
        

        // *************************************************************************************************************************************************
        public Village(long id) : base(id, EUnitType.EVillige)
        {
        }
        // ***********************************************************************************************************************************

        public Dictionary<long, VillageBarn> GetBarnDict() {
            return dictBarn;
        }

        public VillageBarn GetBarnById(int id) {
            return dictBarn[id];
        }

        public int GetBarnCount () {
            return dictBarn.Count;
        }

        public void AddBarn(VillageBarn barn) {
            dictBarn.Add(barn.ID, barn);
        }

        // ***********************************************************************************************************************************

        public Dictionary<long, VillageHouse> GetHouseDict() {
            return dictHouse;
        }

        public VillageHouse GetHouseById(int id) {
            return dictHouse[id];
        }

        public int GetHouseCount() {
            return dictHouse.Count;
        }

        public void AddBarn(VillageHouse house) {
            dictHouse.Add(house.ID, house);
        }
        // ***********************************************************************************************************************************
        // ***********************************************************************************************************************************
        public override void CalcNextStep(DeskCell cell)
        {
            throw new NotImplementedException();
        }
        // ***********************************************************************************************************************************
    }
}
