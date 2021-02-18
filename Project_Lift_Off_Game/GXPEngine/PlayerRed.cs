using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerRed : Player
{

    PlayerRedAnimation _playerMove2;
    public PlayerRed() : base( "circle2.png" )
    {

        this.speed = 1.4f;
        this.playerNumber = 2;

        this.wallCrusher = false;
        this.hasPowerup = false;

        this.SetScaleXY(0.4f, 0.4f);

        _playerMove2 = new PlayerRedAnimation();
        AddChild(_playerMove2);
    }

    void Update()
    {
        // PLAYER 2 
        if (mActive2Lock == true)
        {
            this.alpha = 1;
            _playerMove2.alpha = 0;
        }
        else if (mActive1Lock == false)
        {
            _playerMove2.alpha = 1;
            this.alpha = 0;
        }

        if (mActive2 == 1) //move left
        {
            _playerMove2.rotation = 270;
        }

        if (mActive2 == 2) //move right
        {
            _playerMove2.rotation = 90;
        }

        if (mActive2 == 3) //move up
        {
            _playerMove2.rotation = 180;
        }

        if (mActive2 == 4) //move down
        {
            _playerMove2.rotation = 0;
        }

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
}