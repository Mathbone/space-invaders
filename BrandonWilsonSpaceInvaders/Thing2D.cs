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
     * This class is an abstract class that will contain most properties common to drawn objects in the game. 
     * adapted from dvb
     * ******************************************/
    class Thing2D
    {
        protected Graphics g;
        protected Pen p;
        int penWidth;
        protected int x, y, width, height;
        Color drawColor;
        int gWidth, gHeight;
        public int Y { get { return y; } set { y = value; } }
        public int X { get { return x; } set { x = value; } }
        public Thing2D(int penWidthFoo, int xFoo, int yFoo,
           int widthFoo, int heightFoo,
           int gWidthFoo, int gHeightFoo,
           Color dColor, Graphics gFoo)
        {
            penWidth = penWidthFoo;
            x = xFoo; y = yFoo; width = widthFoo; height = heightFoo;
            drawColor = dColor;
            gWidth = gWidthFoo; gHeight = gHeightFoo;
            p = new Pen(drawColor, penWidth);
            g = gFoo;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * generates a new grid of enemies when all enemies in the previous round are found to be defeated.
         * ******************************************/
        public virtual void drawThing()
        {
            g.DrawRectangle(p, x, y, width, height);
            // g.DrawEllipse(p, x, y, width, height);
        }
        public int getWidth() { return width; }
        public int getHeight() { return height; }
    }
}
