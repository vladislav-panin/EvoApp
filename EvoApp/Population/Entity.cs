using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class Entity: BaseEntity
    {
        public IBehavior behavior { get; set; }

        public Entity (int entityId) : base (entityId)
        {

        }

        //инициализация ячеек игрового поля 1000*1000
        virtual public int Paint (Graphics canvasGraph, DeskCell cell)
        {
            return 0;
        }
    }
}
