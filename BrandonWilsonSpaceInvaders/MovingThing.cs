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
     * This is an abstract class used to represent things that are made up
     * of multiple parts. (e.g. the player cannon is drawn with two rectangles, but needs
     * a unified bounding box)
     * ******************************************/
    class MovingThing :Thing2D
    {
        protected List<Thing2D> parts;
        public MovingThing(int penWidthFoo, int xFoo, int yFoo,
         int widthFoo, int heightFoo,
         int gWidthFoo, int gHeightFoo,
         Color dColor, Graphics gFoo) :
           base(penWidthFoo, xFoo, yFoo, widthFoo, heightFoo,
               gWidthFoo, gHeightFoo, dColor, gFoo)
        { parts = new List<Thing2D>(); }
        /*********************************************
         * Brandon Wilson 04/18
         * draws each part in the list of parts. 
         * ******************************************/
        public override void drawThing()
        {
            foreach (Thing2D thing in parts)
                thing.drawThing();
        }
        /*********************************************
         * Brandon Wilson 04/18
         * virtual functions that allow the call of child class functions from the master list of game objects.
         * ******************************************/
        public virtual void update() { }
        public virtual void flipXDir() { }
        public virtual void moveDown() { }

    }
}
