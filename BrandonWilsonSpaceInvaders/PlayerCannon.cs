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
     * This class represents the player controlled ion cannon at the bottom of the screen.
     * ******************************************/
    class PlayerCannon : MovingThing
    {
        public PlayerCannon(int penWidthFoo, int xFoo, int yFoo,
         int widthFoo, int heightFoo,
         int gWidthFoo, int gHeightFoo,
         Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        {
            parts.Add(new RectangleThing(penWidthFoo,xFoo, yFoo+heightFoo*2/3, widthFoo, heightFoo/3, gWidthFoo, gHeightFoo, dColor, gFoo));
            parts.Add(new RectangleThing(penWidthFoo, xFoo+widthFoo*2/5, yFoo, widthFoo/5, heightFoo*2/3, gWidthFoo, gHeightFoo, dColor, gFoo));
        }
        /*********************************************
         * Brandon Wilson 04/18
         * Allows the mouse to control the position of the player cannon.
         * ******************************************/
        public override void update()
        {
            x = System.Windows.Forms.Cursor.Position.X-width/2;
            foreach (Thing2D thing in parts)
            {
                thing.X = (System.Windows.Forms.Cursor.Position.X - thing.getWidth() / 2);
            }
        }
    }
}
