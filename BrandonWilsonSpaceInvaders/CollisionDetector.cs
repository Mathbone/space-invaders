using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandonWilsonSpaceInvaders
{
    /*********************************************
     * Brandon Wilson 04/18
     * This is a static class used to collect the methods for collision detection.
     * ******************************************/
    static class CollisionDetector
    {
        /*********************************************
         * Brandon Wilson 04/18
         * This function detects the collision of two Thing2Ds by checking for a gap on all four sides.
         * If no gap is found the objects are colliding.
         * ******************************************/
        public static bool thingCollision(Thing2D thing1,Thing2D thing2)
        {
            if(thing1.X < thing2.X + thing2.getWidth() &&
               thing1.X + thing1.getWidth() > thing2.X &&
               thing1.Y < thing2.Y + thing2.getHeight() &&
               thing1.getHeight() + thing1.Y > thing2.Y)
            {
                return true;
            }
            return false;
        }
    }
}
