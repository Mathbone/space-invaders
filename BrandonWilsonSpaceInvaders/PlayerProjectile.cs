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
     * This class represents projectiles fired by the player.
     * separating the projectiles eliminates friendly fire.
     * ******************************************/
    class PlayerProjectile : Projectile
    {
        public PlayerProjectile(int penWidthFoo, int xFoo, int yFoo,
         int widthFoo, int heightFoo,
         int gWidthFoo, int gHeightFoo,
         Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        {
            parts.Add(new RectangleThing(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo, gWidthFoo, gHeightFoo, dColor, gFoo));
        }
        /*********************************************
         * Brandon Wilson 04/18
         * moves the projectile straight up the screen.
         * ******************************************/
        public override void update()
        {
            y -= 15;
            foreach (Thing2D thing in parts)
                thing.Y -= 15;
        }
    }
}
