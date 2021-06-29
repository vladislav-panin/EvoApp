using EvoApp.Properties;
using System;
using System.Drawing;
using System.Resources;

namespace EvoApp
{
    // Animal - параметризованный класс (Generic). Параметр дженерика - базовый класс еды, которую он ест.
    // То есть, еда, которую он может съесть - должна быть унаследована от <EatableClass>
    public abstract class Animal <EatableClass> : BiomBase
    {
        public int satiety = 50;

        // действия при вычислении очередного шага эволюции

        abstract public void doMove();  // передвигает на другую ячейку (определямую смещением getStepShift()) глобального Desk        
        // ***********************************************************************************************************************************

        protected static Type eatableType = typeof(EatableClass); // Тип класса, определенного как базовый класс для еды

        public bool IsEatable(BiomBase foodObj) {

            Type baseUnitObj_Type = foodObj.GetType();
            bool res = baseUnitObj_Type.IsSubclassOf(eatableType);
            return res;
        }
        
        public Animal (long id, EUnitType type, EUnitSex sex) : base(id, type, sex)
        { 
        }

        public override void doDrink()
        {
        }
    }
}
