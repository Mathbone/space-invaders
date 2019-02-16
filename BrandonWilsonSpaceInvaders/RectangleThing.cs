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
     * This class expidites the drawing of rectangles.
     * adapted from dvb
     * ******************************************/
    class RectangleThing : Thing2D
    {
        public RectangleThing(int penWidthFoo, int xFoo, int yFoo,
       int widthFoo, int heightFoo,
       int gWidthFoo, int gHeightFoo,
        Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        { }
        /*********************************************
         * Brandon Wilson 04/18
         * This function draws the rectangle.
         * ******************************************/
        public override void drawThing()
        {
            GameMaster.canvas.DrawRectangle(p, x, y, width, height);
        }
    }
}
