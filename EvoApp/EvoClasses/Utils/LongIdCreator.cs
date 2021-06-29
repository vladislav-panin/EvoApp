using System;
using System.Collections.Generic;

namespace EvoApp
{
    public class LongIdCreator
    {
        // ***********************************************************************************************************************************
        protected SortedDictionary<long, UnitBase> biomByID;

        // ***********************************************************************************************************************************
        public LongIdCreator(SortedDictionary<long, UnitBase> biomByID)
        {
            this.biomByID = biomByID;
        }
        // ***********************************************************************************************************************************

        public long getID ()
        {
            for (long runner = 0; runner < long.MaxValue; runner++)
            {
                if (!biomByID.ContainsKey(runner))
                    return runner;
            }
            throw new Exception("Генератор идентификаторов для живности: Ошибка или переполнение! Исчерпан положительный диапазон long, не могу найти свободное число.");
        }
        // ***********************************************************************************************************************************

        public long getID_OnInit()
        {
            for (long runner = 1_000_000; runner < long.MaxValue; runner++)
            {
                if (!biomByID.ContainsKey(runner))
                    return runner;
            }
            throw new Exception("Генератор идентификаторов для живности: Ошибка или переполнение! Исчерпан положительный диапазон long, не могу найти свободное число.");
        }
        // ***********************************************************************************************************************************
    }
}
