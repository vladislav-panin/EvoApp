using System;
using System.Diagnostics;
using System.Threading;

namespace EvoApp
{
    // вся логика Эволюции - агрегирована в этом классе. Частично здесь и логика прорисовки юнитов.
    public class App
    {
        //  информация, которая передается из потока ассинхронной инициализации Evo в поток объекта главной формы приложения. Там она отрисовывется в метках
        public AppInitInfo appInitInfo = new AppInitInfo();

        //  информация, которая передается после выполнения каждого шага Эволюции в поток объекта главной формы приложения. Там она отрисовывется в метках
        public AppThreadInfo appThreadInfo = new AppThreadInfo();

        //  население (юниты) со всеми их свойствами
        public Population population = new Population();

        //  мир (Desk) и население (юниты) со всеми их свойствами
        private Desk evoDesk = new Desk();

        public Desk getDesk() {        
            return evoDesk;
        }
        /*
        public void setDesk(Desk desk) {            
            this.evoDesk = desk;
        }*/

        // поток вычисления шага эволюции, запускается по таймеру из потока объекта главной формы приложения.
        static Thread evoThread = null;

        // таймер для замера в потоке расчета шага эволюции. Не путать с таймером запуска (из формы EvoAppForm) расчета шага эволюции - это разные классы и разное назначение.
        // этот измеряет время и имеет тип System.Diagnostics.Stopwatch, а тот - имеет тип System.Windows.Forms.Timer и служит для периодического запуска некоего кода из кода и потока главной формы
        protected Stopwatch watcher = new Stopwatch(); 

        // ******************************************************************************************************
        // вообще говоря, для межпоточных локов лучше использовать ReaderWriterLock. Но с ним нужно разобраться.
        //
        // Собранная по ReaderWriterLock-у информация:
        //
        // static ReaderWriterLock rwEvoLock = new ReaderWriterLock();

        // ReaderWriterLock. AcquireReaderLock()
        // наш поток вызывает этот метод попытаясь захватить ресурс на чтение. Если другие потоки уже захватили ресурс на чтение, то это не помешает нашему потоку прочитать ресурс.
        // Но если этот ресурс уже захвачен другим потоком на запись, или в очереди уже есть поток, ожидающий блокировки на запись - то наш поток будет заблокирован и будет ожидать
        // до тех пор не кончится таймаут (и поток отвалится так и не прочитав ресурс), либо пока все потоки, стоящие перед ним в очереди и ожидающие блокировку записи, - не освободят ресурс.

        // // ReaderWriterLock. AcquireWriterLock()
        // наш поток вызывает этот метод попытаясь захватить ресурс на запись. Если другие потоки уже захватили ресурс на чтение или запись, - то наш поток будет заблокирован и будет ожидать
        // до тех пор не кончится таймаут (и поток отвалится так и не прочитав ресурс), либо пока все потоки, стоящие перед ним в очереди, не освободят ресурс.
        // ******************************************************************************************************

        public App ()
        {
            evoDesk = new Desk();
            appThreadInfo = new AppThreadInfo();
        }

        // ******************************************************************************************************
        // Создание и инициализация ячеек поля Эволюции
        // подготовка отрисовки малой панели и ячеек большой панели - не здесь! (вызывается в конструкторе EvoAppForm(), метод Init()  панелей)
        //
        // Этот метод запускается в потоке асинхронной задачи главной формы приложения
        // Этот поток, и поток App.evoThread, будут конкурировать за ресурс evoDesk.cellTable
        // поэтому evoDesk нужно защитить, и сделаю это с использованием  лока на lockerObjForEvoDesk
        public AppInitInfo Init()
        {
            watcher.Start();

                int cellCount = this.evoDesk.Init();
                population.Generate();
                
            watcher.Stop();  
            
            long milli = watcher.ElapsedMilliseconds;

            appInitInfo.cellCount   = cellCount;
            appInitInfo.evoInitTime = milli;

            //appInitInfo.countOf_Herbivore  = population.biom_HerbivoreByID.Count;
            //appInitInfo.countOf_Omni       = population.biom_OmniByID.Count;
            //appInitInfo.countOf_Raptor     = population.biom_RaptorByID.Count;
            //appInitInfo.countOf_Human      = population.biom_HumanByID.Count;
            //appInitInfo.countOf_Realty     = population.biom_RealtyByID.Count;
            //appInitInfo.countOf_Vegetables = population.biom_VegetablesByID.Count;

            appInitInfo.countBiomHerbivoreSquirrel = 0;
            appInitInfo.countBiomHerbivoreDeer = 0;
            appInitInfo.countBiomHerbivoreRabbit = 0;

            appInitInfo.countBiomOmniBoar = 0;
            appInitInfo.countBiomOmniBadger = 0;
            appInitInfo.countBiomOmniBear = 0;

            appInitInfo.countBiomRaptorLynx = 0;
            appInitInfo.countBiomRaptorWolf = 0;
            appInitInfo.countBiomRaptorFox = 0;

            appInitInfo.countBiomVegetablePatato = 0;
            appInitInfo.countBiomVegetableCarrot = 0;
            appInitInfo.countBiomVegetableMushroom = 0;
            appInitInfo.countBiomVegetableTomato = 0;
            appInitInfo.countBiomVegetableStrawberry = 0;

            appInitInfo.countBiomHumanWoman = 0;
            appInitInfo.countBiomHumanMan = 0;
            appInitInfo.countBiomHumanChildren = 0;

            appInitInfo.countBiomVilligeHouse = 0;
            appInitInfo.countBiomVilligeBarn = 0;
            appInitInfo.countBiomVilligeBarnAnimal = 0;
            appInitInfo.countBiomVilligeBarnVeg = 0;

            return appInitInfo;
        }

        // ****************************************************************************************               
        // создает и запускает новый поток вычисления шага Эволюции.
        // после выполнения расчета шага, поток завершает свою работу. Для рассчета следующего шага - метод Run () вызывается снова - то еснова будет создан и запущен на выполнение поток.
        public void Run ()
        {
            evoThread = new Thread(App.DoEvoThread);
            evoThread.Start(this);

            Console.WriteLine("! ---------------- расчет шага игры запущен");
        }

        // ****************************************************************************************               
        // Этот метод запускается в потоке App.evoThread этого класса, экземпляр которого создается в потоке главной формы приложения
        public static void DoEvoThread (object this_app_obj)
        {
            Stopwatch evoThreadWatcher = new Stopwatch();

            App app = (App)this_app_obj; 
            evoThreadWatcher.Restart();

                 app.evoDesk.CalcNextTick();  // вызов этого метода считает шаг эволюции, остальной код - собирает информацию для отображения на форме приложения

            evoThreadWatcher.Stop();

            app.appThreadInfo.evoCycleCounter++;
            app.appThreadInfo.evoCycleTime_millisec = evoThreadWatcher.ElapsedMilliseconds;
        }

        // ****************************************************************************************               
    }
}
