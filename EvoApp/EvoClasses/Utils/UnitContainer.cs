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
		protected int startId = 0;		


		public SortedDictionary<long, UnitBase> unitByID 
		{ 
			get; 
			set; 
		} 
			= new SortedDictionary<long, UnitBase>();		
		// ***********************************************************************************************************************************

		public UnitContainer(int startId)
		{
			this.startId = startId;
			this.idGen = new LongIdCreator(unitByID);
		}
		// ***********************************************************************************************************************************
	}
}
