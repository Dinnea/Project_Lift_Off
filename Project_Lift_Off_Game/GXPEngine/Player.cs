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

    //MOVEMENT CHECK PLAYERS MOVEMENT
    protected int mActive1;
    protected bool mActive1Lock;
    protected int mActive2;
    protected bool mActive2Lock;

    // SPEED VARIABLES
    protected float speed;
    protected float xSpeed;
    protected float ySpeed;


    // POWERUP VARIABLES
    protected bool hasPowerup = false;
    protected bool hasBad = false;
    protected int powerId;
    protected Random rnd = new Random();
    protected int powerTime = 2;
    protected int badTime = 5;
    protected int timePickedUp;
    protected int timer;
    protected bool wallCrusher;
    protected int isItTime;
    protected bool canBeHit;
    protected int playerNumber;
    protected int isItBad;

    //POWERUP IMAGERY
    private Sprite _fast;
    private Sprite _shield;
    private Sprite _wall;
    private Sprite _bad;

    //SOUND
    private Sound _powerUp;
    private Sound _trap;

    public Player( String filename ) : base( filename )
    {
        _powerUp = new Sound("Powerup.wav");
        _trap = new Sound("trap.wav");

        _fast = new Sprite("powerup.png");
        _shield = new Sprite("shield.png");
        _wall = new Sprite("wall_crusher.png");
        _bad = new Sprite("bad.png");

        AddChild(_fast);
        AddChild(_shield);
        AddChild(_wall);
        AddChild(_bad);

        _fast.visible = false;
        _shield.visible = false;
        _wall.visible = false;
        _bad.visible = false;

        _fast.x = -15;
        _fast.y = -15;

        _shield.x = -15;
        _shield.y = -15;

        _wall.x = -15;
        _wall.y = -15;

        _bad.x = -15;
        _bad.y = -15;

        //SetScaleXY(0.7f, 0.7f);
        this.SetScaleXY(0.4f, 0.4f);
        //this.SetXY(64, 64);
    }    
        void Update()
        {
        
        }

    //--------------------------------------------------
    //                   Movement
    //---------------------------------------------------
    public void PlayerMovement()
    {
        //movement
        xSpeed = 0;
        ySpeed = 0;

        //check movement players
        mActive1 = 0;
        mActive1Lock = true;

        //check movement players
        mActive2 = 0;
        mActive2Lock = true;

        if (xSpeed == 0 || ySpeed == 0)
        {
            mActive1Lock = true;
            mActive2Lock = true;
        }

        if ( Input.GetKey ( keyLeft ) )
        {
            xSpeed = -speed;

            mActive1 = 1;
            mActive1Lock = false;

            mActive2Lock = false;
            mActive2 = 1;
        }

        if ( Input.GetKey ( keyRight ) )
        {
            xSpeed = speed;

            mActive1 = 2;
            mActive1Lock = false;

            mActive2Lock = false;
            mActive2 = 2;
        }

        if ( Input.GetKey ( keyUp ) )
        {
            ySpeed = -speed;

            mActive1 = 3;
            mActive1Lock = false;

            mActive2Lock = false;
            mActive2 = 3;
        }

        if ( Input.GetKey ( keyDown ) )
        {
            ySpeed = speed;

            mActive1 = 4;
            mActive1Lock = false;

            mActive2Lock = false;
            mActive2 = 4;
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
        if ( other is PowerUp && hasPowerup == false && hasBad == false)
        {
            isItBad = rnd.Next(1, 11);
            if ( isItBad == 1 )
            {
                _trap.Play();
                hasBad = true;
                timePickedUp = Time.time;
                other.LateDestroy();
            }
            else {
                _powerUp.Play();
                isItTime = rnd.Next(1, 5);

                if ( isItTime == 1 )
                {
                    if (playerNumber == 1)
                    {
                        Level.maxTime = Level.maxTime + 5;
                        other.LateDestroy();
                    }
                    
                    if ( playerNumber == 2)
                    {
                        Level.maxTime = Level.maxTime - 5;
                        other.LateDestroy();
                    }
                    
                }
                else
                {
                    hasPowerup = true;
                    timePickedUp = Time.time;
                    powerId = rnd.Next(1, 4);
                    other.LateDestroy();
                }
            }
            
        }
    }
    //-------------------------------------
    //              PowerUps
    //------------------------------------

    public void PoweredUp()
    {
        timer = ( Time.time -  timePickedUp ) / 1000;
        switch ( powerId )
        {
            case 1:
                 speed = 4.0f;
                _fast.visible = true;
                break;
            case 2:
                if ( playerNumber == 1 )
                {
                     powerTime = 5;
                    _shield.visible = true;
                    canBeHit = false;
                }
                else if ( playerNumber == 2 )
                {
                     speed = 2.1f;
                    _fast.visible = true;
                    break;
                }
                break;
            case 3:
                _wall.visible = true;
                wallCrusher = true;
                break;
        }

        if ( timer >=  powerTime )
        {
            _fast.visible = false;
            _shield.visible = false;
            _wall.visible = false;

            hasPowerup = false;
            timer = 0;
            powerTime = 2;
            wallCrusher = false;
            if ( playerNumber == 1)
            {
                speed = 2f;
            }
            else if ( playerNumber == 2)
            {
                speed = 1.4f;
            }
        }
    }

    public void Trap()
    {
        timer = ( Time.time - timePickedUp ) / 1000;
        _bad.visible = true;

        if ( playerNumber == 1 )
        {
            keyUp = Key.DOWN;
            keyLeft = Key.RIGHT;
            keyDown = Key.UP;
            keyRight = Key.LEFT;

            if ( timer >= badTime )
            {
                keyUp = Key.UP;
                keyLeft = Key.LEFT;              
                keyDown = Key.DOWN;
                keyRight = Key.RIGHT;

                powerTime = 2;
                hasBad = false;
                timer = 0;
                _bad.visible = false;
            }
        }
        if ( playerNumber == 2 )
        {
            keyUp = Key.S;
            keyLeft = Key.D;
            keyDown = Key.W;
            keyRight = Key.A;

            if ( timer >= badTime )
            {
                keyUp = Key.W;
                keyLeft = Key.A;
                keyDown = Key.S;
                keyRight = Key.D;

                powerTime = 2;
                hasBad = false;
                timer = 0;
                _bad.visible = false;
            }
        }
    }
}
