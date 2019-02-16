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
     * This class represents the projectiles fired by the enemy.
     * Separating the projectiles avoids friendly fire.
     * ******************************************/
    class EnemyProjectile : Projectile
    {
        public EnemyProjectile(int penWidthFoo, int xFoo, int yFoo,
         int widthFoo, int heightFoo,
         int gWidthFoo, int gHeightFoo,
         Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        {
            // projectile is a single box.
            parts.Add(new RectangleThing(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo, gWidthFoo, gHeightFoo, dColor, gFoo));
        }
        /*********************************************
         * Brandon Wilson 04/18
         * updates the status of the projectile, moving down the screen at 15 pixels per frame. 
         * ******************************************/
        public override void update()
        {
            y += 15;
            foreach(Thing2D thing in parts)
            {
                thing.Y += 15;
            }
        }
    }
}
