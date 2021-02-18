using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerGreen : Player
{
    private Sound _doorOpen;
    private Sound _keyCollect;
    private int _storedKeys; // How many keys the player holds. 

    public PlayerGreen() : base("circle.png")
    {
        _doorOpen = new Sound("EndDoor_Open.wav");
        _keyCollect = new Sound("Key_collect.wav");
        

        _storedKeys = 0;

        this.speed = 2f;
        this.playerNumber = 1;

        this.wallCrusher = false;
        this.canBeHit = true;

        //movement keys override
        this.keyLeft = Key.LEFT;
        this.keyRight = Key.RIGHT;
        this.keyUp = Key.UP;
        this.keyDown = Key.DOWN;
    }

    void Update()
    {
        PlayerMovement();
        //Check for power up!
        if (hasPowerup)
        {
            PoweredUp();
        }

        //check for bad

        if (hasBad)
        {
            Trap();
        }
    }

    //------------------------------------------------------------------------------------
    //                        Collisions (base + green exclusive)
    //------------------------------------------------------------------------------------
    public override void OnCollision( GameObject other )
    {
        base.OnCollision( other );

        //pickup
        if ( other is Keys && _storedKeys < 3)
        {
            _keyCollect.Play();
            _storedKeys = _storedKeys + 1; //pickup a key
        }

        if ( other is Keys && _storedKeys == 3)
        {
        
            //_keyCollect.Play();
            _doorOpen.Play();
            _storedKeys = _storedKeys + 1; //pickup a key
        }

        if ( other is Exit && _storedKeys == 3 )
        {
            End();
            Menu.playerID = 1;
        }

        else if ( other is Exit && _storedKeys < 3 )
        {
            Move(-xSpeed, -ySpeed);
        }

        //player collision
        if ( other is PlayerRed && canBeHit == true )
        {
            End();
            Menu.playerID = 2;
        }
    }
    
   
    public void End()
    {
        Menu.switchMenu = 1;
    }
}