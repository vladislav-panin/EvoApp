using System;
using System.Diagnostics;
using System.Threading;

namespace EvoApp
{
    public class AppInitInfo
    {
        public String sTimerInfo  { get; set; } = "";        
        public long   evoInitTime { get; set; } = 0;

        public int cellCount      { get; set; } = 0;

        public int countBiomHerbivoreSquirrel  = 0;
        public int countBiomHerbivoreDeer      = 0;
        public int countBiomHerbivoreRabbit    = 0;

        public int countBiomOmniBoar           = 0;
        public int countBiomOmniBadger         = 0;
        public int countBiomOmniBear           = 0;

        public int countBiomRaptorLynx         = 0;
        public int countBiomRaptorWolf         = 0;
        public int countBiomRaptorFox          = 0;

        public int countBiomVegetablePatato    = 0;
        public int countBiomVegetableCarrot    = 0;
        public int countBiomVegetableMushroom  = 0;
        public int countBiomVegetableTomato    = 0;
        public int countBiomVegetableStrawberry= 0;
        
        public int countBiomHumanWoman         = 0;
        public int countBiomHumanMan           = 0;
        public int countBiomHumanChildren      = 0;

        public int countBiomVillige            = 0;
        public int countBiomVilligeHouse       = 0;
        public int countBiomVilligeBarn        = 0;
        public int countBiomVilligeBarnAnimal  = 0;
        public int countBiomVilligeBarnVeg     = 0;

        public int countBiomAll()
        {
            return  countBiomHerbivoreSquirrel +
                    countBiomHerbivoreDeer +
                    countBiomHerbivoreRabbit +

                    countBiomOmniBoar +
                    countBiomOmniBadger +
                    countBiomOmniBear +

                    countBiomRaptorLynx +
                    countBiomRaptorWolf +
                    countBiomRaptorFox +

                    countBiomVegetablePatato +
                    countBiomVegetableCarrot +
                    countBiomVegetableMushroom +
                    countBiomVegetableTomato +
                    countBiomVegetableStrawberry +

                    countBiomHumanWoman +
                    countBiomHumanMan +
                    countBiomHumanChildren +

                    countBiomVilligeHouse +
                    countBiomVilligeBarn +
                    countBiomVilligeBarnAnimal +
                    countBiomVilligeBarnVeg;
        }

        public int countBiomHerbivore()
        {
            return
                countBiomHerbivoreSquirrel +
                countBiomHerbivoreDeer +
                countBiomHerbivoreRabbit;
        }

        public int countBiomOmni()
        {
            return
                countBiomOmniBoar +
                countBiomOmniBadger +
                countBiomOmniBear;
        }

        public int countBiomRaptor()
        {
            return
                countBiomRaptorLynx +
                countBiomRaptorWolf +
                countBiomRaptorFox;
        }

        public int countBiomVegetable()
        {
            return
                countBiomVegetablePatato +
                countBiomVegetableCarrot +
                countBiomVegetableMushroom +
                countBiomVegetableTomato +
                countBiomVegetableStrawberry;
        }

        public int countBiomHuman()
        {
            return
                countBiomHumanWoman +
                countBiomHumanMan +
                countBiomHumanChildren;
        }

        // ******************************************************************************************************

        public AppInitInfo () {
            getTimerInfo();
        }

        // ****************************************************************************************               
        protected void getTimerInfo ()
        {
            long nanosecPerTick = (1000L * 1000L * 1000L) / Stopwatch.Frequency;

            if (Stopwatch.IsHighResolution)
                sTimerInfo = "Системный таймер использует режим высокого разрешения.\n\n";
            else
                sTimerInfo = "Системный таймер использует режим по умолчанию (низкое разрешение).\n\n";

            sTimerInfo += "Частота таймера равна " + Stopwatch.Frequency + ".\n";
            sTimerInfo += "Точность таймера равна " + nanosecPerTick + " наносекунд.\n";
        }
        // ****************************************************************************************               
    }
}
