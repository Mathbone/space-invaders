using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace BrandonWilsonSpaceInvaders
{
    /*********************************************
     * Brandon Wilson 04/18
     * This class is used to manage all other objects and gameplay.
     * ******************************************/
    class GameMaster
    {
        List<MovingThing> DrawnObjects;
        List<MovingThing> toRemove;
        List<MovingThing> thingsToAdd;
        int lives = 3;
        int score = 0;
        int highscore = 0;
        static int level = 0;
        public static Graphics canvas;
        public static Random rand = new Random();
        Font drawFont = new Font("Copperplate Gothic Bold", 20);
        SolidBrush drawBrush = new SolidBrush(Color.White);
        StringFormat drawFormat = new StringFormat();
        public GameMaster(Graphics gFoo)
        {
            DrawnObjects = new List<MovingThing>();
            canvas = gFoo;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * This function draws a new frame by clearing the screen, then drawing each element one at a time. 
         * Double Buffering on the form is necessary for smooth performance with this strategy.
         * ******************************************/
        public void draw()
        {
            canvas.Clear(Color.Black);
            foreach (MovingThing thing in DrawnObjects)
                thing.drawThing();
            drawGUI();
        }
        /*********************************************
         * Brandon Wilson 04/18
         * Allows the addition of new objects to the list of drawn objects.
         * Used by the master form to respond to mouse events
         * ******************************************/
        public void addThing(MovingThing thing)
        {
            DrawnObjects.Add(thing);
        }
        /*********************************************
         * Brandon Wilson 04/18
         * This function updates each object individually. Also contains the firing 
         * mechanism for enemy ships, since the ships don't know which GameMaster contians them and thus can't 
         * add to the correct DrawnObjects list.
         * ******************************************/
        public void update()
        {
            thingsToAdd = new List<MovingThing>();
            foreach (MovingThing thing in DrawnObjects)
            {
                thing.update();
                if (thing is EnemyShip && rand.Next() % (2000 - level * 50) == 0)
                    thingsToAdd.Add(new EnemyProjectile(5, thing.X + thing.getWidth() - 3, thing.Y, 5, 20, 6000, 6000, Color.Orange, GameMaster.canvas));
            }
            foreach(MovingThing thing in thingsToAdd)
                DrawnObjects.Add(thing);
        }
        /*********************************************
         * Brandon Wilson 04/18
         * Checks for any enemy ships, returning true if none are found.
         * ******************************************/
        public bool isEveryEnemyDefeated()
        {
            foreach(MovingThing thing in DrawnObjects)
                if (thing is EnemyShip)
                    return false;
            return true;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * generates a new grid of enemies when all enemies in the previous round are found to be defeated.
         * ******************************************/
        public void generateEnemies(Form form)
        {
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 11; j++)
                    DrawnObjects.Add(new EnemyShip(3, j * 60, i * 60, 35, 15, form.Width, form.Height, Color.Blue, canvas));
            score += level * 100;
            level++;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * detects whether any of the enemy ships has reached the edge of the game screen.
         * ******************************************/
        public bool isEdgeReached(Form form)
        {
            foreach (MovingThing thing in DrawnObjects)
                if(thing is EnemyShip)
                    if(thing.X >form.Width - thing.getWidth()|| thing.X < 0)
                        return true;

            return false;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * moves enemies down the screen and reverses the direction of sideways travel.
         * ******************************************/
        public void downAndReverse()
        {
            foreach (MovingThing thing in DrawnObjects)
            {
                if(thing is EnemyShip)
                {
                    thing.flipXDir();
                    thing.moveDown();
                }
            }
        }
        /*********************************************
         * Brandon Wilson 04/18
         * detects whether a projectile has impacted a vulnerable target.
         * ******************************************/
        public void detectCollision()
        {
            toRemove = new List<MovingThing>();
            foreach(MovingThing thing1 in DrawnObjects)
            {
                if(thing1 is PlayerProjectile)
                    foreach(MovingThing thing2 in DrawnObjects)
                        if(thing2 is EnemyShip)
                            if (CollisionDetector.thingCollision(thing1, thing2))
                            {
                                toRemove.Add(thing1);
                                toRemove.Add(thing2);
                                score += 20;
                            }
                if(thing1 is PlayerCannon)
                    foreach(MovingThing thing2 in DrawnObjects)
                        if(thing2 is EnemyProjectile)
                            if (CollisionDetector.thingCollision(thing1, thing2))
                            {
                                toRemove.Add(thing2);
                                lives--;
                                Thread.Sleep(3000);
                            }
            }
            foreach(MovingThing thing in toRemove)
            {
                DrawnObjects.Remove(thing);
            }
        }
        /*********************************************
         * Brandon Wilson 04/18
         * draws the string information necessary for the user.
         * ******************************************/
        public void drawGUI()
        {
            if (score > highscore)
                highscore = score;
            string gui = "Level: " + level.ToString() + "\r\n";
            gui += "Lives: " + lives.ToString() + "\r\n";
            gui += "Score: " + score.ToString() + "\r\n";
            gui += "High Score: " + highscore.ToString();
            canvas.DrawString(gui,drawFont,drawBrush,0,0); 
        }
        /*********************************************
         * Brandon Wilson 04/18
         * allows other entities to know what level it is.
         * ******************************************/
        public static int getLevel() { return level; }
        /*********************************************
         * Brandon Wilson 04/18
         * performs all tasks involved in resetting a game to the default state.
         * ******************************************/
        public void resetGame()
        {
            score = 0;
            level = 0;
            lives = 3;
            foreach(MovingThing thing in DrawnObjects)
            {
                if (thing is EnemyShip || thing is Projectile)
                    toRemove.Add(thing);
            }
            foreach (MovingThing thing in toRemove)
                DrawnObjects.Remove(thing);
        }
        /*********************************************
         * Brandon Wilson 04/18
         * detects whether either loss condition has been met.
         * ******************************************/
        public bool gameIsLost(int baseline)
        {
            foreach (MovingThing thing in DrawnObjects)
                if (thing is EnemyShip && thing.Y + thing.getHeight() > baseline)
                    return true;
            if (lives <= 0)
                return true;
            return false;
        }
        /*********************************************
         * Brandon Wilson 04/18
         * removes projectiles from the screen when a new level is reached.
         * ******************************************/
        public void removeProjectiles()
        {
            toRemove = new List<MovingThing>();
            foreach (MovingThing thing in DrawnObjects)
                if (thing is Projectile)
                    toRemove.Add(thing);
            foreach (MovingThing thing in toRemove)
                DrawnObjects.Remove(thing);
        }
    }
}
