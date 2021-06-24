using System;
using System.Diagnostics;
using System.Threading;

namespace EvoApp
{
    public class AppInitInfo
    {
        public String sTimerInfo { get; set; } = "";
        
        public long evoInitTime_millisec { get; set; } = 0;

        public int cellCount { get; set; } = 0;
        public int entityCount { get; set; } = 0;

        // ******************************************************************************************************

        public AppInitInfo ()
        {
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
