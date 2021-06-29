using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;

namespace EvoApp
{
    public class VillageBarn : Urban
    {
        protected List<FastFoodAnimal> smokedMeatList = new List<FastFoodAnimal>();
        protected List<FastFoodVeg>    pickleList     = new List<FastFoodVeg>();

        // *************************************************************************************************************************************************
        public VillageBarn(long id) : base(id, EUnitType.EVilligeBarn)
        {
        }
        // ***********************************************************************************************************************************

        public FastFoodAnimal Get_ListItem_SmokedMeat()
        {
            if (smokedMeatList.Count == 0)
                return null;

            FastFoodAnimal smokedMeat = smokedMeatList.First();
            smokedMeatList.Remove(smokedMeat);

            return smokedMeat;
        }

        public int Count_List_OfSmokedMeat()
        {
            return smokedMeatList.Count;
        }

        public void Add_ToList_SmokedMeat(FastFoodAnimal smokedMeat)
        {
            smokedMeatList.Add(smokedMeat);
        }

        // ***********************************************************************************************************************************

        public FastFoodVeg Get_ListItem_Pickle()
        {
            if (pickleList.Count == 0)
                return null;

            FastFoodVeg pickle = pickleList.First();
            pickleList.Remove(pickle);

            return pickle;
        }

        public int Count_List_OfPickleList()
        {
            return pickleList.Count;
        }

        public void Add_ToList_Pickle(FastFoodVeg pickle)
        {
            pickleList.Add(pickle);
        }
        // ***********************************************************************************************************************************
    }
}
