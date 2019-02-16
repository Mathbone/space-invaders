using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrandonWilsonSpaceInvaders
{
    /*********************************************
     * Brandon Wilson 04/18
     * This class is an abstract class used to represent the projectiles fired.
     * separating the projectiles into two groups eliminates friendly fire. 
     * ******************************************/
    class Projectile : MovingThing
    {
        public Projectile(int penWidthFoo, int xFoo, int yFoo,
         int widthFoo, int heightFoo,
         int gWidthFoo, int gHeightFoo,
         Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        { }
    }
}
