using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoApp
{
    public interface IBehavior
    {
        DeskCell /*cell to*/ Move (DeskCell fromCell);

        bool Catch (DeskCell current, DeskCell tryingToRichCell);
        bool Eat (Entity who, Entity whom, DeskCell current);
    }
}
