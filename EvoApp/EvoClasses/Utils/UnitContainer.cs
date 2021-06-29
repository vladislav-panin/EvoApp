using EvoApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    public class UnitContainer
    {
		public LongIdCreator idGen;
		public int startUnitCount = 0;		
		public SortedDictionary<long, UnitBase> unitByID 
		{ 
			get; 
			set; 
		} 
			= new SortedDictionary<long, UnitBase>();		
		// ***********************************************************************************************************************************

		public UnitContainer(int startUnitCount)
		{
			this.startUnitCount = startUnitCount;
			this.idGen = new LongIdCreator(unitByID);
		}
	}
}
