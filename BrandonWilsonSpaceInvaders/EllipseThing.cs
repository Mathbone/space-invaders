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
     * This class is used to help automate the process of drawing ellipses.
     * adapted from dvb
     * ******************************************/
    class EllipseThing : Thing2D
    {
        public EllipseThing(int penWidthFoo, int xFoo, int yFoo,
            int widthFoo, int heightFoo,
            int gWidthFoo, int gHeightFoo,
            Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        { }
        /*********************************************
         * Brandon Wilson 04/18
         * This function draws the ellipse.
         * ******************************************/
        public override void drawThing()
        {
            GameMaster.canvas.DrawEllipse(p, x, y, width, height);
        }
    }
}
