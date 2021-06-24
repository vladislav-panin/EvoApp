using System;
using System.Diagnostics;
using System.Threading;

namespace EvoApp
{
    public class App
    {
        static object lockerObjForEvoDesk = new object();
        private Desk evoDesk = new Desk();

        public Desk getDesk()
        {
            lock (lockerObjForEvoDesk)
            {
                return evoDesk;
            }
        }

        public void setDesk(Desk desk)
        {
            lock (lockerObjForEvoDesk)
            {
                this.evoDesk = desk;
            }
        }
            

        // ****************************************************************************************
        static object lockerObjForAppThreadInfo = new object();
        private AppThreadInfo appThreadInfo = new AppThreadInfo();

        public AppThreadInfo getThreadInfo ()        
        {            
                lock (lockerObjForAppThreadInfo)
                {
                    return appThreadInfo;
                }
        }

        public void setThreadInfo(AppThreadInfo info)
        {
            lock (lockerObjForAppThreadInfo)
            {
                appThreadInfo = info;
            }
        }
        // ****************************************************************************************

        public AppInitInfo appInitInfo = new AppInitInfo();
        public Population population = new Population();

        protected Stopwatch watcher = new Stopwatch();
        static Thread evoThread = null;        

        // ******************************************************************************************************
        // static ReaderWriterLock rwEvoLock = new ReaderWriterLock();

        // ReaderWriterLock. AcquireReaderLock()
        // наш поток вызывает этот метод попытаясь захватить ресурс на чтение. Если другие потоки уже захватили ресурс на чтение, то это не помешает нашему потоку прочитать ресурс.
        // Но если этот ресурс уже захвачен другим потоком на запись, или в очереди уже есть поток, ожидающий блокировки на запись - то наш поток будет заблокирован и будет ожидать
        // до тех пор не кончится таймаут (и поток отвалится так и не прочитав ресурс), либо пока все потоки, стоящие перед ним в очереди и ожидающие блокировку записи, - не освободят ресурс.

        // // ReaderWriterLock. AcquireWriterLock()
        // наш поток вызывает этот метод попытаясь захватить ресурс на запись. Если другие потоки уже захватили ресурс на чтение или запись, - то наш поток будет заблокирован и будет ожидать
        // до тех пор не кончится таймаут (и поток отвалится так и не прочитав ресурс), либо пока все потоки, стоящие перед ним в очереди, не освободят ресурс.
        // ******************************************************************************************************

        // имя объекта, который будем использовать для лока разделяемого между потоками объекта - оно может быть произвольным        
        static object lockerObjForEvoSpeed = new object();
        // ******************************************************************************************************

        protected EvoSpeed evo_speed = EvoSpeed.Hi;
        public EvoSpeed evoSpeed
                { 
                    get 
                    {
                        lock (lockerObjForEvoSpeed)
                        {
                            return evo_speed;
                        }
                    }
                    set 
                    {
                        lock (lockerObjForEvoSpeed)
                        {
                            evo_speed = value;
                        }
                    }
                }

        // ******************************************************************************************************
        public App ()
        {
            evoDesk = new Desk();
            appThreadInfo = new AppThreadInfo();
        }

        // ******************************************************************************************************
        // Этот метод запускается в потоке асинхронной задачи главной формы приложения
        // Этот поток, и поток App.evoThread, будут конкурировать за ресурс evoDesk.cellTable
        // поэтому evoDesk нужно защитить, и сделаю это с использованием  лока на lockerObjForEvoDesk
        public AppInitInfo Init()
        {
            watcher.Start();

                int cellCount = this.evoDesk.Init();
                Console.WriteLine("! ------- инициализация игрового поля завершена, количество инициированных ячеек равно " + cellCount);

                int entityCount = population.Generate();
                Console.WriteLine("! ------- инициализация сущностей завершена, количество инициированных сущностей равно " + entityCount);
                
            watcher.Stop();  
            
            long milli = watcher.ElapsedMilliseconds;

            appInitInfo.evoInitTime_millisec = milli;
            appInitInfo.cellCount = cellCount;
            appInitInfo.entityCount = entityCount;

            return appInitInfo;
        }

        // ****************************************************************************************               
        public void Run ()
        {
            evoThread = new Thread(App.DoEvoThread);
            evoThread.Start(this);

            Console.WriteLine("! ---------------- расчет шага игры запущен");
        }

        // ****************************************************************************************               
        // Этот метод запускается в потоке App.evoThread этого класса, экземпляр которого создается в другом потоке
        // Этот поток, и поток главной формы приложения, будут конкурировать за ресурс evoDesk.cellTable
        // поэтому evoDesk нужно защитить, и сделаю это с использованием  лока на lockerObjForEvoDesk
        public static void DoEvoThread (object this_app_obj)
        {
            Stopwatch evoThreadWatcher = new Stopwatch();

            App app = (App)this_app_obj; 
            evoThreadWatcher.Restart();

                 app.evoDesk.CalcNextTick();  // вызов этого метода считает шаг эволюции, остальной код - собирает информацию для отображения на форме приложения

            evoThreadWatcher.Stop();

            app.getThreadInfo().evoCycleCounter++;
            app.getThreadInfo().evoCycleTime_millisec = evoThreadWatcher.ElapsedMilliseconds;
        }

        // ****************************************************************************************               
    }
}
