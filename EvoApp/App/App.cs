using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvoApp
{
    public class App
    {
        // имя объекта, который будем использовать для лока разделяемого между потоками объекта - оно может быть произвольным
        static object lockerObjWithSomeName = new object();

        public Desk desk { get; set; } = new Desk();
        public Population population = new Population();
        // демонстрация и лока и геттеров/сеттеров свойств  *****************************************************
                protected EvoSpeed evo_speed = EvoSpeed.Hi;

                public EvoSpeed evoSpeed
                { 
                    get 
                    {
                        return evo_speed;
                    }
                    set 
                    {
                        lock (lockerObjWithSomeName)
                        {
                            evo_speed = value;
                        }
                    }
                }
        // ******************************************************************************************************

        public AppInitResult Init()
        {
            AppInitResult res = new AppInitResult();

            int cellCount = this.desk.Init();
            Console.WriteLine("! ------- инициализация игрового поля завершена, количество инициированных ячеек равно " + cellCount);
            res.cellCount = cellCount;


            int entityCount = population.Generate();
            Console.WriteLine("! ------- инициализация сущностей завершена, количество инициированных сущностей равно " + entityCount);
            res.entityCount = entityCount;

            return res;
        }

        public void Run()
        {
            Console.WriteLine("! ---------------- игра запущена");
            desk.CalcNextTick();
        }


    }
}
