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
        protected Desk desk = new Desk();

        public void Init()
        {
            Thread threadInit = new Thread(() => DoThreadInit(this)); // () => DoThreadInit(this) - это определение лямбда функции для порождения объекта с использованием функционального интерфейса
            threadInit.Start();
        }

        public static void DoThreadInit(App app)
        {
            
            int counter = app.desk.Init();
            Console.WriteLine("! ------- инициализация игрового поля завершена");

            Thread.Sleep(100);

            Program.appForm.InitAppIndikator();
            Program.appForm.SetCellCount(counter);
        }

        public void Run()
        {
            Console.WriteLine("! ---------------- игра запущена");
        }
    }
}
