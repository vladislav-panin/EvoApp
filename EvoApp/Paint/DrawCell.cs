using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public class DrawCell: DrawBase
    {
        public DrawCell () : base()
        {

        }

        override public void paintCell(Graphics canvasGraph, int originX, int originY, int width, int height)
        {
            base.paintCell(canvasGraph, originX, originY, width, height);
        }
    }
}
