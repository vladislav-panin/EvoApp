using System;
using System.Diagnostics;
using System.Threading;

namespace EvoApp
{
    public class AppThreadInfo
    {
        public long evoCycleCounter 
        { 
            get; 
            set; 
        } = 0;
        public double evoCycleTime_millisec 
        { 
            get; 
            set; 
        } = 0;
        
    }
}
