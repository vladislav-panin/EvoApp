using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    /*
     * Инверсия текущего значения в заданном диапазоне [min, max].
     * Для слайдера.
     * Val() вернет инвертированное значение val, смещенное относительно max вниз настолько же, насколько прямое смещено относительно min вверх.
     * 
     * Set (int val) устанавливает "прямое" значение
     * 
     * То есть, например, для диапазона [min = 0; max = 10] установлено текущее значение val = 3;
     * Тогда Val() вернет "инвертированное" значение inverted_val равное (max - (val - min)) равное 7
     * 
     * А для диапазона [min = 3; max = 10] и установленного текущего значения val = 4;
     * значение inverted_val будет равно (max - (val - min)) равное 9
     */
    public class Invertor
    {
        private int min = -1; 
        private int max = -1;
        private int val = -1;

        public Invertor (int min, int max, int val)
        {
            if (val > max || val < min)
                throw new Exception("Попытка установить значение Invertor.val вне установленного диапазона значений!");

            this.min = min;
            this.max = max;
            this.val = val;
        }

        public void Set (int val)
        {
            if (val > max || val < min)
                throw new Exception("Попытка установить значение Invertor.val вне установленного диапазона значений!");

            this.val = val;
        }

        public int Val()
        {
            return (max - (val - min));
        }
    }
}
