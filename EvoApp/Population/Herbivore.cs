using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class Herbivore : Entity
    {
        protected static Point[] stepHerbivore = new Point[]
        {
            new Point(+1,-1), new Point(-1,-1),
            new Point(+1,-1), new Point(-1,-1),
            new Point(+1,+1), new Point(-1,+1),
            new Point(+1,+1), new Point(-1,+1),
        };

        override public Point[] getStepShift()
        {
            return stepHerbivore;
        }
        // *************************************************************************************************************************************************

        public Herbivore(int entityId) : base(entityId)
        {
        }
        // *************************************************************************************************************************************************
        override protected void drawOnRect(Graphics canvasGraph, int xOriginGlobal, int yOriginGlobal, int width, int height)
        {
            canvasGraph.DrawImage(Population.bmpHerbivore, xOriginGlobal, yOriginGlobal);
        }
        // *************************************************************************************************************************************************

        // *************************************************************************************************************************************************
    }
}
