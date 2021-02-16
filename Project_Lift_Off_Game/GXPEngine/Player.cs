using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class Player : Sprite
{
    //MOVEMENT KEYS
    protected int keyLeft = Key.A;
    protected int keyRight = Key.D;    
    protected int keyUp = Key.W;
    protected int keyDown = Key.S;

    // SPEED VARIABLES
    protected float speed;
    protected float xSpeed;
    protected float ySpeed;


    // POWERUP VARIABLES
    protected bool hasPowerup;
    protected int powerId;
    protected Random rnd = new Random();
    protected int powerTime = 2;
    protected int timePickedUp;
    protected int timer;
    protected bool wallCrusher;
    protected int isItTime;
    protected bool canBeHit;
    protected int playerNumber;

    public Player( String filename ) : base( filename )
    {
    }
    
        void Update()
        {
        //Check for power up!
            if ( hasPowerup )
            {
                poweredUp();
            }
        }

    //--------------------------------------------------
    //                   Movement
    //---------------------------------------------------
    public void PlayerMovement()
    {
        //movement
        xSpeed = 0;
        ySpeed = 0;

        if ( Input.GetKey ( keyLeft ) )
        {
            xSpeed = -speed;
            //SetFrame(5);
            //this.scaleX = -1;
        }

        if ( Input.GetKey ( keyRight ) )
        {
            xSpeed = speed;
            //SetFrame(2);
            //this.scaleX = 1;
        }

        if ( Input.GetKey ( keyUp ) )
        {
            ySpeed = -speed;
            //this.scaleY = 1;
            //SetCycle(7,7,30,false);
        }

        if ( Input.GetKey ( keyDown ) )
        {
            ySpeed = speed;
            //this.scaleY = -1;
        }

        Move( xSpeed, ySpeed );
    }

    //----------------------------------------------------
    //                        Collisions
    //-----------------------------------------------------
    public virtual void OnCollision( GameObject other )
    {

        //enviroment collisions
        if ( other is Wall && wallCrusher == false || other is Border && wallCrusher == true )
        {
            Move( -xSpeed, -ySpeed );
        }

        else if ( other is Wall && wallCrusher == true )
        {
            other.LateDestroy();
        }

        //Power up collision!
        if ( other is PowerUp )
        {

            isItTime = rnd.Next( 1, 5 );

            if ( isItTime == 1 )
            {
                Level.maxTime = Level.maxTime - 5;
                other.LateDestroy();
            }
            else
            {
                hasPowerup = true;
                timePickedUp = Time.time;
                powerId = rnd.Next( 1, 4 );
                other.LateDestroy();
            }
        }
    }
    //-------------------------------------
    //              PowerUps
    //------------------------------------

    public void poweredUp()
    {
         timer = ( Time.time -  timePickedUp ) / 1000;
        switch ( powerId )
        {
            case 1:
                 speed = 4.0f;
                break;
            case 2:
                if ( playerNumber == 1 )
                {
                     powerTime = 5;
                     canBeHit = false;
                }
                else if ( playerNumber == 2 )
                {
                     speed = 2.1f;
                    break;
                }
                break;
            case 3:
                 wallCrusher = true;
                break;
        }

        if ( timer >=  powerTime )
        {
            hasPowerup = false;
            timer = 0;
            wallCrusher = false;
            if ( playerNumber == 1)
            {
                speed = 1f;
            }
            else if ( playerNumber == 2)
            {
                speed = 0.7f;
            }
        }
    } 
}
