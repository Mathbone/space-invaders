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
     * This class represents the enemy ships.
     * ******************************************/
    class EnemyShip : MovingThing
    {
        int xdir = 1;
        public EnemyShip(int penWidthFoo, int xFoo, int yFoo,
         int widthFoo, int heightFoo,
         int gWidthFoo, int gHeightFoo,
         Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        {
            parts.Add(new EllipseThing(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo, gWidthFoo, gHeightFoo, dColor, gFoo));
        }
        /*********************************************
         * Brandon Wilson 04/18
         * updates the status of the object, moving sideways in most frames.
         * ******************************************/
        public override void update()
        {
            moveSideways();
        }
        /*********************************************
         * Brandon Wilson 04/18
         * flips the direction of sideways travel when the screen edge is reached.
         * ******************************************/
        public override void flipXDir()
        {
            xdir *= -1;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * moves down the screen when the edge is reached during sideways travel.
         * ******************************************/
        public override void moveDown()
        {
            y += 30;
            foreach(Thing2D thing in parts) { thing.Y += 30; }
        }
        /*********************************************
         * Brandon Wilson 04/18
         * moves sideways at a speed that increases as the game level progresses.
         * ******************************************/
        public void moveSideways()
        {
            x += xdir * (5+GameMaster.getLevel());
            foreach(Thing2D thing in parts) { thing.X += xdir * (5+GameMaster.getLevel()); }
        }
    }
}
